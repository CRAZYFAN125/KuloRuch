using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipLevel : MonoBehaviour
{
    public void Skip(string SceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);
    }
}
