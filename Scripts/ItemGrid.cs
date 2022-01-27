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
    int ItemsToDisplay = 10;
    [SerializeField]
    private GameObject slot;
    [SerializeField]
    private GameObject itemInSlot;
    [SerializeField]
    private InventoryObject inventory;
    [SerializeField]
    private Sprite selected;
    [SerializeField]
    private Sprite unselected;
    [SerializeField]
    private int itemSelectedDefault = 0;
    [SerializeField]
    private EmptyItemObject emptyObject;

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

    private void Update()
    {
        ItemSelected(itemSelectedDefault);
    }

    // when ui is brought up it updates it
    private void OnEnable()
    {
        
        for (int i = 0; i < inventory.GetSlotCount(); i++)
        {
            if (i > ItemsToDisplay)
            {
                break;
            }
            var item = inventory.GetItemInSlot(i);
            addToSlot(i, item.Item1, item.Item2);
        }

        ItemSelected(0);
    }


    private void addToSlot(int slot, int quantity, ItemObject item)
    {
        Debug.Log("add to slot is called");

        // make child object of item slot
        // itemSlots[slot].
        // does not work...GameObject newItem = Instantiate(item.prefab,itemSlots[slot].transform, false);
        GameObject newItem = Instantiate(itemInSlot,itemSlots[slot].transform);
        newItem.GetComponent<UnityEngine.UI.Image>().sprite = item.prefab.GetComponent<SpriteRenderer>().sprite;

        RectTransform rectTrans = newItem.GetComponent<RectTransform>();

        rectTrans.localPosition = new Vector3(0,0,0);
        rectTrans.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        


    }


    int previousSelected = -1;
    // for toolbat item selection
    public void ItemSelected(int itemSelected)
    {
        GameObject slot;

        

        if (previousSelected != -1)
        {
            gameObject.transform.GetChild(previousSelected).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = unselected;
        }
        // gets the itemslot of the int
        // slot = gameObject.transform.GetChild(itemSelected).gameObject;
        slot = itemSlots[itemSelected];

        previousSelected = itemSelected;

        slot.GetComponent<UnityEngine.UI.Image>().sprite = selected;
        Debug.Log("Slot color changed");
    }

}
