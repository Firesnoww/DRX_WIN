using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAleatorio : MonoBehaviour
{
    public Shader shader;
    public MeshRenderer mesh;

    private void Start()
    {
        Material m = new Material(shader);
        mesh.material = m;
        CambioMaterial();
    }
    // Start is called before the first frame update
    public void CambioMaterial()
    {
        mesh.sharedMaterial.SetFloat("_Velocidad", Random.Range(0.2f, 4));
        mesh.sharedMaterial.SetFloat("_Patron", Random.Range(1, 12));
        mesh.sharedMaterial.SetFloat("_Margen", Random.Range(-1.25f, 5)); ;
        mesh.sharedMaterial.SetFloat("_Color1", Random.Range(0f, 1f));
        mesh.sharedMaterial.SetFloat("_Color2", Random.Range(0f, 1f));

    }
}
