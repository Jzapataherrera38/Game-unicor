using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Personaje : MonoBehaviour, ICharacterDefeatedListener
{
    public PersonajeVida PersonajeVida { get; private set; }
    public PersonajeAnimacion PersonajeAnimacion { get; private set; }

    private void Awake()
    {
        PersonajeVida = GetComponent<PersonajeVida>();
        PersonajeAnimacion = GetComponent<PersonajeAnimacion>();

        // Suscribirse al evento de derrota de PersonajeVida
        PersonajeVida.OnCharacterDefeated += OnCharacterDefeated;
    }

    public void RestaurarPersonaje()
    {
        PersonajeVida.RestaurarPersonaje();
        PersonajeAnimacion.RevivirPersonaje();
    }

    public void OnCharacterDefeated()
    {
        // Este método se llama cuando el personaje es derrotado
        // Agrega aquí las acciones que deseas realizar cuando el personaje es derrotado
    }
}
