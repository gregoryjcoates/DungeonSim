using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public EventAddItem iAdd;
    public InventoryObject inventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().inventory;
        if (iAdd == null)
        {
            iAdd = new EventAddItem();
        }
    }

    private void Update()
    {
        for (int i = 0; i < inventory.slotList.Count; i++)
        {
            Debug.Log("add item sent");
            iAdd.Invoke(i, inventory.slotList[i].quantity, inventory.slotList[i].item);
        }
    }
}
