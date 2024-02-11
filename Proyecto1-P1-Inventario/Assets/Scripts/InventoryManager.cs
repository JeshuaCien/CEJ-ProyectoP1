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

    //Sirve para cambiar el color del slot 0 a el color se slot seleccionado.
    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        //Checamos que alguna llave (tecla) esta presinada
        if (Input.inputString != null)
        {
            //Se hace parsing para saber si la llave presionada es un numero del int.
            bool isNumber = int.TryParse(Input.inputString, out int number);
            //Ponemos un rango de las teclas que se pueden selecionar en el toolbar.
            if (isNumber && number > 0 && number <10)
            {
                //Linea de codigo para que el slot cambie de color.
                ChangeSelectedSlot(number -1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            { ChangeSelectedSlot(9);}
        }

        ////Líenas del if que sirven para poder saber que tecla esta presionada y se cambie el color
        //// del slot original al del slot selecionado.
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    ChangeSelectedSlot(0);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        //{ ChangeSelectedSlot(1);}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{ ChangeSelectedSlot(2);}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{ ChangeSelectedSlot(3);}
        //else if (Input.GetKeyDown(KeyCode.Alpha5))
        //{ ChangeSelectedSlot(4);}
        //else if (Input.GetKeyDown(KeyCode.Alpha6))
        //{ ChangeSelectedSlot(5);}
        //else if (Input.GetKeyDown(KeyCode.Alpha7))
        //{ ChangeSelectedSlot(6);}
        //else if (Input.GetKeyDown(KeyCode.Alpha8))
        //{ ChangeSelectedSlot(7);}
        //else if (Input.GetKeyDown(KeyCode.Alpha9))
        //{ ChangeSelectedSlot(8);}
        //else if (Input.GetKeyDown(KeyCode.Alpha0))
        //{ ChangeSelectedSlot(9);}
    }

    //Metodo que cambia el slot de color. 
    private void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].NoSelecionado();
        }
            inventorySlots[newValue].Selecionado();
            selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        //busca si uno de los slots tiene el mismo item con un contador inferior al maximo de capacidad.
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInslot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInslot != null && 
                itemInslot.item == item && 
                itemInslot.count < maxStackedItems &&
                itemInslot.item.stackable == true) 
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

    //metodo para eliminar y soltar objetos del toolbar.
    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInslot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInslot != null)
        {
           Item item = itemInslot.item;
            if (use == true)
            {
                itemInslot.count--;
                if (itemInslot.count <= 0)
                {
                    Destroy(itemInslot.gameObject);
                }
                else
                {
                    itemInslot.RefreshCount();
                }
            }
            return item;
        }
        //De lo contrario regresa algo nulo si no es un item que esta en el slot seleccionado.
        return null;
    }
}