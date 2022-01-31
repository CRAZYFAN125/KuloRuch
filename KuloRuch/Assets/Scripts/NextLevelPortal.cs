using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPortal : MonoBehaviour
{
    public string gameName = "Game";
    [SerializeField] private bool unLockCursor = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            if (unLockCursor)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            SceneManager.LoadSceneAsync(gameName);
        }
    }
}
