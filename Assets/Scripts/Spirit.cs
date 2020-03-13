using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField] MyElementSO spiritsList;
    [SerializeField] Element.ItemCharacteristic SpiritType;

    public Element.ItemCharacteristic GetSpiritType()
    {
        return SpiritType;
    }

}
