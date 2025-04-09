using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Analizador : MonoBehaviour
{
    public InfoDatos infoDatos; // Referencia al script del átomo
    public GameObject sistemaParticulas; // Sistema de partículas para feedback visual
    private bool analisisCompleto = false;
    //public Button compararButton;



    [Header("Datos Fijos")]
    public TextMeshProUGUI InfoNombre;
    public TextMeshProUGUI SpaceGru;
    public TextMeshProUGUI X_Ray;
    public TextMeshProUGUI CellVol;
    public TextMeshProUGUI Density;
    public TextMeshProUGUI Max_Abs;
    public TextMeshProUGUI RIR;
    public TextMeshProUGUI[] barrasRef;

    [Header("Datos Ajustables")]
    public TextMeshProUGUI XRayJugador;
    public TextMeshProUGUI CellVolJugador;
    public TextMeshProUGUI DensityJugador;
    public TextMeshProUGUI Max_AbsJugador;
    public TextMeshProUGUI RIRJugador;
    public TextMeshProUGUI[] barrasJugador;

    [Header("Sliders")]
    public Slider sliderXRay;
    public Slider sliderCellVol;
    public Slider sliderDensity;
    public Slider sliderMaxAbs;
    public Slider sliderRIR;
    public Slider[] slidersBarras;
    public Slider[] listaSliders;
    public Slider publicSlider;

    [Header("Alertas")]
    public TextMeshProUGUI alerta; // Campo para mostrar mensajes

    int comprobarDato;

    private void Start()
    {
        ReiniciarValores();
    }
    public void RecibirSlider(int entero)
    {
       
        publicSlider = listaSliders[entero];
        comprobarDato = entero; Debug.Log(comprobarDato);
    }
    public void EstablecerSliders()
    {

        sliderXRay.onValueChanged.AddListener((v) => { XRayJugador.text = v.ToString("0.00"); });
        sliderXRay.maxValue = infoDatos.SMolecula.X_Ray * (Random.Range(1.5f, 2.5f));

        sliderCellVol.onValueChanged.AddListener((v) => { CellVolJugador.text = v.ToString("0.00"); });
        sliderCellVol.maxValue = infoDatos.SMolecula.CellVol * (Random.Range(1.5f, 2.5f));

        sliderDensity.onValueChanged.AddListener((v) => { DensityJugador.text = (v.ToString("0.00")); });
        sliderDensity.maxValue = infoDatos.SMolecula.Density * (Random.Range(1.5f, 2.5f));

        sliderMaxAbs.onValueChanged.AddListener((v) => { Max_AbsJugador.text = (v.ToString("0.00")); });
        sliderMaxAbs.maxValue = infoDatos.SMolecula.Max_Abs * (Random.Range(1.5f, 2.5f));

        sliderRIR.onValueChanged.AddListener((v) => { RIRJugador.text = (v.ToString("0.00")); });
        sliderRIR.maxValue = infoDatos.SMolecula.RIR * (Random.Range(1.5f, 2.5f));

        slidersBarras[0].onValueChanged.AddListener((v) => { barrasJugador[0].text = (v.ToString("0.00")); });
        slidersBarras[0].maxValue = infoDatos.SMolecula.CellPara[0] * (Random.Range(1.5f, 2.5f));

        slidersBarras[1].onValueChanged.AddListener((v) => { barrasJugador[1].text = (v.ToString("0.00")); });
        slidersBarras[1].maxValue = infoDatos.SMolecula.CellPara[1] * (Random.Range(1.5f, 2.5f));

        slidersBarras[2].onValueChanged.AddListener((v) => { barrasJugador[2].text = (v.ToString("0.00")); });
        slidersBarras[2].maxValue = infoDatos.SMolecula.CellPara[2] * (Random.Range(1.5f, 2.5f));

        slidersBarras[3].onValueChanged.AddListener((v) => { barrasJugador[3].text = (v.ToString("0.00")); });
        slidersBarras[3].maxValue = infoDatos.SMolecula.CellPara[3] * (Random.Range(1.5f, 2.5f));

        slidersBarras[4].onValueChanged.AddListener((v) => { barrasJugador[4].text = (v.ToString("0.00")); });
        slidersBarras[4].maxValue = infoDatos.SMolecula.CellPara[4] * (Random.Range(1.5f, 2.5f));

        slidersBarras[5].onValueChanged.AddListener((v) => { barrasJugador[5].text = (v.ToString("0.00")); });
        slidersBarras[5].maxValue = infoDatos.SMolecula.CellPara[5] * (Random.Range(1.5f, 2.5f));


        float tolerancia = 10f; // Rango de tolerancia para el ajuste automático

        sliderXRay.onValueChanged.AddListener((v) =>
        {
            XRayJugador.text = v.ToString("0.00");

            if (Mathf.Abs(v - infoDatos.SMolecula.X_Ray) <= tolerancia)
            {
                sliderXRay.value = infoDatos.SMolecula.X_Ray; // Ajustar al valor objetivo
                XRayJugador.text = sliderXRay.value.ToString("0.00");
            }

        });
        sliderXRay.maxValue = infoDatos.SMolecula.X_Ray * (Random.Range(1.5f, 3.0f));

        sliderCellVol.onValueChanged.AddListener((v) =>
        {
            CellVolJugador.text = v.ToString("0.00");

            if (Mathf.Abs(v - infoDatos.SMolecula.CellVol) <= tolerancia)
            {
                sliderCellVol.value = infoDatos.SMolecula.CellVol; // Ajustar al valor objetivo
                CellVolJugador.text = sliderCellVol.value.ToString("0.00");
            }

        });
        sliderCellVol.maxValue = infoDatos.SMolecula.CellVol * (Random.Range(1.5f, 3.0f));

        sliderDensity.onValueChanged.AddListener((v) =>
        {
            DensityJugador.text = v.ToString("0.00");
            if (Mathf.Abs(v - infoDatos.SMolecula.Density) <= tolerancia)
            {
                sliderDensity.value = infoDatos.SMolecula.Density; // Ajustar al valor objetivo
                DensityJugador.text = sliderDensity.value.ToString("0.00");
            }

        });
        sliderDensity.maxValue = infoDatos.SMolecula.Density * (Random.Range(1.5f, 3.0f));

        sliderMaxAbs.onValueChanged.AddListener((v) =>
        {
            Max_AbsJugador.text = v.ToString("0.00");
            if (Mathf.Abs(v - infoDatos.SMolecula.Max_Abs) <= tolerancia)
            {
                sliderMaxAbs.value = infoDatos.SMolecula.Max_Abs; // Ajustar al valor objetivo
                Max_AbsJugador.text = sliderMaxAbs.value.ToString("0.00");
            }

        });
        sliderMaxAbs.maxValue = infoDatos.SMolecula.Max_Abs * (Random.Range(1.5f, 3.0f));

        sliderRIR.onValueChanged.AddListener((v) =>
        {
            RIRJugador.text = v.ToString("0.00");
            if (Mathf.Abs(v - infoDatos.SMolecula.RIR) <= tolerancia)
            {
                sliderRIR.value = infoDatos.SMolecula.RIR; // Ajustar al valor objetivo
                RIRJugador.text = sliderRIR.value.ToString("0.00");
            }

        });
        sliderRIR.maxValue = infoDatos.SMolecula.RIR * (Random.Range(1.5f, 3.0f));

        for (int i = 0; i < slidersBarras.Length; i++)
        {
            int index = i; // Capturar el índice actual para la clausura
            slidersBarras[index].onValueChanged.AddListener((v) =>
            {
                barrasJugador[index].text = v.ToString("0.00");
                if (Mathf.Abs(v - infoDatos.SMolecula.CellPara[index]) <= tolerancia)
                {
                    slidersBarras[index].value = infoDatos.SMolecula.CellPara[index]; // Ajustar al valor objetivo
                    barrasJugador[index].text = slidersBarras[index].value.ToString("0.00");
                }

            });
            slidersBarras[index].maxValue = infoDatos.SMolecula.CellPara[index] * (Random.Range(1.5f, 3.0f));
        }

    }

    public void IniciarAnalisis(InfoDatos atomoInfo)
    {
        infoDatos = atomoInfo; // Guardar referencia al script InfoDatos del objeto detectado

        // Cargar valores de referencia desde el InfoDatos del objeto
        X_Ray.text = infoDatos.SMolecula.X_Ray.ToString("F2");
        CellVol.text = infoDatos.SMolecula.CellVol.ToString("F2");
        Density.text = infoDatos.SMolecula.Density.ToString("F2");
        Max_Abs.text = infoDatos.SMolecula.Max_Abs.ToString("F2");
        RIR.text = infoDatos.SMolecula.RIR.ToString("F2");

        // Mostrar SpaceGru como referencia fija
        SpaceGru.text = infoDatos.SMolecula.SpaceGru;

        for (int i = 0; i < barrasRef.Length; i++)
        {
            barrasRef[i].text = infoDatos.SMolecula.CellPara[i].ToString("F2");
        }

        // Reiniciar valores ajustables del jugador
        ReiniciarValores();
        analisisCompleto = false;
    }

    private void ReiniciarValores()
    {
        sliderXRay.value = 0f;
        sliderDensity.value = 0f;
        sliderCellVol.value = 0f;
        sliderMaxAbs.value = 0f;
        sliderRIR.value = 0f;

        foreach (var slider in slidersBarras)
        {
            slider.value = 0f;
        }

        XRayJugador.text = "0.00";
        CellVolJugador.text = "0.00";
        DensityJugador.text = "0.00";
        Max_AbsJugador.text = "0.00";
        RIRJugador.text = "0.00";
        InfoNombre.text = "Esperando datos";
        alerta.text = "";


        for (int i = 0; i < barrasJugador.Length; i++)
        {
            barrasJugador[i].text = "0.00";
        }
    }

    // Métodos para actualizar los valores del jugador


  

    public void CompararValores()
    {
        switch (comprobarDato)
        {
            case 0:
                if (barrasRef[comprobarDato].text == barrasJugador[comprobarDato].text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Barra 1", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Barra 1 no coinciden..", Color.red));
                }
                break;
            case 1:
                if (barrasRef[comprobarDato].text == barrasJugador[comprobarDato].text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Barra 2", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Barra 2 no coinciden..", Color.red));
                }

                break;
            case 2:
                if (barrasRef[comprobarDato].text == barrasJugador[comprobarDato].text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Barra 3", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Barra 3 no coinciden..", Color.red));
                }

                break;
            case 3:
                if (barrasRef[comprobarDato].text == barrasJugador[comprobarDato].text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Barra 4", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Barra 4 no coinciden..", Color.red));
                }

                break;

            case 4:
                if (barrasRef[comprobarDato].text == barrasJugador[comprobarDato].text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Barra 5", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Barra 5 no coinciden...", Color.red));
                }

                break;
            case 5:
                if (barrasRef[comprobarDato].text == barrasJugador[comprobarDato].text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Barra 6", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Barra 6 no coinciden..", Color.red));
                }

                break;
            case 6:
                // Comparar los textos de X_Ray y XRayJugador
                if (X_Ray.text == XRayJugador.text)
                {
                    StartCoroutine(MostrarMensaje(" Valores correctos de X_Ray ", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de X_Ray no coinciden.", Color.red));
                }

                break;
            case 7:
                // Comparar los textos de CellVol y CellVolJugador
                if (CellVol.text == CellVolJugador.text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de CellVol", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de CellVol no coinciden.", Color.red));
                }

                break;
            case 8:
                // Comparar los textos de Density y DensityJugador
                if (Density.text == DensityJugador.text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Density", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Density no coinciden.", Color.red));
                }

                break;
            case 9:
                // Comparar los textos de Max_Abs y Max_AbsJugador
                if (Max_Abs.text == Max_AbsJugador.text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de Max_Abs", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de Max_Abs no coinciden.", Color.red));
                }

                break;
            case 10:
                // Comparar los textos de RIR y RIRJugador
                if (RIR.text == RIRJugador.text)
                {
                    StartCoroutine(MostrarMensaje("Valores correctos de RIR", Color.green));
                }
                else
                {
                    StartCoroutine(MostrarMensaje("Los valores de RIR no coinciden.", Color.red));
                }
                break;



        }

    }
    // Corutina para mostrar y ocultar mensajes
    private IEnumerator MostrarMensaje(string mensaje, Color color)
    {
        alerta.text = mensaje;
        alerta.color = color;
        alerta.gameObject.SetActive(true); // Mostrar el mensaje
        yield return new WaitForSeconds(6); // Esperar 6 segundos
        alerta.gameObject.SetActive(false); // Ocultar el mensaje
    }

    public void VerificarTodosLosSliders()
    {
        bool todosCorrectos = true; // Bandera para determinar si todos los sliders están correctos

        // Verificar los sliders ajustables principales
        if (sliderXRay.value.ToString("0.00") != infoDatos.SMolecula.X_Ray.ToString("0.00"))
            todosCorrectos = false;

        if (sliderCellVol.value.ToString("0.00") != infoDatos.SMolecula.CellVol.ToString("0.00"))
            todosCorrectos = false;

        if (sliderDensity.value.ToString("0.00") != infoDatos.SMolecula.Density.ToString("0.00"))
            todosCorrectos = false;

        if (sliderMaxAbs.value.ToString("0.00") != infoDatos.SMolecula.Max_Abs.ToString("0.00"))
            todosCorrectos = false;

        if (sliderRIR.value.ToString("0.00") != infoDatos.SMolecula.RIR.ToString("0.00"))
            todosCorrectos = false;

        // Verificar las barras de referencia
        for (int i = 0; i < slidersBarras.Length; i++)
        {
            if (slidersBarras[i].value.ToString("0.00") != infoDatos.SMolecula.CellPara[i].ToString("0.00"))
            {
                todosCorrectos = false;
                break;
            }
        }

        // Mostrar mensaje según el estado de todos los sliders
        if (todosCorrectos)
        {
            StartCoroutine(MostrarMensaje("Todos los valores son correctos.", Color.green));
            infoDatos.informacionCompleta = true;
            infoDatos.Iniciacion();
            InfoNombre.text = infoDatos.InfoNombre.text;
        }
        else
        {
            StartCoroutine(MostrarMensaje("Algunos valores no coinciden.", Color.red));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar el objeto que entra en el trigger y verificar si tiene InfoDatos
        InfoDatos atomoInfo = other.GetComponent<InfoDatos>();

        if (atomoInfo != null && atomoInfo.DrxListo) // modificar despues 
        {
            Debug.Log("Átomo detectado: " + atomoInfo.SMolecula.nombreAtomo);
            IniciarAnalisis(atomoInfo);
            EstablecerSliders();

        }
        else
        {
            Debug.Log("El objeto no contiene datos de un átomo válido.");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Detectar si el objeto que sale tiene InfoDatos
        InfoDatos atomoInfo = other.GetComponent<InfoDatos>();

        // Si es el objeto actualmente analizado, reiniciar los valores
        if (atomoInfo != null && atomoInfo == infoDatos)
        {
            Debug.Log("El átomo ha salido del área de análisis: " + atomoInfo.SMolecula.nombreAtomo);

            // Reiniciar los valores ajustables
            ReiniciarValores();

            // Reiniciar los valores estáticos
            ReiniciarValoresEstaticos();

            // Eliminar la referencia al átomo analizado
            infoDatos = null;
        }
    }

    // Método para reiniciar los valores estáticos (Info Estática 1)
    private void ReiniciarValoresEstaticos()
    {
        // Reiniciar los textos de las propiedades estáticas a valores predeterminados o vacíos
        X_Ray.text = "0.00";
        CellVol.text = "0.00";
        Density.text = "0.00";
        Max_Abs.text = "0.00";
        RIR.text = "0.00";
        SpaceGru.text = "N/A"; // Si es un texto no numérico, establecer un valor neutral

        // Reiniciar las barras de referencia
        foreach (var barra in barrasRef)
        {
            barra.text = "0.00";
        }
    }



}