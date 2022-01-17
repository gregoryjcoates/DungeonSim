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

    private void Start()
    {
        targetPrefab = Resources.Load<GameObject>("TileTarget");
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
                Instantiate(targetPrefab, tileLocation, Quaternion.identity);


            }
        }
        else if (dir == FacingDirection.Direction.Right) // right
        {
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x) + i, Mathf.Round(gameObject.transform.position.y), 0)));
                Instantiate(targetPrefab, tileLocation , Quaternion.identity);

            }
        }
        else if (dir == FacingDirection.Direction.Down) // down
        {
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x), Mathf.Round(gameObject.transform.position.y) - i, 0)));
                Instantiate(targetPrefab, tileLocation, Quaternion.identity);

            }
        }
        else if (dir == FacingDirection.Direction.Left) // left
        {
            for (int i = 1; i <= range; i++)
            {
                tileLocation = (tMap.WorldToCell(new Vector3(Mathf.Round(gameObject.transform.position.x) - i, Mathf.Round(gameObject.transform.position.y), 0)));
                Instantiate(targetPrefab, tileLocation, Quaternion.identity);

            }
        }

    }

}
