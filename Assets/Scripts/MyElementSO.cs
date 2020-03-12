using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementsList",menuName ="Elemenets Framework/create new ElementsList")]
public class MyElementSO : ScriptableObject
{
    public Element[] elementsList;
    public enum SpiritsList
    {
        Fire,
        Water,
        Earth,
        Air
    };
    public SpiritsList chooseASpirit;

    //Need to figure out if these things are actually needed for anything.
    /*public void Init()
    {
        PopulateElementsSet();
    }
    void PopulateElementsSet()
    {
        for (int i = 0; i<elementsList.Length; i++)
        {
            elementsList[i] = new Element();
        }
    }*/
}
