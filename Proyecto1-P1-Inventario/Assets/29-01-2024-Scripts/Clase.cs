using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;

    private bool inventoryEnabled;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    void Start()
    {
        allSlots = slotHolder.transform.childCount;

        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
            //slotHolder.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
            //slotHolder.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;

            ClaseItem item = itemPickedUp.GetComponent<ClaseItem>();

            AddItem(itemPickedUp,item.Name,item.life,item.descripcion,item.icon);
        }
    }

    void AddItem(GameObject itemObject, string itemName, int itemLife, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<ClaseItem>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().Name = itemName;

                slot[i].GetComponent<Slot>().life = itemLife;
                slot[i].GetComponent<Slot>().descripcion = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().empty = false;
            }
        }
    }
}
