using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModelosAtomicos : MonoBehaviour
{
    public GameObject[] Modelos; // Modelos atómicos
    public GameObject[] Pos;     // Posiciones donde se mostrarán los modelos
    private int contador = 0;    // Índice del modelo actual

    public float animationDuration = 0.5f; // Duración de la animación combinada (movimiento + escala)
    private Vector3 initialScale = Vector3.zero;
    private Vector3 targetScale = Vector3.one;

    void Start()
    {
        abrirAtom();
    }

    public void abrirAtom()
    {
        for (int i = 0; i < Modelos.Length; i++)
        {
            Modelos[i].transform.localScale = initialScale;
            Modelos[i].transform.position = Pos[0].transform.position;
            Modelos[i].SetActive(false);
        }

        // Activar el primer modelo en la posición correcta con animación
        Modelos[contador].SetActive(true);
        StartCoroutine(AnimarCambio(Modelos[contador], Pos[1].transform.position, true));
    }

    public void MoverDerecha()
    {
        StartCoroutine(CambiarModelo((contador + 1) % Modelos.Length, true));
    }

    public void MoverIzquierda()
    {
        StartCoroutine(CambiarModelo((contador - 1 + Modelos.Length) % Modelos.Length, false));
    }

    IEnumerator CambiarModelo(int nuevoIndice, bool derecha)
    {
        GameObject modeloActual = Modelos[contador];
        GameObject modeloNuevo = Modelos[nuevoIndice];

        // Animar salida del modelo actual (se mueve y se desvanece)
        yield return StartCoroutine(AnimarCambio(modeloActual, derecha ? Pos[2].transform.position : Pos[0].transform.position, false));
        modeloActual.SetActive(false);

        // Configurar modelo nuevo y animarlo hacia el centro
        modeloNuevo.SetActive(true);
        modeloNuevo.transform.position = derecha ? Pos[0].transform.position : Pos[2].transform.position;

        yield return StartCoroutine(AnimarCambio(modeloNuevo, Pos[1].transform.position, true));

        // Actualizar el índice
        contador = nuevoIndice;
    }

    IEnumerator AnimarCambio(GameObject modelo, Vector3 targetPos, bool apareciendo)
    {
        float elapsedTime = 0f;
        Vector3 startPos = modelo.transform.position;
        Vector3 startScale = apareciendo ? initialScale : targetScale;
        Vector3 endScale = apareciendo ? targetScale : initialScale;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;

            // Interpolación de movimiento
            modelo.transform.position = Vector3.Lerp(startPos, targetPos, t);

            // Interpolación de escala
            modelo.transform.localScale = Vector3.Lerp(startScale, endScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurar que el modelo termine en la posición y escala exacta
        modelo.transform.position = targetPos;
        modelo.transform.localScale = endScale;
    }
}


