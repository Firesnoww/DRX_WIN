using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoActivo : MonoBehaviour
{
    public Animator anim;
    public bool almacen;
    public AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player")
        {
            if (almacen)
            {
                anim.SetBool("Entro", true);
                audioManager.PlayEfect(2);

            }
            else 
            {
                anim.SetBool("Entro", true);
                audioManager.PlayEfect(4);
            }
        }
            
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (almacen)
            {
                anim.SetBool("Entro", false);
                audioManager.PlayEfect(1);

            }
            else
            {
                anim.SetBool("Entro", false);
                StartCoroutine(playSonidoCerrar());
            }
           

        }     
    }

    public IEnumerator playSonidoCerrar() 
    {
        audioManager.StopEfect();
        yield return new WaitForSeconds(2.1f);
        audioManager.PlayEfect(5);
    }

}
