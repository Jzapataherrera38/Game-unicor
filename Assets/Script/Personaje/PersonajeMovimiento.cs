using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public bool EnMovimiento => movimientoHabilitado && _direccionMovimiento.magnitude > 0f;
    public Vector2 DireccionMovimiento => _direccionMovimiento;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    private Vector2 _input;
    private bool movimientoHabilitado = true; // Variable para habilitar/deshabilitar el movimiento

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_input.x > 0.1f)
            _direccionMovimiento.x = 1f;
        else if (_input.x < 0f)
            _direccionMovimiento.x = -1f;
        else
            _direccionMovimiento.x = 0;

        if (_input.y > 0.1f)
            _direccionMovimiento.y = 1f;
        else if (_input.y < 0f)
            _direccionMovimiento.y = -1f;
        else
            _direccionMovimiento.y = 0;
    }

    private void FixedUpdate()
    {
        if (movimientoHabilitado)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
        }
    }

    public void HabilitarMovimiento(bool habilitar)
    {
        movimientoHabilitado = habilitar;
    }
}
