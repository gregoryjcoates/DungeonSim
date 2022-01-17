using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Mine : MonoBehaviour
{

    [SerializeField]
    private UnityEvent mine;
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

    public void MineAction(int range, int power, int rank, FacingDirection.Direction dir)
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        Vector3 position = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x), Mathf.Round(gameObject.transform.position.y), 0)));

        if (dir == FacingDirection.Direction.Up)
        {
            Debug.DrawLine(position, position + new Vector3(0, range), Color.yellow, 10f);
            Physics2D.Linecast(position, position + new Vector3(0, range),filter, hits);

            foreach (RaycastHit2D thingy in hits)
            {
                Debug.Log("did this work?");
                GameObject a = thingy.collider.gameObject;
                mineItem.Invoke();
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
