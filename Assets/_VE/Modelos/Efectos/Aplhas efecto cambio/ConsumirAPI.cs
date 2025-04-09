using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


/// <summary>
/// Utilizada para consumir una API, en este caso la api de SICAU para validar los usuarios activos en el periodo
/// </summary>
public class ConsumirAPI : MonoBehaviour
{
    // Solicitamos una referencia a los InputField del login
    public TMP_InputField inputUsuario;
    public TMP_InputField inputPassword;
    public GameObject imgCarga;  // Asignar desde el Inspector

    // Variable para almacenar los datos del usuario
    public EnvioDatosBD envioDatosBD;

    // Establecemos las variables, con los datos de la url a consumir y su llave de autenticacion
    private string apiUrl = "https://sicau.pascualbravo.edu.co/SICAU/API/ServicioLogin/LoginAmbientesVirtuales";
    private string apiKey = "s1c4uc0ntr0ld34cc3s02019*";


    // Objeto en el que se mostrará en pantalla el error
    public GameObject gmError;
    public TextMeshProUGUI txtError;

    public bool debugEnConsola; // Gestionador de mensajes

    private void Awake()
    {
        // Busca el objeto por nombre para buscar la referencia al objeto que administra la base de datos, ya que este pasar  entre escenas
        GameObject obj = GameObject.Find("EnvioBD");

        if (obj != null)
        {
            envioDatosBD = obj.GetComponent<EnvioDatosBD>(); // Si encuentra el objeto lo almacenamos en la variable
        }
        else
        {
            envioDatosBD = null;
        }
        if (envioDatosBD == null)
        {
            if (debugEnConsola) print("Falta inicializar componente managerBD");
        }
    }


    /// <summary>
    /// Metodo invocado desde el botón Iniciar en el Login para consumir el servicio
    /// </summary>
    public void Consumir()
    {
        // Crear un objeto con los datos que queremos enviar
        SolicitudLogin solicitudLogin = new SolicitudLogin
        {
            Email = inputUsuario.text + "@pascualbravo.edu.co",
            Contraseña = inputPassword.text
        };

        // Convertir el objeto a JSON
        string jsonDato = JsonUtility.ToJson(solicitudLogin);

        // Iniciar la corrutina para enviar los datos
        //StartCoroutine(PostDataFake()); // Para que no solicite credenciales
        StartCoroutine(PostData(jsonDato));  // Para que solicite credenciales de sicau
    }

    /// <summary>
    /// Currutina empleada para consumir el serevicio donde se valida su recepción y posterior lectura
    /// </summary>
    /// <param name="jsonDato"> Objeto convertido en json para su manejo </param>
    IEnumerator PostData(string jsonDato)
    {
        // Activar el indicador de carga
        imgCarga.SetActive(true);

        // Crear una solicitud POST, donde le enviamos la URL a consumir
        UnityWebRequest solicitud = new UnityWebRequest(apiUrl, "POST");
        // Convertir el JSON a bytes y adjuntar a la solicitud
        byte[] jsonAEnviar = new System.Text.UTF8Encoding().GetBytes(jsonDato);
        // Adjuntamos los datos JSON al cuerpo de la solicitud
        solicitud.uploadHandler = new UploadHandlerRaw(jsonAEnviar);
        // Recibe la respuesta en el buffer para su almacenamiento
        solicitud.downloadHandler = new DownloadHandlerBuffer();

        // Establecemos las cabeceras necesarias para indicar que los datos son JSON y añadimos la clave de autenticación (Authorization en este caso).
        solicitud.SetRequestHeader("Content-Type", "application/json");
        solicitud.SetRequestHeader("Authorization", apiKey);

        // Enviamos la solicitud y esperamos la respuesta
        yield return solicitud.SendWebRequest();

        // Comprobamos si hay errores en la solicitud
        if (solicitud.result == UnityWebRequest.Result.ConnectionError || solicitud.result == UnityWebRequest.Result.ProtocolError)
        {
            if (debugEnConsola)
            {
                print("Error: " + solicitud.error);
                print("Codigo de respuesta: " + solicitud.responseCode);
                print("URL: " + solicitud.url);
            }

            // Desactivar el indicador de carga después de recibir la respuesta
            imgCarga.SetActive(false);
            txtError.text = solicitud.error + "\n" + "Codigo de respuesta: " + solicitud.responseCode + "\n" + "URL: " + solicitud.url;
            gmError.SetActive(true);
        }
        else
        {
            // Sino se encuentra ningun error obtenemos la respuesta en formato JSON
            string respuestaJson = solicitud.downloadHandler.text;
            // Pasamos el json a un objeto tipo LoginRespuesta
            LoginRespuesta loginResponse = JsonUtility.FromJson<LoginRespuesta>(respuestaJson);
            // Si la respuesta es exitosa el estado de la consulta es verdadero
            loginResponse.Estado = true;

            // Procesamos la respuesta
            if (debugEnConsola)
            {
                print(respuestaJson);
                print(loginResponse.Datos);
                print("Estado: " + loginResponse.Estado);
                print("Mensaje: " + loginResponse.Mensaje);
            }

            // Validamos que los datos sean correctos para guardar los datos de usuario
            if (loginResponse.Mensaje != "El usuario y/o contraseña son inválidos")
            {
                AudioManager.Instance.PlayEfect(2);
                envioDatosBD.id_usuario = int.Parse(loginResponse.Datos.Identificacion);
                envioDatosBD.nombre = loginResponse.Datos.NombreCompleto;
                envioDatosBD.facultad = loginResponse.Datos.Facultad;
                envioDatosBD.programa = loginResponse.Datos.Programa;
                envioDatosBD.correo = inputUsuario.text;
                envioDatosBD.EnviarDatosU();
            }
            else
            {
                AudioManager.Instance.PlayEfect(3);
                txtError.text = "Usuario o Contraseña invalidos, verifique e ingrese nuevamente";
                imgCarga.SetActive(false);
                gmError.SetActive(true);
            }
        }
    }
}

[Serializable]
// Clase que Representa los datos que enviarás en la solicitud POST
public class SolicitudLogin
{
    public string Email;
    public string Contraseña;
}

[Serializable]
// Clase que Representa los datos anidados dentro de la respuesta
public class DatosUsuarioSicau
{
    public string Identificacion;
    public string NombreCompleto;
    public string TipoDeUsuario;
    public string Programa;
    public string Facultad;
}

[Serializable]
// Clase que Representa los datos anidados dentro de la respuesta
public class DatosUsuario
{
    public string id_usuario;
    public string personalizacion;
    public string tiempo_uso;
    public string num_conexiones;
    public string nombre;
    public string tipo_usuario;
    public string programa;
    public string facultad;
    public string usuario;
}


[Serializable]
// Clase que Representa la respuesta general que contiene un booleano de éxito, un mensaje, y los datos de respuesta
public class LoginRespuesta
{
    public bool Estado;
    public string Mensaje;
    public DatosUsuarioSicau Datos;
}