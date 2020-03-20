﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject spawningPoint;
    [SerializeField] float spawningPointDistanceLimit = 2f;
    [SerializeField] float attackRange = 1.5f;
    private bool isChasingPlayer = false;
    private bool isReturningToPost = false;
    private Rigidbody rigidbodyCache;
    private float rangeVariator = .5f, detectionVariator = .5f;
    private bool isAttackingPlayer = false;
    private float returnToThePostDelay = 3f;
    private float detectionRange = 10f;
    

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
    /* private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Player")
         {

             isChasingPlayer = true;
         }
     }*/
    private void OnTriggerEnter(Collider other)
    {
        //We detected a player nearby and initializing chasing
        if (other.tag == "Player")
        {
            InitializeChasing(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //We got close enough to initialize attack. At that point we should stop chasing player
        if (other.tag == "Player" && CalcDistanceBetweenPlayerAndEnemy(other,rangeVariator)< attackRange)
        {
            StopMoving();
            Attack();
           
        } 

    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(KeepFollowingThePlayer(other,returnToThePostDelay));  
    }
    /*private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ChasingPlayer(other));
    }*/
    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag== ("Player") && Vector3.Distance(other.gameObject.transform.position, transform.position) - Random.Range(-rangeVariator, rangeVariator) < attackRange)
        {
            isChasingPlayer = false;
            isAttackingPlayer = true;
            rigidbodyCache.velocity = Vector3.zero;
        }
        else if (other.tag == "Player" && isChasingPlayer)
        {
            
           
            rigidbodyCache.velocity = new Vector3 (other.transform.position.x - transform.position.x, rigidbodyCache.velocity.y, rigidbodyCache.velocity.z);
            
        }
        
    }*/
    /*private IEnumerator ChasingPlayer(Collider other)
    {
        Debug.Log("Starting Coroutine " + other.name);
        yield return new WaitForSeconds(returnToThePostDelay);
        if (other.tag == "Player" && Vector3.Distance(other.transform.position,transform.position)-Random.Range(-detectionVariator,detectionVariator) > detectionRange)
        {

            isChasingPlayer = false;
            isReturningToPost = true;
            rigidbodyCache.velocity = new Vector3(spawningPoint.transform.position.x - transform.position.x, transform.position.y, transform.position.z);
        } else if (other.tag == "Player" && Vector3.Distance(other.transform.position, transform.position) - Random.Range(-detectionVariator, detectionVariator) <= detectionRange)
        {
            isChasingPlayer = true;
            isReturningToPost = false;
            rigidbodyCache.velocity = new Vector3(other.transform.position.x - transform.position.x, rigidbodyCache.velocity.y, rigidbodyCache.velocity.z);
        }
    }*/
    private void DetectPlayer()
    {

    }
    private void InitializeChasing(Collider other)
    {
        //Checking that we are in detection range but not to close to be able to attack
        if (CalcDistanceBetweenPlayerAndEnemy(other,detectionVariator) < detectionRange && !isAttackingPlayer)
        {
            //isChasingPlayer = true; Dont' think I need this bool parameter here.
            MoveTowardsTarget(other.gameObject);

        }
    }
    private void Attack()
    {
        Debug.Log("Kicking player's ass");
        isAttackingPlayer = true;
        //isChasingPlayer = false; prabably not needed.
    }
    private void ReturnToThePost()
    {
        MoveTowardsTarget(spawningPoint);
    }
    private float CalcDistanceBetweenPlayerAndEnemy(Collider other, float variator)
    {
        return Vector3.Distance(other.transform.position, transform.position) - Random.Range(-variator, variator);
    }
    private void MoveTowardsTarget(GameObject target)
    {
        rigidbodyCache.velocity = new Vector3(target.transform.position.x - transform.position.x, transform.position.y, transform.position.z);
    }
    private void StopMoving()
    {
        rigidbodyCache.velocity = Vector3.zero;
    }
    private IEnumerator KeepFollowingThePlayer(Collider target, float forHowLongToFollow)
    {
        Debug.Log("Target out of range, following");
        while (CalcDistanceBetweenPlayerAndEnemy(target,detectionVariator)<detectionRange && !isAttackingPlayer) //problems: if we managed to catch player and are in attack range, this coroutine is going to make us return to the post.
        {
            MoveTowardsTarget(target.gameObject);
            yield return new WaitForSeconds(forHowLongToFollow);
        }
        yield return new WaitForSeconds(forHowLongToFollow);
        ReturnToThePost();
    }
}
