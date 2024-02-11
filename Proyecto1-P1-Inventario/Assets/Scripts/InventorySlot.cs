using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor;
    public Color originalColor;

    private void Awake()
    {
        NoSelecionado();
    }

    public void Selecionado()
    {
        image.color = selectedColor;
    }

    public void NoSelecionado()
    {
        image.color = originalColor;
    }

    //Linea de codigo para hacer que los objetos selecionados se puedan soltar en cualquiera
    //de los slot del inventario y tolbar.
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform; 
        }
    }
    
}
