using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.RemoteConfig;

public class MenuManager : MonoBehaviour
{
    
    #region Function Main
    public Text loadingText;
    public Button play;
    private void Start()
    {
        if (!Crazy.Events.CustomEventSystem.IsEvent)
        {
            LoadLevel();
        }
    }
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

    #region Function Secondary
    void LoadLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (!System.IO.File.Exists(Application.dataPath+"/save.cdat")|| sceneName != "SampleScene")
        {
            return;
        }
        if (play == null)
        {
            Debug.LogError("Play button is not setted corectly, check and repair!");
            return;
        }
        GameManager.Save save = JsonUtility.FromJson<GameManager.Save>(System.IO.File.ReadAllText(Application.dataPath+"/save.cdat"));
        play.onClick.RemoveAllListeners();
        play.onClick.AddListener(()=>LoadLevel(save.Scene));
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
