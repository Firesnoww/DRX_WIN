using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAutoEncendida : MonoBehaviour
{
    public Animator anim;
    private bool activo = false;
    public float conteo;
    // Start is called before the first frame update
    public void EstadoBoton()
    {
        if (activo)
        {
            activo = false;
        }
        else
        {
            activo = true;
        }

        anim.SetBool("Entro", activo);
    }

    private void Update()
    {
       
    }
}
