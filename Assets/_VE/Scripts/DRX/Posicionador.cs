using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Posicionador : MonoBehaviour
{
    public GameObject posI;
    public bool drx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (drx)
        {
            // Detectar el objeto que entra en el trigger y verificar si tiene InfoDatos
            InfoDatos atomoInfo = other.GetComponent<InfoDatos>();
            if (other.tag == "Recipiente" && atomoInfo.DrxListo == false)
            {
                other.transform.position = posI.transform.position;
                Debug.Log("cambio de poss");
            }
            else
            {
                Debug.Log("no cambio de poss");
            }

        }else
        {
            // Detectar el objeto que entra en el trigger y verificar si tiene InfoDatos
            InfoDatos atomoInfo = other.GetComponent<InfoDatos>();
            if (other.tag == "Recipiente" && atomoInfo.DrxListo == atomoInfo.informacionCompleta == false )
            {
                other.transform.position = posI.transform.position;
                Debug.Log("cambio de poss");
            }
            else
            {
                Debug.Log("no cambio de poss");
            }
        }
    } 
}
