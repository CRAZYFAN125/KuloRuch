using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeActive : MonoBehaviour
{
    public Behaviour[] behaviours;
    public GameObject[] gameObjects;
    bool bH = false;
    bool gO = false;
    // Start is called before the first frame update
    void Start()
    {
        if (behaviours.Length>0)
        {
            bH = true;
        }
        if (gameObjects.Length>0)
        {
            gO = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (bH)
        {
            foreach (Behaviour item in behaviours)
            {
                item.enabled = !item.enabled;
            }
        }
        if (gO)
        {
            foreach (GameObject item in gameObjects)
            {
                item.SetActive(!item.activeSelf);
            }
        }
    }
}
