using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DRX : MonoBehaviour
{
    public GameObject Col;
    public ParticleSystem Particle;
    public AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
     Col.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Recipiente")
        {   
            InfoDatos info = other.GetComponent<InfoDatos>();
            if (info.DrxListo == false)
            {
                Debug.Log("entro");
                audioManager.PlayEfect(2);
                Col.SetActive(true);
                Particle.Play();

            } 
            //StartCoroutine(Proceso());               
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Recipiente")
        {
                                                                        
            Debug.Log("salio");
            audioManager.StopEfect();
            Col.SetActive(false);
            Particle.Stop();

        }
    }

    public IEnumerator Proceso() 
    {
       
        yield return null;
    }
}
