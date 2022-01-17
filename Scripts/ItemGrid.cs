using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ItemGrid : MonoBehaviour
{
    [SerializeField]
    int numberItems = 30;
    [SerializeField]
    private GameObject slot;

    GameObject player;

    public List<GameObject> itemSlots = new List<GameObject>();

    public EventAddItem iAdd;
    

    private void Awake()
    {
        player = GameObject.Find("Player");
        iAdd = new EventAddItem();
        iAdd.AddListener(addToSlot);
        for (int i = 0; i < numberItems; i++)
        {
            
           GameObject itemSlot = Instantiate(slot, gameObject.transform);
           itemSlot.name = "itemSlot" + (i + 1);
           itemSlots.Add(itemSlot);
            
        }
        

    }

    private void addToSlot(int slot, int quantity, ItemObject item)
    {
        Debug.Log("add slot event??");
        // different method needed
        //itemSlots[slot].GetComponentInChildren<Image>().image = item.prefab.GetComponent<SpriteRenderer>().sprite.texture;
    }

}
