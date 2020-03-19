using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject spawningPoint;
    [SerializeField] float spawningPointDistanceLimit = 2f;
    private bool isChasingPlayer = false;
    private bool isReturningToPost = false;
    private Rigidbody rigidbodyCache;
    

    private void Start()
    {
        rigidbodyCache = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        
        if (isReturningToPost && Vector3.Distance(spawningPoint.transform.position, transform.position)<spawningPointDistanceLimit)
        {
            isReturningToPost = false;
            rigidbodyCache.velocity = Vector3.zero;
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            isChasingPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            isChasingPlayer = false;
            isReturningToPost = true;
            rigidbodyCache.velocity = new Vector3(spawningPoint.transform.position.x - transform.position.x, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && isChasingPlayer)
        {
            
            rigidbodyCache.velocity = new Vector3 (other.transform.position.x - transform.position.x, rigidbodyCache.velocity.y, rigidbodyCache.velocity.z);
            
        }
    }
}
