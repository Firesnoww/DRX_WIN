using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeDatos : MonoBehaviour
{
    // Lista de todos los �tomos disponibles (usando ScriptableObject)
    public ScriptableMolecula[] Atomos;

    // Lista de �tomos usados
    public List<ScriptableMolecula> AtomoUsado = new List<ScriptableMolecula>();

    // Objeto que ser� instanciado como el contenedor (Material)
    public GameObject Material;

    public GameObject ref_Insta;

    // M�todo para seleccionar un �tomo de manera aleatoria y pasarlo a la lista de usados
    public void randomAtom()
    {
        StartCoroutine(RutinaAleatoria());
    }

    // M�todo para mostrar la lista completa de �tomos y seleccionar uno manualmente
    public void listaNormal(int index)
    {
        if (index < 0 || index >= Atomos.Length)
        {
            Debug.LogWarning("�ndice fuera de rango.");
            return;
        }

        // Seleccionar el �tomo seg�n el �ndice
        ScriptableMolecula selectedAtom = Atomos[index];

        // Instanciar el contenedor "Material" en la posici�n deseada
        GameObject container = Instantiate(Material, Vector3.zero, Quaternion.identity);

        // Asignar el ScriptableMolecula al componente InfoDatos en el objeto Material instanciado
        InfoDatos infoDatosComponent = container.GetComponent<InfoDatos>();
        if (infoDatosComponent != null)
        {
            infoDatosComponent.SMolecula = selectedAtom;

        }

        Debug.Log("Contenedor instanciado manualmente para el �tomo: " + selectedAtom.name);
    }

    public IEnumerator RutinaAleatoria()
    {
        // Verificar si todos los �tomos han sido usados
        if (AtomoUsado.Count >= Atomos.Length)
        {
            Debug.LogWarning("No hay m�s �tomos disponibles para mostrar aleatoriamente.");
            yield break;
        }

        // Seleccionar un �tomo aleatorio que a�n no haya sido usado
        ScriptableMolecula selectedAtom = null;
        int attempts = 0;
        while (selectedAtom == null && attempts < Atomos.Length)
        {
            int randomIndex = Random.Range(0, Atomos.Length);
            ScriptableMolecula potentialAtom = Atomos[randomIndex];

            // Si el �tomo a�n no ha sido usado, lo seleccionamos
            if (!AtomoUsado.Contains(potentialAtom))
            {
                selectedAtom = potentialAtom;
            }
            attempts++;
        }

        // Verificar si se encontr� un �tomo v�lido
        if (selectedAtom != null)
        {
            // Instanciar el contenedor "Material" en la posici�n deseada
            GameObject container = Instantiate(Material, ref_Insta.transform.position, ref_Insta.transform.rotation);

            // Asignar el ScriptableMolecula al componente InfoDatos en el objeto Material instanciado
            InfoDatos infoDatosComponent = container.GetComponent<InfoDatos>();
            if (infoDatosComponent != null)
            {
                infoDatosComponent.SMolecula = selectedAtom;

            }

            // Agregar el ScriptableMolecula seleccionado a la lista de usados
            AtomoUsado.Add(selectedAtom);

            Debug.Log("Contenedor instanciado y �tomo asignado: " + selectedAtom.name);
        }
        
    }
}



