using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Opciones", menuName = "Herramientas/Opciones", order = 1)]
public class Opciones : PuntajePersistente
{
    public float velocidadBola = 30;
    public dificultad NivelDificultad = dificultad.facil;

    public event Action<dificultad> OnDificultadChanged;  

    public enum dificultad
    {
        facil,
        normal,
        dificil
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBola = nuevaVelocidad;

        Bola bola = FindObjectOfType<Bola>();
        if (bola != null)
        {
            bola.velocidadBola = nuevaVelocidad;
        }
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        NivelDificultad = (dificultad)nuevaDificultad;
        OnDificultadChanged?.Invoke(NivelDificultad); 
    }
}

