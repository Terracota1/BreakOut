using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Madera : Bloque
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
                resistencia = 3;
                break;
            case Opciones.dificultad.normal:
                resistencia = 6;
                break;
            case Opciones.dificultad.dificil:
                resistencia = 9;
                break;
        }
    }

    public override void RebotarBola()
    {
        base.RebotarBola();
    }
}
