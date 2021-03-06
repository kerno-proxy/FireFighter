﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Element
{
    public string elementName = "Element Name";
    [SerializeField] private Vector3 objectSize;
    [SerializeField] private Color objectColor;
    public SpiritType spiritType;
    public enum SpiritType
    {
        Fire,
        Water,
        Earth,
        Air,
        Empty
    };
    

    public string ElementName
    {
        get { return elementName; }
        set { elementName = value; }
    }
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
    public SpiritType SetSpiritType
    {
        get { return spiritType; }
        set { spiritType = value; }
    }
}

