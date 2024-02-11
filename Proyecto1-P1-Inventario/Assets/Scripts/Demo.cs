using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    //Metodo para agregar un item basado en el id de cada uno.
    public void PickupItem(int id)
    {
       bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        if (result == true)
        {
            Debug.Log("ITEM AGREGADO");
        }
        else 
        {
            Debug.Log("ITEM NO AGREGADO");
        }
    }

    //Metodo para soltar un objeto.
    public void Informar()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("Item soltado" + receivedItem);
        }
        else
        {
            Debug.Log("ningun item fue soltado");
        }
    }

    public void Eliminar()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Item eliminado" + receivedItem);
        }
        else
        {
            Debug.Log("ningun item fue eliminado");
        }
    }
}
