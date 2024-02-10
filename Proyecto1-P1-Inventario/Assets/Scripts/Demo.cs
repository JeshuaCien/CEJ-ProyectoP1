using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

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
}
