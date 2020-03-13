using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public MyElementSO testingSO;
    public Transform nearestSpirit;

    private List<Collider> collisionList;
    private SphereCollider mySphereCollider;

    void Start()
    {
        collisionList = new List<Collider>();
        mySphereCollider = GetComponent<SphereCollider>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Spirit"))
        {
            DevourSpirit();
        }
        ActivateNearbySpirit();
    }

    private void ActivateNearbySpirit() //Need to figure out a way to count distance between player and Spirit. There might be some sense in using Vector3.Distance.
    {
        Vector3 closestSpiritDistance = new Vector3(mySphereCollider.radius, mySphereCollider.radius, transform.position.z); //This one might be useless
        for (int i = 0; i < collisionList.Count; i++)
        {
            if ()
        }
    }

    private void DevourSpirit()
    {
        for (int i = 0; i<testingSO.elementsList.Length; i++)
        {
            Debug.Log(testingSO.elementsList[i].ElementName);
        }
    }
       private void OnTriggerStay(Collider other)
    {
        if (!collisionList.Contains(other) && other.gameObject.tag == "Spirit")
        {

            collisionList.Add(other);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (collisionList.Contains(other) && other.gameObject.tag == "Spirit")
            {
            Debug.Log("Forgetting a guy named: " + other.gameObject.name);
            collisionList.Remove(other);
            }
    }
}
