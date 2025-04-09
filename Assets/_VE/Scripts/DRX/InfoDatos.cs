using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class InfoDatos : MonoBehaviour
{
    public ScriptableMolecula SMolecula;
    public GameObject ObjMain;
    public GameObject Recipiente;
    public GameObject canvasBase;
    private GameObject objetoInstanciado;
    public bool rotar;
    public Rigidbody rig;
    public bool forzarKinematic;
    public bool boton = false;
    public Animator anim;
    public Animator animInterfaz;
    public ParticleSystem party;

    // Variables para el an�lisis en la plataforma
    public float analisisTiempo = 3.6f; // Tiempo en segundos necesario para iniciar el an�lisis
    public float tiempoEnPlataforma = 3.6f; // Contador de tiempo en la plataforma
    private bool enPlataforma = false; // Bandera para verificar si est� en la plataforma
    public bool analisisIniciado = false; // Bandera para asegurar que el an�lisis solo se inicie una vez
    public bool DrxListo = false;
    public bool informacionCompleta = true; // Bandera para verificar si se ha revelado el nombre y detalles

    float[] datosGrafica;

    public TextMeshProUGUI InfoNombre;
    public TextMeshProUGUI InfoAtomo;
    public TextMeshProUGUI SpaceGru;
    public TextMeshProUGUI X_Ray;
    public TextMeshProUGUI CellVol;
    public TextMeshProUGUI Density;
    public TextMeshProUGUI Max_Abs;
    public TextMeshProUGUI RIR;
    

    [Header("Infos")]
    public TextMeshProUGUI[] barrasT;

    private void Start()
    {
        party.Stop();
        rig = GetComponent<Rigidbody>(); 
        ToggleChildren(false); // Apagar todos los objetos hijos al inicio
        rig.useGravity = true;
        rig.isKinematic = false;
        Recipiente.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (enPlataforma && !analisisIniciado && !DrxListo)
        {
            // Aumenta el contador de tiempo mientras el objeto est� en la plataforma
            tiempoEnPlataforma += Time.deltaTime;
            // Verifica si el tiempo en la plataforma ha alcanzado el tiempo necesario
            if (tiempoEnPlataforma >= analisisTiempo)
            {
                Iniciacion(); // Inicia el an�lisis
                rig.useGravity = false;
                rig.isKinematic = true;
                ForzarKinematic();
                analisisIniciado = true; // Marca que el an�lisis se ha iniciado
            }
        }
        if (!rig.isKinematic && forzarKinematic)
        {
            rig.isKinematic = true;
        }
    }

    public void ForzarKinematic()
    {
        forzarKinematic = true;
    }
    public void Iniciacion()
    {
        objetoInstanciado = Instantiate(SMolecula.atomoPrefab, this.transform.position, this.transform.rotation, this.transform);

        // Si la informaci�n completa a�n no se ha revelado, muestra el mensaje "falta an�lisis"
        if (!informacionCompleta)
        {   
               
            InfoNombre.text = "Falta analisis";
            InfoNombre.color =  new Color(255,0,0,255); 
            
            InfoAtomo.text = "Falta analisis";
            InfoAtomo.color =  new Color(255,0,0,255);
        }
        else
        {
            // Mostrar informaci�n completa
            InfoNombre.text = SMolecula.nombreAtomo;
            InfoNombre.color =  new Color(122,255,73,255);

            InfoAtomo.text = SMolecula.infoAtomo;
            InfoAtomo.color =  new Color(122,255,73,255);  
        }

        // Resto de los datos que siempre se muestran
        datosGrafica = new float[SMolecula.CellPara.Length];
        SpaceGru.text = SMolecula.SpaceGru;
        X_Ray.text = SMolecula.X_Ray.ToString();
        CellVol.text = SMolecula.CellVol.ToString();
        Density.text = SMolecula.Density.ToString();
        Max_Abs.text = SMolecula.Max_Abs.ToString();
        RIR.text = SMolecula.RIR.ToString();

        for (int i = 0; i < SMolecula.CellPara.Length; i++)
        {
            datosGrafica[i] = SMolecula.CellPara[i];
            barrasT[i].text = SMolecula.CellPara[i].ToString();
        }

        name = name + (" ") + SMolecula.nombreAtomo;

        // Encender todos los objetos hijos despu�s del an�lisis
        ToggleChildren(true);
        DrxListo = true;
        Recipiente.gameObject.SetActive(false);
    }

    // M�todo para encender o apagar todos los objetos hijos
    private void ToggleChildren(bool state)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(state);

        }
    }

    // M�todo que detecta cuando el objeto entra en el trigger de la plataforma
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DRX"))
        {
            enPlataforma = true;
            tiempoEnPlataforma = 0.0f; // Reinicia el contador cuando el objeto entra en la plataforma
        }
    }

    // M�todo que detecta cuando el objeto sale del trigger de la plataforma
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DRX"))
        {
            enPlataforma = false;
            tiempoEnPlataforma = 0.0f; // Reinicia el contador cuando el objeto sale de la plataforma
            analisisIniciado = false; // Permite reiniciar el an�lisis si el objeto vuelve a la plataforma
        }
    }

    // M�todo para revelar la informaci�n completa cuando se descubren los valores correctos
    public void RevelarInformacion()
    {
        informacionCompleta = true;
        Iniciacion(); // Actualizar la informaci�n para mostrar el nombre y los detalles completos
    }

    public void ActivarInfo()
    {
        if (boton) 
        {
           
            boton = false;
            anim.SetBool("Encender", false);
            animInterfaz.SetBool("Interfaz", false);
        }
        else
        {
            party.Play();
            boton = true;
            anim.SetBool("Encender", true);
            animInterfaz.SetBool("Interfaz", true);
        }
        
    }

}