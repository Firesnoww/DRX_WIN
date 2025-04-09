using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using VHierarchy.Libs;

public class Almacen_Atomos : MonoBehaviour
{

    public List<GameObject> atoms = new List<GameObject>();
    public GameObject objInst;
    public string nombres;
    public GameObject BotonesG;
    public GameObject posisionI;
    public GameObject poSalida;
    public AudioManager audioManager;
    

    // Start is called before the first frame update

    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar el objeto que entra en el trigger y verificar si tiene InfoDatos
        InfoDatos atomoInfo = other.GetComponent<InfoDatos>();

        if (atomoInfo != null)
        {   // El atomo entra y se guarda
            atoms.Add(other.gameObject);
            Debug.Log("Átomo detectado: " + atomoInfo.SMolecula.nombreAtomo);
            other.gameObject.SetActive(false);
            other.transform.position = gameObject.transform.position;

            //Inicia la instanciasion del boton dentro del canvas

            GameObject temporal  = Instantiate(BotonesG, posisionI.transform);
            Button b = temporal.GetComponent<Button>();
            b.onClick.AddListener(() => EliminarEste(other.gameObject,temporal));
            TextMeshProUGUI n = temporal.GetComponentInChildren<TextMeshProUGUI>();
            n.text = ("falta analicis");
            b.onClick.AddListener(() => aggSonido(0));
        }
        else
        {
            Debug.Log("Falta Análisis.");
        }
    }
    public void EliminarEste(GameObject game,GameObject boton)
    {
        print("eliminar esta on");
        if (atoms.Contains(game))
        {   
            game.transform.position = poSalida.transform.position;
            game.SetActive(true);
            atoms.Remove(game);    
            Debug.Log($"Objeto '{game}' eliminado de la lista.");
            Destroy(boton);
        }
        else
        {
            Debug.Log($"El objeto '{game}' no se encuentra en la lista.");
        }
    }

    public void aggSonido(int b) 
    {
        audioManager.PlayEfect(b);
    }
}
