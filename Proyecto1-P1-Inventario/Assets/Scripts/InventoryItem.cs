using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;


    //Se crea la función que inicia el drag- mandando un mensaje que se inicio el drag.
    // Raycast se desactiva para poder mover los iconos por el tolbar.
    //Se hace parent para que el objeto que se selecciona pueda moverse por encima de la UI.
    public void OnBeginDrag(PointerEventData evenData)
    {

        Debug.Log("comenzo el drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        image.raycastTarget = false;
        //transform.SetAsLastSibling();
        
    }


    //Funcion que mantiene el objeto mientras el mouse mantiene su click.
    //Manda mensaje de que se está haciendo Dragging.
    public void OnDrag(PointerEventData evenData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }


    // Raycast se activa para poder colocar la imagen en el tolbar.
    //Cuando se termina el drag- se hace parent del slot para colocarse por encima de este.
    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("termino el drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
       
    }
}
