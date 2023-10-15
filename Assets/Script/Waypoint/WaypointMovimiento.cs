using UnityEngine;

public enum DireccionMovimiento
{
    Horizontal,
    Vetical
}

public class WaypointMovimiento : MonoBehaviour
{

    [SerializeField] private DireccionMovimiento direccion;
    [SerializeField] private float velocidad;

    public Vector3 PuntoPorMoverse => _waypoint.ObtenerPosicionMovimiento(puntoActualIndex);

    private Waypoint _waypoint;
    private int puntoActualIndex;
    private Vector3 ultimaPosicion;


    void Start()
    {
        puntoActualIndex = 0;
        _waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        MoverPersonaje();
        RotarPersonaje();
        if (ComprobarPuntoActualAlcanzado())
        {
            ActualizarIndexMovimiento();
        }
    }

    private void MoverPersonaje()
    {
        transform.position = Vector3.MoveTowards(transform.position, PuntoPorMoverse,
            velocidad * Time.deltaTime);
    }

    private bool ComprobarPuntoActualAlcanzado()
    {
        float distanciaHaciaPuntoActual = (transform.position - PuntoPorMoverse).magnitude;
        if (distanciaHaciaPuntoActual < 0.1f)
        {
            ultimaPosicion = transform.position;
            return true;   
        }
        return false;
    }

    private void ActualizarIndexMovimiento()
    {
        if(puntoActualIndex == _waypoint.Puntos.Length - 1)
        {
            puntoActualIndex = 0;

        }
        else
        {
            if (puntoActualIndex < _waypoint.Puntos.Length - 1)
            {
                puntoActualIndex++;
            }
        }
    }

    private void RotarPersonaje()
    {
        if (direccion != DireccionMovimiento.Horizontal)
        {
            return;
        }

        if (PuntoPorMoverse.x > ultimaPosicion.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
