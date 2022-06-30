using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    #region Function Main
    public Text loadingText;
    public Button play;
    public GameObject levelScreen;
    public GameObject levelPrefab;
    public Transform levelPrefabsParent;
    public string[] scenes;

    private void Start()
    {
        if (!Crazy.Events.CustomEventSystem.IsEvent)
        {
            
            int x = 0;

            if (System.IO.File.Exists(Application.persistentDataPath + "/save.cdat"))
            {
                string data = System.IO.File.ReadAllText(Application.persistentDataPath + "/save.cdat");
                GameManager.Save s = JsonUtility.FromJson<GameManager.Save>(data);
                char[] ss = s.Scene.ToCharArray();
                string xxxx = string.Empty;
                foreach (char item in ss)
                {
                    switch (item)
                    {
                        case '1':
                            xxxx += '1';
                            break;
                        case '2':
                            xxxx += '2';
                            break;
                        case '3':
                            xxxx += '3';
                            break;
                        case '4':
                            xxxx += '4';
                            break;
                        case '5':
                            xxxx += '5';
                            break;
                        case '6':
                            xxxx += '6';
                            break;
                        case '7':
                            xxxx += '7';
                            break;
                        case '8':
                            xxxx += '8';
                            break;
                        case '9':
                            xxxx += '9';
                            break;
                        case '0':
                            xxxx += '0';
                            break;
                        default:
                            xxxx += '0';
                            break;
                    }
                }
                x = int.Parse(xxxx);
            }

            print(x);
            for (int i = 0; i < scenes.Length; i++)
            {
                int ii = i + 1;
                GameObject g = Instantiate(levelPrefab, levelPrefabsParent);
                g.GetComponent<Button>().onClick.RemoveAllListeners();
                g.GetComponent<Button>().onClick.AddListener(() =>
                {
                    AsyncOperation operation = SceneManager.LoadSceneAsync(ii);
                });
                if (i < x)
                {
                    g.GetComponent<Button>().interactable = true;
                }
                Text text = g.transform.Find("Text").gameObject.GetComponent<Text>();
                text.text = "" + (ii);
                g.SetActive(true);
                print($"{ii} | {scenes[ii-1]}");



            }
        }
    }

    public void ShowLevelsList()
    {
        levelScreen.SetActive(true);
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
        if (!System.IO.File.Exists(Application.dataPath + "/save.cdat") || sceneName != "SampleScene")
        {
            return;
        }
        if (play == null)
        {
            Debug.LogError("Play button is not setted corectly, check and repair!");
            return;
        }
        GameManager.Save save = JsonUtility.FromJson<GameManager.Save>(System.IO.File.ReadAllText(Application.dataPath + "/save.cdat"));
        play.onClick.RemoveAllListeners();
        play.onClick.AddListener(() => LoadLevel(save.Scene));
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
