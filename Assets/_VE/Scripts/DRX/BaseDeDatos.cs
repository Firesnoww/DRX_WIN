using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeDatos : MonoBehaviour
{
    // Lista de todos los átomos disponibles (usando ScriptableObject)
    public ScriptableMolecula[] Atomos;

    // Lista de átomos usados
    public List<ScriptableMolecula> AtomoUsado = new List<ScriptableMolecula>();

    // Objeto que será instanciado como el contenedor (Material)
    public GameObject Material;

    public GameObject ref_Insta;

    // Método para seleccionar un átomo de manera aleatoria y pasarlo a la lista de usados
    public void randomAtom()
    {
        StartCoroutine(RutinaAleatoria());
    }

    // Método para mostrar la lista completa de átomos y seleccionar uno manualmente
    public void listaNormal(int index)
    {
        if (index < 0 || index >= Atomos.Length)
        {
            Debug.LogWarning("Índice fuera de rango.");
            return;
        }

        // Seleccionar el átomo según el índice
        ScriptableMolecula selectedAtom = Atomos[index];

        // Instanciar el contenedor "Material" en la posición deseada
        GameObject container = Instantiate(Material, Vector3.zero, Quaternion.identity);

        // Asignar el ScriptableMolecula al componente InfoDatos en el objeto Material instanciado
        InfoDatos infoDatosComponent = container.GetComponent<InfoDatos>();
        if (infoDatosComponent != null)
        {
            infoDatosComponent.SMolecula = selectedAtom;

        }

        Debug.Log("Contenedor instanciado manualmente para el átomo: " + selectedAtom.name);
    }

    public IEnumerator RutinaAleatoria()
    {
        // Verificar si todos los átomos han sido usados
        if (AtomoUsado.Count >= Atomos.Length)
        {
            Debug.LogWarning("No hay más átomos disponibles para mostrar aleatoriamente.");
            yield break;
        }

        // Seleccionar un átomo aleatorio que aún no haya sido usado
        ScriptableMolecula selectedAtom = null;
        int attempts = 0;
        while (selectedAtom == null && attempts < Atomos.Length)
        {
            int randomIndex = Random.Range(0, Atomos.Length);
            ScriptableMolecula potentialAtom = Atomos[randomIndex];

            // Si el átomo aún no ha sido usado, lo seleccionamos
            if (!AtomoUsado.Contains(potentialAtom))
            {
                selectedAtom = potentialAtom;
            }
            attempts++;
        }

        // Verificar si se encontró un átomo válido
        if (selectedAtom != null)
        {
            // Instanciar el contenedor "Material" en la posición deseada
            GameObject container = Instantiate(Material, ref_Insta.transform.position, ref_Insta.transform.rotation);

            // Asignar el ScriptableMolecula al componente InfoDatos en el objeto Material instanciado
            InfoDatos infoDatosComponent = container.GetComponent<InfoDatos>();
            if (infoDatosComponent != null)
            {
                infoDatosComponent.SMolecula = selectedAtom;

            }

            // Agregar el ScriptableMolecula seleccionado a la lista de usados
            AtomoUsado.Add(selectedAtom);

            Debug.Log("Contenedor instanciado y átomo asignado: " + selectedAtom.name);
        }
        
    }
}



