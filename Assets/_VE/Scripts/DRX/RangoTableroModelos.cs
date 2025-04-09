using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoTableroModelos : MonoBehaviour
{
    public Animator anim;
    public Material mat; // Material del objeto
    public Color colorOnEnter = Color.red; // Color al entrar
    public Color colorOnExit = Color.white; // Color al salir
    public float transitionDuration = 1.0f; // Duración de la transición
    public AudioManager audioManager;

    private Coroutine colorChangeCoroutine; // Guarda la transición en proceso

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && mat != null) // Compara con el tag "Player"
        {
            anim.SetBool("Entro", true);
            audioManager.PlayEfect(2);
            if (colorChangeCoroutine != null)
                StopCoroutine(colorChangeCoroutine); // Detiene la transición anterior si existía
            colorChangeCoroutine = StartCoroutine(ChangeColorOverTime(mat, colorOnEnter));
        }

    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player") && mat != null)
        {
            anim.SetBool("Entro", false);
            audioManager.PlayEfect(1);
            if (colorChangeCoroutine != null)
                StopCoroutine(colorChangeCoroutine);
            colorChangeCoroutine = StartCoroutine(ChangeColorOverTime(mat, colorOnExit));
        }
    }

    private IEnumerator ChangeColorOverTime(Material material, Color targetColor)
    {
        Color startColor = material.color; // Obtiene el color actual
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            material.color = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        material.color = targetColor; // Asegura que el color final sea exacto
    }
}
