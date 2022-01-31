using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // player attributes
    [SerializeField]
    protected float movementSpeed = 1f;
    [SerializeField]
    protected float manaMax = 1f;
    [SerializeField]
    protected float manaCurrent = 1f;
    [SerializeField]
    protected int playerInventorySize = 30;

    // player rigid body
    Rigidbody2D rb;

    // movement script
    Movement movementSystem;

    //Get Direction facing script
    FacingDirection direction;
    public FacingDirection.Direction dir;

    // target system
    TileTarget tileTarg;

    // camera script
    CameraFollow cameraSystem;

    // Inventory system
    [SerializeField]
    public InventoryObject playerInventory;
    [SerializeField]
    ItemObject emptyObject;

    //item pickup
    ItemPickup itemPkUP;

    // event system
    PlayerEventManager eventSystem;

    // get reference to player menu
    [SerializeField]
    GameObject playerMenu;

    // get reference to toolbar itemgrid script
    [SerializeField]
    ItemGrid toolbar;

    [SerializeField]
    private GameObject heldItem;

    ItemObject previousItem;




    // mining system
    Mine mine;

    // Start is called before the first frame update
    void Start()
    {
        // set player ridig body
        rb = GetComponent<Rigidbody2D>();

        // attach movement script
        movementSystem = gameObject.AddComponent<Movement>() as Movement;

        // attack get direction system

        direction = gameObject.AddComponent<FacingDirection>() as FacingDirection;

        // attach camera script
        cameraSystem = gameObject.AddComponent<CameraFollow>() as CameraFollow;
        // set camera target
        cameraSystem.ObjectToFollow(gameObject);

        // attach pickup script
        itemPkUP = gameObject.AddComponent<ItemPickup>();

        // attact=h mining sytem
        mine = gameObject.AddComponent<Mine>() as Mine;

        // tool action tile target system
        tileTarg = gameObject.AddComponent<TileTarget>() as TileTarget;

        // player event manager
        eventSystem = gameObject.AddComponent<PlayerEventManager>() as PlayerEventManager;

        playerInventory.EmptySlots(playerInventorySize, emptyObject);
        // default value for previous item
        previousItem = emptyObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        rb.velocity = movementSystem.Move(rb, movementSpeed, horizontalSpeed, verticalSpeed );
        dir = direction.DirectionFacing(rb.velocity.x, rb.velocity.y);

        


       // Action();
        ToolBarSelection();
      
    }

    //private void Action()
    //{
    //    if (Input.GetKeyDown("x") == true)
    //    {
    //        if (currentItem.type == ItemType.Tool)
    //        {
    //            if (currentTool.toolType == ToolItemObject.ToolType.Pickaxe)
    //            {
    //                tileTarg.targetTile(dir, currentTool.toolRange);
    //                mine.MineAction(currentTool.toolRange, currentTool.toolPower, currentTool.rank, dir);
    //            }
    //        }
    //    }
    //}


    // selections toolbar slot
    [Range(0,9)]
    int itemSelection = 0;

    // controls toolbar slot selection
    private void ToolBarSelection()
    {
        // moves left
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (itemSelection == 0)
            {
                itemSelection = 9;
            }
            else
            {
                itemSelection -= 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) 
        {
            // moves right
            if (itemSelection == 9)
            {
                itemSelection = 0;
            }
            else
            {
                itemSelection += 1;
            }
        }

        toolbar.ItemSelected(itemSelection);
        CurrentItem(itemSelection);
    }

    // passes selected item data to ui
    private void CurrentItem(int selectedSlot)
    {
        ItemObject currItem = null;
        int itemQuantity = 0;

        var item = playerInventory.GetItemInSlot(selectedSlot);
        itemQuantity = item.Item1;
        currItem = item.Item2;


        ItemActions(currItem);
        Debug.Log("Current item is: " + currItem.name);
    }

    // allows actions based on current item
    void ItemActions(ItemObject currItem)
    {


        if (currItem != previousItem)
        {
            
            if (currItem != emptyObject)
            {
                previousItem = currItem;
                Debug.Log("change current item");
              //  Destroy(heldItem);
                heldItem = Instantiate(currItem.prefab, gameObject.transform, false);
                heldItem.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }

        }

        if (currItem.type == ItemType.Tool)
        {
            ToolItemObject currTool = currItem as ToolItemObject;
            if (currTool.toolType == ToolItemObject.ToolType.Pickaxe)
            {

            }
        }
    }
}
