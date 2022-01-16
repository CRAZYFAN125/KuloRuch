using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPortal : MonoBehaviour
{
    public string gameName = "Gra";

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            SceneManager.LoadSceneAsync(gameName);
        }
    }
}
