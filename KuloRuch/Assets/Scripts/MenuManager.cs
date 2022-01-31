using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region Function Main
    public Text loadingText;
    public void LoadLevel(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        StartCoroutine(loadTextAsync(operation));
    }
    public void LoadLevel(string index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        if (loadingText != null)
        {
            StartCoroutine(loadTextAsync(operation));
        }

    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator loadTextAsync(AsyncOperation operation)
    {
        while (!operation.isDone)
        {
            loadingText.text = string.Format("Kulo Ruch- loading:{0}", Mathf.Floor(operation.progress / .9f));
            yield return null;
        }
    }
    #endregion

    #region InputSystem

    public void Play(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            LoadLevel("Game");
        }
    }
    public void Exit(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            ExitGame();
        }
    }

    #endregion
}
