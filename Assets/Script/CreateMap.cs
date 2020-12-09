using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private int mapSize = 0;
    [SerializeField] private int xSize = 1;
    [SerializeField] private int ySize = 1;
    [SerializeField] private GameObject movePoint;
    //[SerializeField] private int summonCount = 0;

    GameObject obj;

    [SerializeField] List<Vector3> Point;
    // Start is called before the first frame update
    void Start()
    {
        Point = new List<Vector3>();
        for(int i = mapSize-1; i >= 0; i--)
        {
            for(int j = 0; j < mapSize - i; j++)
            {
                Point.Add(new Vector3(j * xSize - (mapSize - i-1), ySize * i, 1));
            }
        }
        for(int i = 1; i < mapSize; i++)
        {
            for(int j = 0; j < mapSize - i; j++)
            {
                Point.Add(new Vector3(j * xSize - (mapSize - i - 1), -i * ySize, 1));
            }
        }

        for(int i = 0; i < Point.Count; i++)
        {
            Instantiate(movePoint, Point[i], new Quaternion(0, 0, 0, 0), gameObject.transform);
        }
    }

    void Shuffle()
    {
        Vector3 temp;

        int first;
        int second;
        for (int i = 0; i < 1000; i++)
        {
            first = Random.Range(0, (xSize * ySize) - 1);
            second = Random.Range(0, (xSize * ySize) - 1);
            temp = Point[first];
            Point[first] = Point[second];
            Point[second] = temp;
        }

    }
}
