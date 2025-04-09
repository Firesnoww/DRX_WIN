using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAutomatica : MonoBehaviour
{
    public GameObject[] aRotar; // Array de objetos a rotar
    public float velocidadRotacion = 50f; // Velocidad de rotación

    private Vector3[] direccionesRotacion; // Direcciones aleatorias de rotación para cada objeto

    void Start()
    {
        // Asignar una dirección de rotación aleatoria a cada objeto
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
        // Rotar cada objeto en su dirección asignada
        for (int i = 0; i < aRotar.Length; i++)
        {
            if (aRotar[i] != null)
            {
                aRotar[i].transform.Rotate(direccionesRotacion[i] * velocidadRotacion * Time.deltaTime);
            }
        }
    }
}
