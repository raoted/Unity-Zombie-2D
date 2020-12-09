using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAstar : MonoBehaviour
{
    public int colCount, rowCount;
    public Vector2 startPos;

    private GameObject mapTile;
    private int tileWidth = 1;
    private int tileHeight = 1;
    private int col = 0;
    private int row = 0;

    private GameObject my;
    private GameObject parentNode;
    private GameObject targetNode;
    private GameObject selectedTile;

    private Dictionary<Vector2, GameObject> tileDic = new Dictionary<Vector2, GameObject>();
    private List<GameObject> openList = new List<GameObject>();
    private List<GameObject> closedList = new List<GameObject>();

    void Start()
    {
        CreateMap();
        CreateTile();
    }

    void CreateTile()
    {
        this.my = Instantiate(Resources.Load<GameObject>("Node"));

        this.CreateTileMap(my, this.startPos.x, this.startPos.y);
        this.parentNode = my;
    }

    private void CreateTileMap(GameObject tileMap, float x, float y)
    {
        Vector2 vec2 = new Vector2(x * tileWidth, y * tileHeight);

        tileMap.AddComponent<Node>();
        tileMap.GetComponent<Node>().vec2 = vec2;

        tileMap.transform.position = MapToScreen(vec2);
    }

    private void CreateMap()
    {
        while(true)
        {
            this.mapTile = Instantiate(Resources.Load<GameObject>("mapTile"));

            this.mapTile.tag = "Tile";

            this.mapTile.transform.SetParent(this.transform);

            this.CreateTileMap(this.mapTile, this.col, this.row);
            this.tileDic.Add(new Vector2(col, row), mapTile);
            this.col++;

            if(this.col >= this.colCount)
            {
                this.col = 0;
                this.row++;
            }
            if(this.row >= this.rowCount)
            {
                row = 0;
                break;
            }
        }
    }

    private Vector2 MapToScreen(Vector2 mapPos)
    {
        float screenX = mapPos.x * tileWidth - (mapPos.y * tileWidth);
        float screenY = mapPos.y * -tileHeight - (mapPos.x * tileHeight);

        return new Vector2(screenX, screenY);
    }
}
