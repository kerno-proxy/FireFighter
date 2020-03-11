using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements: ScriptableObject
{
    public List<Element> elements;
    void OnEnable()
    {
        elements = new List<Element>();
    }
}
