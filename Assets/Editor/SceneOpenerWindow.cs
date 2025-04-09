using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections.Generic;



public class SceneOpenerWindow : EditorWindow
{
    private SceneOpenerData sceneOpenerData;

    private const string DataPath = "Assets/Editor/SceneOpenerData.asset";

    [MenuItem("Tools/Abrir Escenas")]
    public static void ShowWindow()
    {
        GetWindow<SceneOpenerWindow>("Abrir Escenas");
    }

    private void OnEnable()
    {
        LoadData();
    }

    private void OnGUI()
    {
        if (sceneOpenerData == null)
        {
            EditorGUILayout.HelpBox("Error al cargar los datos. Aseg�rate de que el archivo de datos exista.", MessageType.Error);
            return;
        }

        EditorGUILayout.LabelField("Grupos de Escenas", EditorStyles.boldLabel);

        // Iterar a trav�s de los grupos de escenas
        for (int i = 0; i < sceneOpenerData.sceneGroups.Count; i++)
        {
            var group = sceneOpenerData.sceneGroups[i];

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.BeginHorizontal();
            group.groupName = EditorGUILayout.TextField("Nombre del Grupo", group.groupName);

            // Bot�n para eliminar grupo
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                sceneOpenerData.sceneGroups.RemoveAt(i);
                SaveData();
                break;
            }
            EditorGUILayout.EndHorizontal();

            // Lista de escenas
            if (group.scenes == null) group.scenes = new List<SceneAsset>();
            SerializedObject serializedObject = new SerializedObject(sceneOpenerData);
            SerializedProperty scenesProperty = serializedObject.FindProperty($"sceneGroups.Array.data[{i}].scenes");
            EditorGUILayout.PropertyField(scenesProperty, new GUIContent("Escenas"), true);
            serializedObject.ApplyModifiedProperties();

            // Bot�n para abrir las escenas
            if (GUILayout.Button($"Abrir {group.groupName}"))
            {
                OpenScenes(group);
            }

            EditorGUILayout.EndVertical();
        }

        // Bot�n para a�adir un nuevo grupo
        if (GUILayout.Button("A�adir Nuevo Grupo"))
        {
            sceneOpenerData.sceneGroups.Add(new SceneGroup() { groupName = "Nuevo Grupo", scenes = new List<SceneAsset>() });
            SaveData();
        }
    }

    private void OpenScenes(SceneGroup group)
    {
        if (group.scenes == null || group.scenes.Count == 0)
        {
            Debug.LogWarning("No hay escenas en el grupo: " + group.groupName);
            return;
        }

        // Abrir la primera escena normalmente
        string firstScenePath = AssetDatabase.GetAssetPath(group.scenes[0]);
        if (!string.IsNullOrEmpty(firstScenePath))
        {
            EditorSceneManager.OpenScene(firstScenePath, OpenSceneMode.Single);
        }
        else
        {
            Debug.LogWarning("Ruta de la escena inv�lida para la primera escena del grupo: " + group.groupName);
        }

        // Abrir las escenas adicionales de forma aditiva
        for (int i = 1; i < group.scenes.Count; i++)
        {
            string scenePath = AssetDatabase.GetAssetPath(group.scenes[i]);
            if (!string.IsNullOrEmpty(scenePath))
            {
                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
            }
            else
            {
                Debug.LogWarning("Ruta de la escena inv�lida para la escena en el �ndice " + i + " del grupo: " + group.groupName);
            }
        }
    }

    private void LoadData()
    {
        sceneOpenerData = AssetDatabase.LoadAssetAtPath<SceneOpenerData>(DataPath);

        if (sceneOpenerData == null)
        {
            sceneOpenerData = CreateInstance<SceneOpenerData>();
            AssetDatabase.CreateAsset(sceneOpenerData, DataPath);
            AssetDatabase.SaveAssets();
        }
    }

    private void SaveData()
    {
        EditorUtility.SetDirty(sceneOpenerData);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
