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
    [SerializeField]
    private int heldItemSortOrder = 10;
    [SerializeField]
    ItemObject currItem;
    ItemObject previousItem;

    [SerializeField]
    ToolItemObject currTool;


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
        rb.velocity = movementSystem.Move(rb, movementSpeed, horizontalSpeed, verticalSpeed);
        dir = direction.DirectionFacing(rb.velocity.x, rb.velocity.y);




         Action();
        ToolBarSelection();
        PlayerMenuOpenClose();

    }
    // item/tool action
    private void Action()
    {
        if (Input.GetKeyDown("x") == true)
        {
            if (heldItem != null)
            {
                if (currTool != null)
                {
                    GetComponent<TileTarget>().targetTile(dir, currTool.toolRange);
                    
                }
            }
        }

        if (Input.GetKeyUp("x") == true)
        {
            if (heldItem !=null)
            {
                if (currTool !=null)
                {
                    GetComponent<TileTarget>().RemoveTiles();
                    heldItem.GetComponent<ToolAction>().Action(currTool.toolType, currTool.toolRange, currTool.toolPower, currTool.rank, dir, gameObject.transform.position);
                }
                
            }
        }
    }

    private void PlayerMenuOpenClose()
    {
        if (Input.GetKeyDown("q") == true)
        {
            if (playerMenu.activeSelf == true)
            {
                playerMenu.SetActive(false) ;
                Time.timeScale = 1;
            }
            else
            {
                playerMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }


    // selections toolbar slot
    [Range(0, 9)]
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
        //ItemObject currItem = null;
        int itemQuantity = 0;

        var item = playerInventory.GetItemInSlot(selectedSlot);
        if (item.Item2 != null)
        {
            itemQuantity = item.Item1;
            currItem = item.Item2;


            HeldItemSpawning(currItem);
            Debug.Log("Current item is: " + currItem.name);
        }
   
    }

    // allows actions based on current item
    private void HeldItemSpawning(ItemObject currItem)
    {
        if (currItem != null)
        {
            // checks if the current item is still the same
            if (currItem != previousItem)
            {
                Destroy(heldItem);

                previousItem = currItem;

                // if the current item is a tool spawn it in player's hands
                if (currItem.type == ItemType.Tool)
                {
                    currTool = currItem as ToolItemObject;
                    HeldToolSpawn(currTool);
                }
                // if the item is not a tool make sure currTool is null
                else
                {
                    currTool = null;
                }
                //  Destroy(heldItem);
                // heldItem = Instantiate(currItem.prefab, gameObject.transform, false);
                //  heldItem.GetComponent<SpriteRenderer>().sortingOrder = 5;


            }
        }
    }


    private void HeldToolSpawn(ToolItemObject currTool)
    {
        heldItem = Instantiate(currTool.prefab, gameObject.transform, false);
        heldItem.name = "HeldItem";
        heldItem.GetComponent<SpriteRenderer>().sortingOrder = heldItemSortOrder;
        heldItem.transform.localPosition = new Vector3(0, 1, 0);
        Destroy(heldItem.GetComponent<CircleCollider2D>());
    }
}
