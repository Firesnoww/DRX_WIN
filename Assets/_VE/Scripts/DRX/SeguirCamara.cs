using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public float rotationThreshold = 15f; // Margen en grados para permitir la rotaci�n

    void Update()
    {
        Vector3 cameraForward = Camera.main.transform.forward; // Direcci�n de la c�mara
        float angle = Vector3.Angle(transform.forward, cameraForward); // Diferencia de �ngulo

        if (angle > rotationThreshold)
        {
            transform.forward = cameraForward; // Solo rota si supera el umbral
        }
    }
}
