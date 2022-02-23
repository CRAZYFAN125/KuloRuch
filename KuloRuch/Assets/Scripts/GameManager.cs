using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool canBeUsed = true;
    public Rigidbody rb;
    public float Force = 5;
    public List<Transform> ads;

    private void Awake()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        if (Instance!=null)
        {
            Destroy(this);
        }
        Instance = this;
        ads = new List<Transform>();
    }

    private void FixedUpdate()
    {
        MoveAds();
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
}
