using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public EventAddItem iAdd;


    private void Awake()
    {
        inventory = Resources.Load<InventoryObject>("ScriptableObjects/Inventory/PlayerInventory");

        iAdd = GameObject.Find("ItemGrid").GetComponent<ItemGrid>().iAdd;
        
    }



    public void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("item found");
        var item = other.GetComponent<Item>();
        if (item == true)
        {
            // adds item to inventory script object
            inventory.AddItem(item.item, item.item.dropQuantity);

            for (int i = 0; i < inventory.slotList.Count; i++)
            {
                Debug.Log("add item sent");
                // sends item to UI
                iAdd.Invoke(i, inventory.slotList[i].quantity, inventory.slotList[i].item);
            }
            Debug.Log("Destroy item pickup");
            Destroy(other.gameObject);
        }

    }

}
