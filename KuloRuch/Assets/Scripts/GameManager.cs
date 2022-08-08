using System.Collections.Generic;
using System.IO;
using Unity.RemoteConfig;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool canBeUsed = true;
    public Rigidbody rb;
    public float Force = 5;
    public List<Transform> ads;
    [SerializeField] private float HowDeepToReset = -15f;
    [HideInInspector] public float Deep;
    [SerializeField] private bool checkGieniekSpeed = false;
    [SerializeField] float MinMaxPlayerSpeed = 50f;
    [HideInInspector] public float GSpeed { get; private set; } = 2f;

    [Header("Gamerules")]
    [SerializeField] private GameObject[] /*gamerule_*/NonWindas;
    string GameruleFilePath = "/../gamerule.overwrite";
    private void Start()
    {
        GameruleFilePath = Application.dataPath + GameruleFilePath;

        if (File.Exists(GameruleFilePath))
        {
            string[] rulesOverwrites = File.ReadAllLines(GameruleFilePath);
            if (rulesOverwrites.Length==0)
            {
                Debug.LogWarning($"There is empty gamerules file in {GameruleFilePath}");
                return;
            }
            foreach (string item in rulesOverwrites)
            {
                if (item == "-NonWindas-" && NonWindas.Length > 0)
                {
                    foreach (GameObject @object in NonWindas)
                    {
                        @object.SetActive(true);
                    }
                    Debug.LogWarning($"Rule {item} has been activated, all elevators will be changed!\nIf you don't want it just delete rule at {item} in \"{GameruleFilePath}\".");
                }
                if (item == "-NonWindas-" && NonWindas.Length == 0)
                {
                    Winda[] Windas = FindObjectsOfType<Winda>();
                    if (Windas.Length != 0)
                    {
                        foreach (Winda winda in Windas)
                        {
                            winda.StartCoroutine(winda.Windowanie());
                        }
                    }
                    Debug.LogWarning($"Rule {item} has been activated, all elevators will be changed!\nIf you don't want it just delete rule at {item} in \"{GameruleFilePath}\".");
                }
            }
        }
    }

    struct userAttributes
    {

    }
    struct appAttributes
    {

    }

    public class Save
    {
        public string Scene = "Game";
    }

    private void Awake()
    {
        ConfigManager.FetchCompleted += CheckForUpdate;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        ads = new List<Transform>();
        Deep = HowDeepToReset;
    }

    void CheckForUpdate(ConfigResponse response)
    {
        if (response.requestOrigin == ConfigOrigin.Remote)
        {
            Force = ConfigManager.appConfig.GetFloat("PlayerRBForce");
            MinMaxPlayerSpeed = ConfigManager.appConfig.GetFloat("MinMaxPlayerSpeed");
            if (checkGieniekSpeed)
            {
                GSpeed = ConfigManager.appConfig.GetFloat("GieniekSpeed");
            }
        }
    }

    private void FixedUpdate()
    {
        MoveAds();
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -MinMaxPlayerSpeed, MinMaxPlayerSpeed), Mathf.Clamp(rb.velocity.y, -MinMaxPlayerSpeed, MinMaxPlayerSpeed), Mathf.Clamp(rb.velocity.z, -MinMaxPlayerSpeed, MinMaxPlayerSpeed));
        if (rb.position.y <= HowDeepToReset)
        {
            ResetLevel();
        }
    }

    public void InputChangeCameras(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            ChangeCamera.instance.ChangeCameras();
        }
    }

    public void InputHideOrShowCursor(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            switch (Cursor.lockState)
            {
                case CursorLockMode.None:
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                case CursorLockMode.Locked:
                    Cursor.lockState = CursorLockMode.None;
                    break;
            }
        }
    }
    public void ResetLevelFromInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {

        string Name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Name);

    }
    public void MovePlayer(InputAction.CallbackContext callback)
    {
        if (callback.performed && canBeUsed)
        {
            Vector2 vector2 = callback.ReadValue<Vector2>();
            rb.AddForce(vector2.x * Force, 0, vector2.y * Force, ForceMode.Force);
        }
    }
    private void MoveAds()
    {
        if (ads.Count > 0)
        {
            foreach (Transform item in ads)
            {
                item.position = rb.position;
            }
        }

    }


    public void SaveForExit()
    {
        try
        {
            Save save = new Save();
            save.Scene = SceneManager.GetActiveScene().name;
            string data = JsonUtility.ToJson(save);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/save.cdat", data);
            Debug.Log("Saved\n\"" + data + $"\"\n{Application.persistentDataPath + "/save.cdat"}");
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
    public void SaveForExit(bool CloseAfterSave)
    {
        try
        {
            int x;
            Save save;
            if (System.IO.File.Exists(Application.persistentDataPath + "/save.cdat"))
            {
                save = JsonUtility.FromJson<Save>(System.IO.File.ReadAllText(Application.persistentDataPath + "/save.cdat"));
                char[] ss = save.Scene.ToCharArray();
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

                xxxx = string.Empty;

                foreach (char item in SceneManager.GetActiveScene().name.ToCharArray())
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
                int y = int.Parse(xxxx);
                if (y > x)
                {
                    save.Scene = SceneManager.GetActiveScene().name;
                }
            }
            else
            {
                save = new Save();
                save.Scene = SceneManager.GetActiveScene().name;
            }
            string data = JsonUtility.ToJson(save);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/save.cdat", data);
            Debug.Log("Saved\n\"" + data + $"\"\n{Application.persistentDataPath + "/save.cdat"}");
            if (CloseAfterSave)
                Application.Quit();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    private void OnApplicationQuit()
    {
        SaveForExit();
    }
}
