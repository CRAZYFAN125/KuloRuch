using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 20f;
    [SerializeField] string[] tags = { "Player" };
    private void Start()
    {
        //rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (string item in tags)
        {
            if (collision.gameObject.CompareTag(item))
            {
                rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                Vector3 x = transform.forward * force;
    
                rb.AddForce(x,ForceMode.VelocityChange);
                rb = null;
            }
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 x = transform.forward * force;
        x.y = 0;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,transform.forward*5);
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
