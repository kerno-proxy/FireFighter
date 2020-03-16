using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Element;

public class Spirit : MonoBehaviour
{
    [SerializeField] ElementsSO spiritsList;
    [SerializeField] SpiritType spiritType;

    private Color colorCache;
    private MeshRenderer spiritMaterial;
    private void Start()
    {
        spiritMaterial = GetComponent<MeshRenderer>();
        SetSpiritCharacteristics();
        colorCache = spiritMaterial.material.color;
    }
    public SpiritType GetSpiritType()
    {
        return spiritType;
    }
    public void ActivateSpirit()
    {
        
        spiritMaterial.material.color = Color.red;
    }
    public void DeactivateSpirit()
    {
        
        spiritMaterial.material.color = colorCache;
    }
    private void SetSpiritCharacteristics()
    {
        for (int i = 0; i<spiritsList.elementsList.Length; i++)
        {
            if (spiritType == spiritsList.elementsList[i].spiritType)
            {
                spiritMaterial.material.color = spiritsList.elementsList[i].ObjectColor;
            }
        }
    }
}
