using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MostrarPassword : MonoBehaviour
{
    public TMP_InputField passwordInput; // Asigna aqu� tu TMP_InputField de contrase�a
    public Toggle toggle; // Asigna aqu� un Toggle o bot�n

    private string passwordOculto; // Para almacenar el password temporalmente

    void Start()
    {
        // Asegurarse de que el toggle est� desactivado al inicio
        if (toggle != null)
        {
            toggle.isOn = false;
            toggle.onValueChanged.AddListener(delegate { TogglePassword(); });
        }
    }

    public void TogglePassword()
    {
        AudioManager.Instance.PlayEfect(1);
        if (toggle.isOn)
        {
            // Mostrar la contrase�a real
            passwordOculto = passwordInput.text;
            passwordInput.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            // Ocultar la contrase�a con asteriscos
            passwordInput.contentType = TMP_InputField.ContentType.Password;
        }

        // Refrescar el campo de entrada
        passwordInput.ForceLabelUpdate();
    }
}
