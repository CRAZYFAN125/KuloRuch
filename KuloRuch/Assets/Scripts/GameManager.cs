using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Rigidbody rb;
    public float Force = 5;

    private void Awake()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    public void ResetLevel()
    {
        string Name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Name);
    }
    public void MovePlayer(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            Vector2 vector2 = callback.ReadValue<Vector2>();
            rb.AddForce(vector2.x * Force, 0, vector2.y*Force, ForceMode.Force);
        }
    }
}
