using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class AlembicLoopController : MonoBehaviour
{
    public AlembicStreamPlayer alembicPlayer; // Referencia al Alembic Stream Player
    public float time;
    public float timeMax;
 

    private void Update()
    {
        alembicPlayer.CurrentTime = time;
        time += Time.deltaTime;
        if (time > timeMax) 
        {
            time = 0;       
        }
       
    }
}



