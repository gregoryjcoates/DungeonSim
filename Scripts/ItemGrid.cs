using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ItemGrid : MonoBehaviour
{
    [SerializeField]
    int ItemGridSize = 30;
    [SerializeField]
    private GameObject slot;
    [SerializeField]
    private GameObject itemInSlot;
    [SerializeField]
    private InventoryObject inventory;

    public List<GameObject> itemSlots = new List<GameObject>();

    

    private void Awake()
    {
        
        // creates empty itemslots
        for (int i = 0; i < ItemGridSize; i++)
        {
            
           GameObject itemSlot = Instantiate(slot, gameObject.transform);
           itemSlot.name = "itemSlot" + (i + 1);
           itemSlots.Add(itemSlot);
            
        }
        

    }
    // when ui is brought up it updates it
    private void OnEnable()
    {
        for (int i = 0; i < inventory.GetSlotCount(); i++)
        {
            var item = inventory.GetItemInSlot(i);
            addToSlot(i, item.Item1, item.Item2);
        }
    }


    private void addToSlot(int slot, int quantity, ItemObject item)
    {
        Debug.Log("add to slot is called");

        // make child object of item slot
        // itemSlots[slot].
        // does not work...GameObject newItem = Instantiate(item.prefab,itemSlots[slot].transform, false);
        GameObject newItem = Instantiate(itemInSlot,itemSlots[slot].transform);
        newItem.GetComponent<UnityEngine.UI.Image>().sprite = item.prefab.GetComponent<SpriteRenderer>().sprite;

        newItem.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);


    }

}
