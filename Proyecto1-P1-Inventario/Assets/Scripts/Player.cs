using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject MainInventory;
    private bool MinventoryEnabled;

    public GameObject Buttons;
    private bool ButonsEnabled;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            MinventoryEnabled = !MinventoryEnabled;
        }

        if (MinventoryEnabled == true)
        {
            MainInventory.SetActive(true); 
        }
        else
        {
            MainInventory.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ButonsEnabled = !ButonsEnabled;
        }

        if (ButonsEnabled == true)
        {
            Buttons.SetActive(true);
        }
        else
        {
            Buttons.SetActive(false);
        }
    }

    //public void OntriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Item"))
    //    {
    //        //InventoryManager inventoryManager = other.GetComponent<InventoryManager>();
    //        GameObject itemPickedUp = other.gameObject;
    //        Item item = itemPickedUp.GetComponent<Item>();
    //        InventoryManager.instance.AddItem(item);

    //    }
    //}

     
}
