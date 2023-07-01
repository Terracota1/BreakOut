using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Acero : Bloque
{
    //Tarea
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 10;
    }
    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola();
    }
}
