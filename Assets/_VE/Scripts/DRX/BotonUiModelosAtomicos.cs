using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonUiModelosAtomicos : MonoBehaviour
{
    public Animator animator; // Referencia al Animator
   
    private bool isPlayingFirstAnimation = true; // Controla qué animación se activa

    public void ToggleAnimation()
    {
        if (animator == null) return;

        if (isPlayingFirstAnimation)
        {
            animator.SetBool("Entro", true);
        }
        else
        {
            animator.SetBool("Entro", false);
        }

        isPlayingFirstAnimation = !isPlayingFirstAnimation; // Alternar estado
    }
}
