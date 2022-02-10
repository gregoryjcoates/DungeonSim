using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Mine : MonoBehaviour
{

    ContactFilter2D filter;

    GameObject tileMap;
    Tilemap tMap;

    [SerializeField]
    private UnityEvent mineItem;

    private void Awake()
    {
        tileMap = GameObject.Find("Tilemap");
        tMap = tileMap.GetComponent<Tilemap>();
        filter.NoFilter();
    }

    public void MineAction(int range, int power, int rank, FacingDirection.Direction dir, Vector3 playerPosition)
    {
        Debug.Log("mine action is called");

        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        Vector3 position = (tMap.WorldToCell(new Vector3(Mathf.Round(playerPosition.x), Mathf.Round(playerPosition.y), 0)));

        if (dir == FacingDirection.Direction.Up)
        {
            Debug.DrawLine(position, position + new Vector3(0, range), Color.yellow, 10f);
            Physics2D.Linecast(position, position + new Vector3(0, range),filter, hits);

            foreach (RaycastHit2D thingy in hits)
            {


                GameObject thingHit = thingy.transform.gameObject;

                if (thingHit.tag == "MineAble")
                {
                    if (thingHit.GetComponent<MineableObject>().instance.Mine(power, rank) == 0)
                    {
                        GameObject drop = thingHit.GetComponent<MineableObject>().instance.GetDrop();
                        if (drop != null)
                        {
                            Instantiate(drop, thingHit.transform.position, Quaternion.identity);
                        }

                        Destroy(thingHit);
                    } 
                }

            }
            
        }
        else if (dir == FacingDirection.Direction.Right)
        {

        }
        else if (dir == FacingDirection.Direction.Down)
        {

        }
        else if (dir == FacingDirection.Direction.Left)
        {

        }
    }
}
