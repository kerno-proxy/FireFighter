using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Spirit"))
        {
            DevourSpirit();
        }
    }

    private void DevourSpirit()
    {
        throw new NotImplementedException();
    }
}
