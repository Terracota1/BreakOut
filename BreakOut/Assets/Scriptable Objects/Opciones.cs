using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Opciones", menuName = "Herramientas/Opciones", order = 1)]

public class Opciones : PuntajePersistente
{
    public float velocidadBola = 50f;
    public Dificultad nivelDificultad = Dificultad.Facil;

    public enum Dificultad
    {
        Facil,
        Normal,
        Dificil
    }

    public float VelocidadPorDificultad(Dificultad dificultad)
    {
        switch (dificultad)
        {
            case Dificultad.Facil:
                return 50f;
            case Dificultad.Normal:
                return 100f;
            case Dificultad.Dificil:
                return 200f;
            default:
                return 50f;
        }
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBola = nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        nivelDificultad = (Dificultad)nuevaDificultad;
        velocidadBola = VelocidadPorDificultad(nivelDificultad);
    }

    public float VelocidadActual
    {
        get { return VelocidadPorDificultad(nivelDificultad); }
    }
}