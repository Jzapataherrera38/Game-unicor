using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Lista de objetos en el inventario

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Se ha añadido el objeto: " + item.name + " al inventario.");
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        Debug.Log("Se ha eliminado el objeto: " + item.name + " del inventario.");
    }
}

public class Item : MonoBehaviour
{
    public new string name; // Nombre del objeto
    // Aquí puedes agregar más propiedades para tu objeto, como descripción, imagen, estadísticas, etc.
}