using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TiposDeAtaque
{
    Melee,
    Embestida
}

public class IAController : MonoBehaviour
{

    // [Header("Stats")]
    // [SerializeField] private PersonajeStats stats;
    
    [Header("Estado")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;

    [Header("Config")]
    [SerializeField] private float rangoDeteccion;
    [SerializeField] private float rangoDeAtaque;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private LayerMask personajeLayerMask;

    [Header("Ataque")]
    [SerializeField] private float daño;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private TiposDeAtaque tipoAtaque;
    
    [Header("Debug")]
    [SerializeField] private bool mostrarDeteccion;
    [SerializeField] private bool mostrarRangoAtaque;

    public Transform PersonajeReferencia { get; set; }
    public IAEstado EstadoActual { get; set; }
    public EnemigoMovimiento EnemigoMovimiento { get; set; }
    public float RangoDeteccion => rangoDeteccion;
    public float RangoDeAtaque => rangoDeAtaque;

    public float Daño => daño;
    public TiposDeAtaque TipoAtaque => tipoAtaque;
    public float VelocidadMovimiento => velocidadMovimiento;
    public LayerMask PersonajeLayerMask => personajeLayerMask;
    
    private float timepoParaSiguienteAtaque;

    private void Start()
    {
        EstadoActual = estadoInicial;
        EnemigoMovimiento = GetComponent<EnemigoMovimiento>();
    }

    public void Update()
    {
        EstadoActual.EjecutarEstado(this);
      
    }

    public void CambiarEstado(IAEstado nuevoEstado)
    {
        if (nuevoEstado != estadoDefault)
        {
            EstadoActual = nuevoEstado;
        }
    }

    public void AtaqueMelee(float cantidad)
    {
        if (PersonajeReferencia != null)
        {
            AplicarDañoAlPersonaje(cantidad);
        }
    }

    public void AplicarDañoAlPersonaje(float cantidad)
    {
        float dañoPorRealizar = 0;
        // if (Random.value < stats.PorcetajeBloqueo / 100)
        // {
        //     return;
        // }

        dañoPorRealizar = Mathf.Max(cantidad, 1f);    
        PersonajeReferencia.GetComponent<PersonajeVida>().RecibirDaño(dañoPorRealizar);
    }

    public bool PersonajeEnRangoDeAtaque(float rango)
    {
        float distanciaHaciaPersonaje = (PersonajeReferencia.position - transform.position).sqrMagnitude;
        if (distanciaHaciaPersonaje < Mathf.Pow(rango, 2))
        {
            return true;
        }

        return false;
    }

    public bool EsTiempoDeAtacar()
    {
        if (Time.time > timepoParaSiguienteAtaque)
        {
            return true;
        }

        return false;
    }

    public void ActualizarTiempoEntreAtaque()
    {
        timepoParaSiguienteAtaque = Time.time + tiempoEntreAtaque;
    }

    private void OnDrawGizmos()
    {
        if (mostrarDeteccion)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        }

         if (mostrarRangoAtaque)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);
        }
    }


}
