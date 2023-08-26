using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Piedra : Bloque
{
    public Opciones opciones;

    void OnEnable()
    {
        opciones.OnDificultadChanged += ActualizarResistencia; 
    }

    void OnDisable()
    {
        opciones.OnDificultadChanged -= ActualizarResistencia;  
    }

    void Start()
    {
        ActualizarResistencia(opciones.NivelDificultad); 
    }

    void ActualizarResistencia(Opciones.dificultad dificultad)
    {
        switch (dificultad)
        {
            case Opciones.dificultad.facil:
                resistencia = 4;
                break;
            case Opciones.dificultad.normal:
                resistencia = 8;
                break;
            case Opciones.dificultad.dificil:
                resistencia = 12;
                break;
        }
    }

    public override void RebotarBola()
    {
        base.RebotarBola();
    }
}

