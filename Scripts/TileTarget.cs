using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTarget : MonoBehaviour
{
    [SerializeField]
    public GameObject targetPrefab;
    GameObject tileMap;
    Tilemap tMap;

    private Vector3 tileLocation;

    private List<GameObject> tiles = new List<GameObject>();

    private void Start()
    {
        
        tileMap = GameObject.Find("Tilemap");
        tMap = tileMap.GetComponent<Tilemap>();
    }

    public void targetTile(FacingDirection.Direction dir, int range)
    {


        if (dir == FacingDirection.Direction.Up) // up
        {
            
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x), Mathf.Round(gameObject.transform.position.y) + i, 0)));
                AddTile();

            }
        }
        else if (dir == FacingDirection.Direction.Right) // right
        {
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x) + i, Mathf.Round(gameObject.transform.position.y), 0)));
                AddTile();

            }
        }
        else if (dir == FacingDirection.Direction.Down) // down
        {
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x), Mathf.Round(gameObject.transform.position.y) - i, 0)));
                AddTile();

            }
        }
        else if (dir == FacingDirection.Direction.Left) // left
        {
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x) - i, Mathf.Round(gameObject.transform.position.y), 0)));
                AddTile();

            }
        }

    }

    private void AddTile()
    {

            GameObject tile = Instantiate(targetPrefab, tileLocation, Quaternion.identity);
            tiles.Add(tile);
        
    }

    public void RemoveTiles()
    {
        if (tiles.Count != 0)
        {
            foreach (GameObject tile in tiles)
            {
                Destroy(tile);
            }
            tiles.Clear();
        }
    }
}
