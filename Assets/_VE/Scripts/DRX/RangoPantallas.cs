using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RangoPantallas : MonoBehaviour
{
    public ParticleSystem[] particulas; // Array de sistemas de part�culas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recipiente"))
        {
            foreach (ParticleSystem ps in particulas)
            {
                var mainModule = ps.main;
                mainModule.loop = true; // Activar loop
                ps.Play(); // Reproducir part�culas
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Recipiente"))
        {
            foreach (ParticleSystem ps in particulas)
            {
                var mainModule = ps.main;
                mainModule.loop = false; // Desactivar loop
            }
        }
    }
}
