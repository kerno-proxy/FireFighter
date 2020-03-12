using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField] MyElementSO spiritsList;
    //Need to find a way to populate this enumenator either manually or automatically from a dependant class (elements.cs)
    public enum ItemCharacteristic
    {
        Consumable,
        Combat,
        Resource,
    };
    [SerializeField] ItemCharacteristic myTestEnum;

}
