using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class EventAddItem : UnityEvent<int, int, ItemObject>
{
    
}

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{

    public List<InventorySlot> slotList = new List<InventorySlot>();


    // adds item and item slot if needed
    public void AddItem(ItemObject _item, int _quantity)
    {
        bool itemFound = false;

        Debug.Log("add item is being called");
        // increases item count if item found in slot
        foreach (var slot in slotList)
        {
            if (slot.item == _item)
            {
                Debug.Log("Item is already aquired and should increase");
                slot.IncreaseQuantity(_quantity);
                itemFound = true;
                break;
            }
            
        }
        // runs if item not found in slot
        if (itemFound == false)
        {
            foreach (var slot in slotList)
            {
                // checks if there is an empty slot
                if (slot.item == null)
                {
                    slot.item = _item;
                    slot.IncreaseQuantity(_quantity);
                    Debug.Log("Item added to empty slot");
                    itemFound = true;
                    break;
                }
            }
            // runs if no empty slot is found and adds a new slot
            if (itemFound == false)
            {
                slotList.Add(new InventorySlot(_item, _quantity));
                Debug.Log("New item added to inventory");
            }

        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int quantity;
    
    public InventorySlot(ItemObject _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
        
    }

    public void IncreaseQuantity(int count)
    {
        quantity += count;
    }

    public void DecreaseQuantity(int count)
    {
        quantity -= count;
    }
}




