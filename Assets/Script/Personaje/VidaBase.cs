using System;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float saludInicial;
    [SerializeField] protected float saludMax;

    public float Salud { get; protected set; }

    public bool IsAlive { get { return Salud > 0f; } }

    // Define un evento público para notificar la derrota del personaje
    public event Action OnCharacterDefeated;

    protected virtual void Start()
    {
        Salud = saludInicial;
    }

    public void RecibirDaño(float cantidad)
    {
        if (cantidad <= 0)
        {
            return;
        }

        if (Salud > 0f)
        {
            Salud -= cantidad;
            ActualizarBarraVida(Salud, saludMax);
            if (Salud <= 0f)
            {
                ActualizarBarraVida(Salud, saludMax);
                PersonajeDerrotado();
            }
        }
    }

    protected virtual void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        // Implementa la actualización de la barra de vida aquí
    }

    protected virtual void PersonajeDerrotado()
    {
        // Implementa el comportamiento de derrota aquí, por ejemplo, desactivar el movimiento
        // Ejemplo:
        // GetComponent<MovimientoDelPersonaje>().enabled = false;

        // Disparar el evento de derrota
        OnCharacterDefeated?.Invoke();
    }

    void Update()
    {
        // Puedes implementar cualquier lógica de actualización aquí si es necesario
    }
}
