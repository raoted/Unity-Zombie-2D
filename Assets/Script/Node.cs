using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int g, h;
    public int f
    {
        get { return g + h; }
    }

    public Vector2 vec2;
    public bool closedNode;
    public bool isBlock;

    public Node(Vector2 _vec2)
    {
        vec2 = _vec2;
    }
}
