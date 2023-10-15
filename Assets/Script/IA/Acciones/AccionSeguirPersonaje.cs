using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/Segui Personaje")]

public class AccionSeguirPersonaje : IAAccion
{
    public override void Ejecutar(IAController controller)
    {
        SeguirPersonaje(controller);
    }

    private void SeguirPersonaje (IAController controller)
    {
        if (controller.PersonajeReferencia == null)
        {
            return;
        }

        Vector3 dirHaciaPersonaje = controller.PersonajeReferencia.position - controller.transform.position;
        Vector3 direccion = dirHaciaPersonaje.normalized;
        float distancia = dirHaciaPersonaje.magnitude;

        if (distancia >= 1.35f)
        {
            controller.transform.Translate(direccion * controller.VelocidadMovimiento * Time.deltaTime);
        }
    }
}
