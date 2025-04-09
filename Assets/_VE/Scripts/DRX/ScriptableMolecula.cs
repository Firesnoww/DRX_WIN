using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atomo_", menuName = "DRX/InfoAtomo")]
public class ScriptableMolecula : ScriptableObject
{

    public Color ColorBase;
    public GameObject atomoPrefab; // El GameObject que representará el átomo
    public string nombreAtomo; // El nombre del átomo
    [TextArea(minLines: 1, maxLines: 5)]
    public string infoAtomo; // Informacion basica sobre el atomo (fecha de i
    [Header("Parametros")]
    public float[] CellPara = new float[6] ; // La Informacion delas graficas 
    public string SpaceGru;
    public float X_Ray;
    public float CellVol;
    public float Density;
    public float Max_Abs;
    public float RIR;


}