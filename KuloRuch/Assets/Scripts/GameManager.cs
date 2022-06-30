using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Unity.RemoteConfig;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool canBeUsed = true;
    public Rigidbody rb;
    public float Force = 5;
    public List<Transform> ads;
    [SerializeField] private float HowDeepToReset = -15f;
    [SerializeField] private bool checkGieniekSpeed = false;
    [HideInInspector] public float GSpeed { get; private set; } = 2f;

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
        if (Instance!=null)
        {
            Destroy(this);
        }
        Instance = this;
        ads = new List<Transform>();
    }

    void CheckForUpdate(ConfigResponse response)
    {
        if (response.requestOrigin == ConfigOrigin.Remote)
        {
            Force = ConfigManager.appConfig.GetFloat("PlayerRBForce");
            if (checkGieniekSpeed)
            {
                GSpeed = ConfigManager.appConfig.GetFloat("GieniekSpeed");
            }
        }
    }

    private void FixedUpdate()
    {
        MoveAds();
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

    private void OnApplicationQuit()
    {
        try
        {
            Save save = new Save();
            save.Scene = SceneManager.GetActiveScene().name;
            string data = JsonUtility.ToJson(save);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/save.cdat", data);
            Debug.Log("Saved\n\""+data+$"\"\n{Application.persistentDataPath+"/save.cdat"}");
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
