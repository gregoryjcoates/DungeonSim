using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// picks item up and adds it to the inventory
public class ItemPickup : MonoBehaviour
{
    public InventoryObject inventory;



    private void Awake()
    {
        inventory = gameObject.GetComponent<PlayerController>().playerInventory;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item == true)
        {
            // adds item to inventory script object
            inventory.AddItem(item.item, item.item.dropQuantity);

            Destroy(other.gameObject);
        }

    }
}
