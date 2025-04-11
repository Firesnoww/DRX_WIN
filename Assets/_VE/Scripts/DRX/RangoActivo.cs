using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoActivo : MonoBehaviour
{
    public Animator anim;
    public bool almacen;
    public AudioManager audioManager;
    public Material Fresnel;

    private bool isHovered = false;
    private bool isSelected = false;

    void Start() { }

    void Update()
    {
        // Detecta si el mouse está sobre este objeto
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                if (!isHovered && !isSelected)
                {
                    isHovered = true;
                    StartCoroutine(Fade(Fresnel, 0f, 2f, 0.5f)); // Fade In
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (!isSelected)
                    {
                        ActivarObjeto(); // Lo que estaba en OnTriggerEnter
                    }
                }
            }
            else if (isHovered && !isSelected)
            {
                isHovered = false;
                StartCoroutine(Fade(Fresnel, 2f, 0f, 0.5f)); // Fade Out
            }
        }
        else if (isHovered && !isSelected)
        {
            isHovered = false;
            StartCoroutine(Fade(Fresnel, 2f, 0f, 0.5f)); // Fade Out
        }
    }

    public void ActivarObjeto()
    {
        isSelected = true;
        isHovered = false;

        StartCoroutine(Fade(Fresnel, 2f, 0f, 0.5f)); // Fade Out (se apaga porque está seleccionado)

        anim.SetBool("Entro", true);
        audioManager.PlayEfect(almacen ? 2 : 4);
    }

    public void DesactivarObjeto()
    {
        isSelected = false;
        anim.SetBool("Entro", false);

        if (almacen)
        {
            audioManager.PlayEfect(1);
        }
        else
        {
            StartCoroutine(playSonidoCerrar());
        }

        StartCoroutine(Fade(Fresnel, 0f, 2f, 0.5f)); // Fade In
    }

    public IEnumerator playSonidoCerrar()
    {
        audioManager.StopEfect();
        yield return new WaitForSeconds(2.1f);
        audioManager.PlayEfect(5);
    }

    IEnumerator Fade(Material mat, float from, float to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float value = Mathf.Lerp(from, to, elapsed / duration);
            mat.SetFloat("_Opacidad", value);
            elapsed += Time.deltaTime;
            yield return null;
        }
        mat.SetFloat("_Opacidad", to); // Valor final asegurado
    }
}

