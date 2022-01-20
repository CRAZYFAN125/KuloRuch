using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Chest : MonoBehaviour
{
    public ParticleSystem particle;
    public Animator animator;
    public GameObject Part;
    public Transform spawnPoint;
    public GameObject ChestLight;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            animator.SetTrigger("Opening");
            particle.Play();
            ChestLight.SetActive(true);
            if (Part!=null)
            {
                Instantiate(Part, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
