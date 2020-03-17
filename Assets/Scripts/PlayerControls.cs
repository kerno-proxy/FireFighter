using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Element;

public class PlayerControls : MonoBehaviour
{
    public ElementsSO elementsList;
    
    [SerializeField] List<Collider> collisionList;
    [SerializeField] SpiritType devouredSpiritType = SpiritType.Empty;
    [SerializeField] Element originalSpiritCache;
    [SerializeField] float delayBeforeSpiritRelease;
    private SphereCollider mySphereCollider;

    

    void Start()
    {
        collisionList = new List<Collider>();
        mySphereCollider = GetComponent<SphereCollider>();
        CacheOriginalForm();
    }
    void Update()
    {
        FindNearbySpirit();
        if (Input.GetButtonDown("Spirit"))
        {
            DevourSpirit();
        } 
        
    }

    private void FindNearbySpirit()
    {
        float minDistance = mySphereCollider.radius;
        
        for (int i = 0; i<collisionList.Count; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, collisionList[i].gameObject.transform.position);
           
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                ActivateNearbySpirit(collisionList[i].gameObject);
            } else if (currentDistance>minDistance)
            {
               
                DeactivateNearbySpirit(collisionList[i].gameObject);
                collisionList.Remove(collisionList[i]);
               
            }
        }
    }

    private void DeactivateNearbySpirit(GameObject spiritToDeactivate)
    {
        
        spiritToDeactivate.GetComponent<Spirit>().DeactivateSpirit();
    }

    private void ActivateNearbySpirit(GameObject spiritToActivate)
    {
        
        spiritToActivate.GetComponent<Spirit>().ActivateSpirit();
    }

    private void DevourSpirit()
    {
        if (collisionList.Count > 0)
        {
            for (int i = 0; i < collisionList.Count; i++)
            {

                for (int j = 0; j < elementsList.elementsList.Length; j++)
                {
                    if (collisionList[i].gameObject.GetComponent<Spirit>().GetSpiritType() == elementsList.elementsList[j].spiritType)
                    {
                        transform.localScale = elementsList.elementsList[j].ObjectSize;
                        devouredSpiritType = elementsList.elementsList[j].spiritType;

                    }
                }
            }
        } else
        {
            ReleaseSpirit();
        }
    }
    private void ReleaseSpirit()
    {
        Debug.Log("Releasing spirit " + devouredSpiritType);
        transform.localScale = originalSpiritCache.ObjectSize;
    }
       
    private void OnTriggerEnter(Collider other)
    {
        if (!collisionList.Contains(other) && other.gameObject.tag == "Spirit")
        {

            collisionList.Add(other);
            
        }
    }
    private void CacheOriginalForm()
    {
        for (int i = 0; i < elementsList.elementsList.Length; i++)
        {
            if (elementsList.elementsList[i].spiritType == devouredSpiritType)
            {
                originalSpiritCache = elementsList.elementsList[i];
            }
        }
    }
   
}
