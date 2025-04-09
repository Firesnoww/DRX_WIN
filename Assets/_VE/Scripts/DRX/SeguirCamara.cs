using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public float rotationThreshold = 15f; // Margen en grados para permitir la rotación

    void Update()
    {
        Vector3 cameraForward = Camera.main.transform.forward; // Dirección de la cámara
        float angle = Vector3.Angle(transform.forward, cameraForward); // Diferencia de ángulo

        if (angle > rotationThreshold)
        {
            transform.forward = cameraForward; // Solo rota si supera el umbral
        }
    }
}
