using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject spawningPoint;
    [SerializeField] float spawningPointDistanceLimit = 2f;
    [SerializeField] float attackRange = 1.5f;
    [SerializeField] float attackCoolDown = 3f;
    [SerializeField] float strikeForce = 3f;

    private bool isChasingPlayer = false;
    private bool isReturningToPost = false;
    private Rigidbody rigidbodyCache;
    private float rangeVariator = .5f, detectionVariator = .5f;
    private bool isAttackingPlayer = false;
    private float attackTimer;
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
            if (Time.timeSinceLevelLoad - attackTimer > attackCoolDown)
            {
                Attack(other);
            }
           
        } else if (other.tag == "Player" && CalcDistanceBetweenPlayerAndEnemy(other, rangeVariator)>=attackRange)
        {
            StopAttacking();
            InitializeChasing(other);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            StartCoroutine(KeepFollowingThePlayer(other, returnToThePostDelay));
        }
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
    private void Attack(Collider other)
    {
            Debug.Log("Kicking player's ass");

        other.gameObject.GetComponent<Rigidbody>().AddForce((other.gameObject.transform.position.x - transform.position.x) * strikeForce,1f,0f, ForceMode.Impulse );
            isAttackingPlayer = true;
            attackTimer = Time.timeSinceLevelLoad;
       
        //isChasingPlayer = false; prabably not needed.
    }
    private void StopAttacking()
    {
        Debug.Log("Stopping attacking the player!");
        isAttackingPlayer = false;
    }
    private void ReturnToThePost()
    {
        Debug.Log("Returning to the post");
        isReturningToPost = true;
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
        while (CalcDistanceBetweenPlayerAndEnemy(target,detectionVariator)<detectionRange && !isAttackingPlayer) 
        {
            MoveTowardsTarget(target.gameObject);
            yield return new WaitForSeconds(forHowLongToFollow);
        }
        if (!isAttackingPlayer)
        {
            StopMoving();
            yield return new WaitForSeconds(forHowLongToFollow);
            ReturnToThePost();
        }
    }
}
