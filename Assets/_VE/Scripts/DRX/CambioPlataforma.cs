using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CambioPlataforma : MonoBehaviour
{

    public Plataforma plataforma;

    [Header("Plataformas")]

    public int Estado;

    public GameObject[] Interfaz_Android_PC;
    public GameObject[] InterfazVr;

    // Start is called before the first frame update
    void Start()
    {
        if (plataforma == Plataforma.VR)
        {
            Estado = 1;
        }
        else
        {
            Estado = 0;
        }
      
        Retifircar();

    }

    // Update is called once per frame

    public void Retifircar()
    {

        if ((plataforma == Plataforma.VR)){ cambio_Android_PC(); }
        else { cambioVr(); }
    }

    public void cambio_Android_PC()
    {
        for (int i = 0; i < Interfaz_Android_PC.Length; i++)
        {
            Interfaz_Android_PC[i].SetActive(true);
        }
        for (int i = 0; i < InterfazVr.Length; i++)
        {
            InterfazVr[i].SetActive(false);
        }

        Debug.Log("Androir On");
    }
    public void cambioVr()
    {
        for (int i = 0; i < InterfazVr.Length; i++)
        {
            InterfazVr[i].SetActive(true);
        }
        for (int i = 0; i < Interfaz_Android_PC.Length; i++)
        {
            Interfaz_Android_PC[i].SetActive(false);
        }

        Debug.Log("Vr On");
    }

    [Header("-------------------UI Analizador de Datos-------------------")]
    [Header("----------------Datos Fijos Menus")]
    public TextMeshProUGUI[] InfoNombre;
    public TextMeshProUGUI[] SpaceGru;
    public TextMeshProUGUI[] X_Ray;
    public TextMeshProUGUI[] CellVol;
    public TextMeshProUGUI[] Density;
    public TextMeshProUGUI[] Max_Abs;
    public TextMeshProUGUI[] RIR;

    [Header("----------------Barras Fijas Menus")]
    public TextMeshProUGUI[] barrasRef_Android_PC;
    public TextMeshProUGUI[] barrasRef_Vr;

    [Header("----------------Datos Ajustables Menus")]
    public TextMeshProUGUI[] XRayJugador;
    public TextMeshProUGUI[] CellVolJugador;
    public TextMeshProUGUI[] DensityJugador;
    public TextMeshProUGUI[] Max_AbsJugador;
    public TextMeshProUGUI[] RIRJugador;

    [Header("----------------Barras Datos Ajustables Menus")]
    public TextMeshProUGUI[] barrasJugador_Android_Pc;
    public TextMeshProUGUI[] barrasJugador_Vr;

    [Header("----------------Sliders Jugador")]
    public Slider[] sliderXRay;
    public Slider[] sliderCellVol;
    public Slider[] sliderDensity;
    public Slider[] sliderMaxAbs;
    public Slider[] sliderRIR;

    [Header("----------------Barras Sliders Jugador")]
    public Slider[] slidersBarras_Android_Pc;
    public Slider[] slidersBarras_Vr;


    //public void Start()
    //{

    //    //---------------------------- Datos Fijos --------------------------
    //    InfoNombre = Cambio.InfoNombre[Cambio.Estado];
    //    SpaceGru = Cambio.SpaceGru[Cambio.Estado];
    //    X_Ray = Cambio.X_Ray[Cambio.Estado];
    //    CellVol = Cambio.CellVol[Cambio.Estado];
    //    Density = Cambio.Density[Cambio.Estado];
    //    Max_Abs = Cambio.Max_Abs[Cambio.Estado];
    //    RIR = Cambio.RIR[Cambio.Estado];

    //    //-------------------------- Datos del Jugador -------------------------
    //    XRayJugador = Cambio.XRayJugador[Cambio.Estado];
    //    CellVolJugador = Cambio.CellVolJugador[Cambio.Estado];
    //    DensityJugador = Cambio.DensityJugador[Cambio.Estado];
    //    Max_AbsJugador = Cambio.Max_AbsJugador[Cambio.Estado];
    //    RIRJugador = Cambio.RIRJugador[Cambio.Estado];


    //    //------------------------------ Sliders --------------------------------

    //    sliderXRay = Cambio.sliderXRay[Cambio.Estado];
    //    sliderCellVol = Cambio.sliderCellVol[Cambio.Estado];
    //    sliderDensity = Cambio.sliderDensity[Cambio.Estado];
    //    sliderMaxAbs = Cambio.sliderMaxAbs[Cambio.Estado];
    //    sliderRIR = Cambio.sliderRIR[Cambio.Estado];


    //    if (Cambio.Estado == 0)
    //    {   //---------------------------- Datos Fijos --------------------------
    //        for (int i = 0; i < barrasRef.Length; i++)
    //        {
    //            barrasRef[i] = Cambio.barrasRef_Android_PC[i];
    //        }
    //        //-------------------------- Datos del Jugador -------------------------
    //        for (int i = 0; i < barrasJugador.Length; i++)
    //        {
    //            barrasJugador[i] = Cambio.barrasJugador_Android_Pc[i];
    //        }
    //        //------------------------------ Sliders --------------------------------
    //        for (int i = 0; i < slidersBarras.Length; i++)
    //        {
    //            slidersBarras[i] = Cambio.slidersBarras_Android_Pc[i];
    //        }
    //    }
    //    if (Cambio.Estado == 1)
    //    {//---------------------------- Datos Fijos --------------------------
    //        for (int i = 0; i < barrasRef.Length; i++)
    //        {
    //            barrasRef[i] = Cambio.barrasRef_Vr[i];
    //        }
    //        //-------------------------- Datos del Jugador -------------------------
    //        for (int i = 0; i < barrasJugador.Length; i++)
    //        {
    //            barrasJugador[i] = Cambio.barrasRef_Vr[i];
    //        }
    //        //------------------------------ Sliders --------------------------------
    //        for (int i = 0; i < slidersBarras.Length; i++)
    //        {
    //            slidersBarras[i] = Cambio.slidersBarras_Android_Pc[i];
    //        }
    //    }
    //}
}
