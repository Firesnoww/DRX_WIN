using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    // La �nica instancia de la clase
    public static ManagerScene instance;

    // M�todo que se llama al iniciar la clase
    void Awake()
    {
        // Si no hay otra instancia, esta ser� la principal
        if (instance == null)
        {
            instance = this;

            // Evita que se destruya cuando cambia de escena
            DontDestroyOnLoad(gameObject);
        }
        // Si ya existe otra instancia y no es esta, destruye esta para mantener solo una
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Metodo invocado si se desea cambiar entre escenas sin una pantalla de carga
    /// </summary>
    /// <param name="nombreScena"> Nombre de la escena a la cual queremos cambiar </param>
    public void CargarEscenaNormal(string nombreScena)
    {
        // Carga as�ncrona
        SceneManager.LoadScene(nombreScena);
    }


    /// <summary>
    /// Metodo invocado si se desea cambiar entre escenas mostrando una pantalla de carga
    /// </summary>
    /// <param name="nombreScena"> Nombre de la escena a la cual queremos cambiar </param>
    public void CargarEscenaAsincronamente(string nombreScena)
    {
        // Carga as�ncrona
        StartCoroutine(EscenaAsincrona(nombreScena));
    }

    /// <summary>
    /// Currutina encargada de hacer carga as�ncrona de la escena de la pista una vez termine de guardar la personalizacion de el furtivo
    /// </summary>
    IEnumerator EscenaAsincrona(string scena)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(scena); // Iniciar la carga as�ncrona de la escena

        operacion.allowSceneActivation = false; // Evita que la escena se active autom�ticamente cuando termina de cargar

        // Mientras la escena se carga, mostrar la imagen de "Cargando".
        while (!operacion.isDone)
        {
            // Podriamos mostrar el progreso de carga (opcional)
            //float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
            //Debug.Log("Progreso de carga: " + (progreso * 100) + "%");

            // Si la escena ha cargado al 90% (es el valor m�ximo antes de activar la escena).
            if (operacion.progress >= 0.9f)
            {
                // Aqu� podr�amos agregar una animaci�n o mensaje de "Presiona un bot�n para continuar" si lo deseamos
                // Activar la escena una vez que ha terminado de cargar.       
                operacion.allowSceneActivation = true;
                
            }       
            yield return null;
        }   
    }
}
