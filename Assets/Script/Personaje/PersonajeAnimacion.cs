using System;
using UnityEngine;

public class PersonajeAnimacion : MonoBehaviour, ICharacterDefeatedListener
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    private Animator _animator;
    private PersonajeMovimiento _personajeMovimiento;

    private readonly int direccionX = Animator.StringToHash("x");
    private readonly int direccionY = Animator.StringToHash("y");
    private readonly int derrotado = Animator.StringToHash("Derrotado");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _personajeMovimiento = GetComponent<PersonajeMovimiento>();
    }

    void Update()
    {
        ActualizarLayers();

        if (!_animator.GetBool(derrotado) && _personajeMovimiento.EnMovimiento)
        {
            _animator.SetFloat(direccionX, _personajeMovimiento.DireccionMovimiento.x);
            _animator.SetFloat(direccionY, _personajeMovimiento.DireccionMovimiento.y);
        }
    }

    private void ActivarLayer(string nombreLayer)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer), 1);
    }

    private void ActualizarLayers()
    {
        if (!_animator.GetBool(derrotado))
        {
            if (_personajeMovimiento.EnMovimiento)
            {
                ActivarLayer(layerCaminar);
            }
            else
            {
                ActivarLayer(layerIdle);
            }
        }
    }

    public void RevivirPersonaje()
    {
        ActivarLayer(layerIdle);
        _animator.SetBool(derrotado, false);

        // Habilitar el movimiento cuando el personaje revive
        _personajeMovimiento.HabilitarMovimiento(true);
    }

    public void OnCharacterDefeated()
    {
        Debug.Log("Personaje derrotado"); // Agrega esto para verificar si la función se llama
        _animator.SetBool(derrotado, true);
        
        // Deshabilitar el movimiento cuando el personaje es derrotado
        _personajeMovimiento.HabilitarMovimiento(false);
    }

    private void OnEnable()
    {
        // Suscribirse al evento de derrota de PersonajeVida (asumiendo que PersonajeVida es quien dispara el evento)
        var vidaBase = GetComponent<PersonajeVida>();
        if (vidaBase != null)
        {
            vidaBase.OnCharacterDefeated += OnCharacterDefeated; // Suscribir al evento
        }
    }

    private void OnDisable()
    {
        // Desuscribirse del evento de derrota de PersonajeVida
        var vidaBase = GetComponent<PersonajeVida>();
        if (vidaBase != null)
        {
            vidaBase.OnCharacterDefeated -= OnCharacterDefeated; // Desuscribir el evento
        }
    }
}
