using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float strikeRange = 2f;
    private RaycastHit hit;
    private void Update()
    {
        int layerMask = 1 << 10;
        if (Input.GetButtonDown("Slash"))
        {
           if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, strikeRange, layerMask))
            {
                
                hit.collider.gameObject.GetComponent<Enemy>().Death();
            }
        }
    }
}
