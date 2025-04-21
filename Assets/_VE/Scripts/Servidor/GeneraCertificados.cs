using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class GeneraCertificados : MonoBehaviour
{
    public string[] campos;
    public List<string> valores = new List<string>();
    public string URL;

    public TextMeshProUGUI correoUsuario;
    [ContextMenu("Generar Certificado")]
    public void GenerarCertificado()
    {
        AudioManager.Instance.PlayEfect(0);
        valores.Add(PersonajeBD.instance.usuario.nombre);
        valores.Add(PersonajeBD.instance.usuario.id_usuario);
        valores.Add(DateTime.Now.Year.ToString());
        valores.Add(PersonajeBD.instance.usuario.programa);
        valores.Add(PersonajeBD.instance.usuario.usuario + "@pascualbravo.edu.co");

        StartCoroutine(EnviarFormulario());
    }

    IEnumerator EnviarFormulario()
    {

        WWWForm form = new WWWForm();
        for (int i = 0; i < campos.Length; i++)
        {
            form.AddField(campos[i], valores[i]);
        }
        using UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            correoUsuario.text = PersonajeBD.instance.usuario.usuario + "@pascualbravo.edu.co";
            Debug.Log("Enviado con exito!");
        }

    }
}
