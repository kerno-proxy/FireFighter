using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isChasingPlayer = false;
    private bool isReturningToPost = false;
    private Rigidbody rigidbodyCache;

    private void Start()
    {
        rigidbodyCache = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Detected a player");
            isChasingPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isChasingPlayer = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            rigidbodyCache.velocity = other.transform.position - transform.position;
        }
    }
}
