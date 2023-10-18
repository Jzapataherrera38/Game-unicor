using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioManager : MonoBehaviour
{
    [SerializeField] private GameObject inventarioUI; // El objeto de la interfaz de usuario del inventario
    private bool inventarioAbierto = false; // Variable para controlar si el inventario está abierto o cerrado

    private void Start()
    {
        CerrarInventario(); // Asegúrate de que el inventario esté cerrado al inicio del juego
    }

    private void Update()
    {
        // Verifica si el jugador presiona una tecla o botón para abrir/cerrar el inventario
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventarioAbierto)
            {
                CerrarInventario();
            }
            else
            {
                AbrirInventario();
            }
        }
    }

    public void AbrirInventario()
    {
        inventarioUI.SetActive(true);
        inventarioAbierto = true;
    }

    public void CerrarInventario()
    {
        inventarioUI.SetActive(false);
        inventarioAbierto = false;
    }
}
