using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public MyElementSO testingSO;
    void Update()
    {
        if (Input.GetButtonDown("Spirit"))
        {
            DevourSpirit();
        }
    }

    private void DevourSpirit()
    {
        for (int i = 0; i<testingSO.elementsList.Length; i++)
        {
            Debug.Log(testingSO.elementsList[i].ElementName);
        }
    }
}
