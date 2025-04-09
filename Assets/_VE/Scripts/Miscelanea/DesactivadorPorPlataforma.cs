using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivadorPorPlataforma : MonoBehaviour
{
    public Plataforma plataforma;
	public MessageOnly mensaje3 = new MessageOnly("Este Script solo es para poner en los objetos que se activan �nicamente para una plataforma.", MessageTypeCustom.Info);
	public MessageOnly mensaje2 = new MessageOnly("Si la plataforma objetivo es diferente a la seseccionada ac� el objeto se desactivar� en el Awake.", MessageTypeCustom.Info);

	private void Awake()
	{
		if (plataforma != ConfiguracionGeneral.configuracionDefault.plataformaObjetivo)
		{
			gameObject.SetActive(false);
		}
	}
}
