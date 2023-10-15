using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private static Inventario instance;

    public static Inventario Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventario>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Inventario>();
                    singletonObject.name = "Inventario (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }


    [SerializeField] private int numeroDeSlots;
    public int NumeroDeSlots => numeroDeSlots;

    [Header("Items")]
    [SerializeField] private InventarioItem[] itemsInventario;

    private void Start()
    {
        itemsInventario = new InventarioItem[numeroDeSlots];
    }
}