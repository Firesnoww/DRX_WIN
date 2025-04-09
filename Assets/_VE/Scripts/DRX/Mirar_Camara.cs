using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirar_Camara : MonoBehaviour
{
    public bool mirarX;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (mirarX)
        {
            transform.forward = Camera.main.transform.forward;
           
        }
        else
        {
            transform.up = Camera.main.transform.up;
        }
       
    }
}
