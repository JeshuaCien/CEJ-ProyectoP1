using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    public void OnBeginDrag(PointerEventData evenData)
    {
        image.raycastTarget = false;

        //Debug.Log("comenzo el drag");
        //parentAfterDrag = transform.parent;
        //transform.SetParent(transform.root);
        //transform.SetAsLastSibling();
        
    }

    public void OnDrag(PointerEventData evenData)
    {
        transform.position = Input.mousePosition;

        //Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        //Debug.Log("termino el drag");
        //transform.SetParent(parentAfterDrag);
       
    }
}
