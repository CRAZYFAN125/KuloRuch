using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public ParticleSystem particle;
    public Animator animator;
    public GameObject Part;
    public Transform spawnPoint;
    public GameObject ChestLight;
    [Header("Loot")]
    public ItemPrefab itemPrefab;
    public Image image;
    public Text text;
    public GameObject ButtonToDeactive;
    private bool isTaken = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&!isTaken)
        {
            animator.SetTrigger("Opening");
            particle.Play();
            ChestLight.SetActive(true);
            if (Part != null)
            {
                GameObject g = Instantiate(Part, spawnPoint.position, Quaternion.identity);
                text.gameObject.SetActive(true);
                g.GetComponent<TakeItem>().prefab = itemPrefab;
                g.GetComponent<TakeItem>().image = image;
                g.GetComponent<TakeItem>().descriptionText = text;
                g.GetComponent<TakeItem>().@object = ButtonToDeactive;
                isTaken = true;
            }
        }
    }


}
