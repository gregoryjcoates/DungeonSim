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
    PlayerInventory inventorySystem;

    // event system
    PlayerEventManager eventSystem;

    [SerializeField]
    ItemObject currentItem;
    TrapItemObject currentTrap;
    ToolItemObject currentTool;
    LootItemObject currentLoot;
    FeedItemObject currentFeed;
    CosmeticItemObject currentCosmetic;
    ArtifactItemObject currentArtifact;






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

        // player inventory system
        inventorySystem = gameObject.AddComponent<PlayerInventory>() as PlayerInventory;

        // attact mining sytem
        mine = gameObject.AddComponent<Mine>() as Mine;

        // tool action tile target system
        tileTarg = gameObject.AddComponent<TileTarget>() as TileTarget;

        // player event manager
        eventSystem = gameObject.AddComponent<PlayerEventManager>() as PlayerEventManager;
    }

    // Update is called once per frame
    void Update()
    {
        // 
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        rb.velocity = movementSystem.Move(rb, movementSpeed, horizontalSpeed, verticalSpeed );
        dir = direction.DirectionFacing(rb.velocity.x, rb.velocity.y);

        if (currentItem.type == ItemType.Tool)
        {
            currentTool = (ToolItemObject)currentItem;
        }

        Action();
      
    }

    private void Action()
    {
        if (Input.GetKeyDown("x") == true)
        {
            if (currentItem.type == ItemType.Tool)
            {
                if (currentTool.toolType == ToolItemObject.ToolType.Pickaxe)
                {
                    tileTarg.targetTile(dir, currentTool.toolRange);
                    mine.MineAction(currentTool.toolRange, currentTool.toolPower, currentTool.rank, dir);
                }
            }
        }
    }
}
