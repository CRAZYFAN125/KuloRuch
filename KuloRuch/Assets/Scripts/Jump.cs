using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]Rigidbody rb;
    [SerializeField] float force = 20f;
    private void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            rb.velocity = Vector3.zero;
            Vector3 x = transform.forward * force;

            rb.AddForce(x,ForceMode.VelocityChange);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 x = transform.forward * force;
        x.y = 0;
        
        Gizmos.color = Color.yellow; 
        if (rb!=null)
        {
            Gizmos.DrawRay(transform.position, (x * force / rb.mass)/4);
        }
        else
        {
            Gizmos.DrawRay(transform.position, x * force / 4);
        }
    }
}
