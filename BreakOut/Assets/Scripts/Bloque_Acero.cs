using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Acero : Bloque
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
                resistencia = 5;
                break;
            case Opciones.dificultad.normal:
                resistencia = 10;
                break;
            case Opciones.dificultad.dificil:
                resistencia = 15;
                break;
        }
    }

    public override void RebotarBola()
    {
        base.RebotarBola();
    }
}
