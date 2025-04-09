
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teclado : MonoBehaviour
{
    public TMP_InputField usuarioInput;  // Input para el usuario
    public TMP_InputField passwordInput;  // Input para la contrase�a
    public List<TMP_Text> botonesTexto;  // Lista de los textos de los botones                                     

    // Listas con los valores que alternar�n (debes llenar esto en el inspector o en Start)
    public List<TMP_Text> botonesNumericos;
    private List<string> numeros = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    private List<string> simbolos = new List<string>() { "?", "�", "%", "&", "$", "!", "�", "(", ")", "=" };
    

    private TMP_InputField inputActivo;  // Referencia al input activo
    private bool mayusculaActiva;
    private bool simbolosActivos; // Controla si estamos mostrando s�mbolos o n�meros

    void Start()
    {
        inputActivo = usuarioInput; // Iniciar con el campo de usuario
    }

    // M�todo para seleccionar el campo activo
    public void ActivarInput(TMP_InputField input)
    {
        inputActivo = input;
    }

    // M�todo para insertar caracteres, invocado desde cada boton del canvas teclado
    public void InsertarCaracter(TMP_Text textoBoton)
    {
        if (inputActivo != null)
        {
            string caracter = textoBoton.text;
            //AudioManager.Instance.PlayEfect(0);
            if (mayusculaActiva)
            {
                inputActivo.text += caracter.ToUpper();
            }
            else
            {
                inputActivo.text += caracter;
            }
        }
    }

    // M�todo para borrar un car�cter
    public void BorrarCaracter()
    {
        if (inputActivo != null && inputActivo.text.Length > 0)
        {
            AudioManager.Instance.PlayEfect(1);
            inputActivo.text = inputActivo.text.Substring(0, inputActivo.text.Length - 1);
        }
    }

    public void ActivarDesactivarMayuscula()
    {
        AudioManager.Instance.PlayEfect(0);
        mayusculaActiva = !mayusculaActiva;
        ActualizarBotones();
    }

    // M�todo para actualizar los botones
    private void ActualizarBotones()
    {
        foreach (TMP_Text boton in botonesTexto)
        {
            boton.text = mayusculaActiva ? boton.text.ToUpper() : boton.text.ToLower();
        }
    }

    public void AlternarNumerosSimbolos()
    {
        simbolosActivos = !simbolosActivos;
        //AudioManager.Instance.PlayEfect(0);

        for (int i = 0; i < botonesNumericos.Count && i < numeros.Count; i++)
        {
            string nuevoTexto = simbolosActivos ? simbolos[i] : numeros[i];
            botonesNumericos[i].text = nuevoTexto;
        }
    }
}
