using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorGenerator : MonoBehaviour
{
    private void Start()
    {
        GenerateColor();
    }
    public void GenerateColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }
    public void Reset()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }
}
