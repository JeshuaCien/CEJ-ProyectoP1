using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("UI-limite de stacks de los objetos")]
    public int maxStackedItems = 10;

    [Header("Stacks")]
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].NoSelecionado();

            inventorySlots[newValue].Selecionado();
            selectedSlot = newValue;
        }
    }

    public bool AddItem(Item item)
    {
        //busca si uno de los slots tiene el mismo item con un contador inferior al maximo de capacidad.
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInslot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInslot != null && itemInslot.item == item && itemInslot.count < maxStackedItems)
            {
                itemInslot.count++;
                itemInslot.RefreshCount();
                return true;
                // para detener la tarea.
            }

        }

        //Se llamara desde el Game con la información del item
        //que debera de ser agregado y busca si un slot esta vacío
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInslot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInslot == null)
            {
                SpawnNewItem(item, slot);
                return true;
                // para detener la tarea.
            }

        }
        return false;
    }

    // Buscara un slot que no este coupado para poder mandar el item en ese lugar.
    void SpawnNewItem(Item item, InventorySlot slot) 
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);

        //Va a assignar una varible y un sprite en la entrada de la función InitialiseItem del
        //Script InventoryItem.
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
