using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAutomatica : MonoBehaviour
{
    public GameObject[] aRotar; // Array de objetos a rotar
    public float velocidadRotacion = 50f; // Velocidad de rotaci�n

    private Vector3[] direccionesRotacion; // Direcciones aleatorias de rotaci�n para cada objeto

    void Start()
    {
        // Asignar una direcci�n de rotaci�n aleatoria a cada objeto
        direccionesRotacion = new Vector3[aRotar.Length];
        for (int i = 0; i < aRotar.Length; i++)
        {
            direccionesRotacion[i] = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized; // Normalizamos para evitar velocidades extremas
        }
    }

    void Update()
    {
        // Rotar cada objeto en su direcci�n asignada
        for (int i = 0; i < aRotar.Length; i++)
        {
            if (aRotar[i] != null)
            {
                aRotar[i].transform.Rotate(direccionesRotacion[i] * velocidadRotacion * Time.deltaTime);
            }
        }
    }
}
