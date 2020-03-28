using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    EnemyMovement enemyMovement;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();

    }

    private void Start()
    {
        enemyMovement.MoveTowardsTarget(currentWaypoint.gameObject);
    }
    private void Update()
    {
        if (enemyMovement.CheckIfReachedDestination(currentWaypoint.gameObject))
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            enemyMovement.MoveTowardsTarget(currentWaypoint.gameObject);
            //now we just need to implement this into the main scene and check how it works with current enemies scripts.
        }
    }
}
