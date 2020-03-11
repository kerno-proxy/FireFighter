using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
    private Vector3 objectSize;
    private Color objectColor;

    public Vector3 ObjectSize
    {
        get{ return objectSize; }
        set{ objectSize = value; }
    }
    public Color ObjectColor
    {
        get { return objectColor; }
        set { objectColor = value; }
    }
}

