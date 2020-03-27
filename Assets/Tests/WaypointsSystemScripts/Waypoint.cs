
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;
    public float width = .5f;
   

    public Vector3 GetPosition()
    {
        return (transform.position);
    }
}
