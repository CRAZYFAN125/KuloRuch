using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Robo : MonoBehaviour
{
    public Transform Player;
    public GameManager manager;
    private PlayerInput inputN;
    private Rigidbody rb;
    [SerializeField] private PlayerInput inputH;
    public float JumpForce = 2f;
    public float RotateSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        manager= GameManager.Instance;
        inputN = manager.GetComponent<PlayerInput>();
        rb = Player.GetComponent<Rigidbody>();
        inputH.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            ActiveHelmet();
            GetComponent<Collider>().enabled = false;
            manager.ads.Add(transform);
        }
    }
    #region CoreFunctions
    private void ActiveHelmet()
    {
        inputN.enabled = false;
        inputH.enabled = true;
    }

    Vector3 rotation;
    private void FixedUpdate()
    {
        transform.Rotate(rotation*Time.fixedDeltaTime*RotateSpeed,Space.World);
    }

    #region Input data
    public void Jump(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            Vector3 vector = transform.forward * 2;
            vector.y = JumpForce;
            rb.AddForce(vector, ForceMode.Impulse);
        }
    }
    public void Rotate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rotation.y = context.ReadValue<float>();
        }
        else if (context.canceled)
        {

            rotation = Vector3.zero;
        }
    }
    public void ExitMe(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            inputH.enabled=false;
            inputN.enabled = true;
            rb.AddForce(0,JumpForce*1.5f,0, ForceMode.Impulse);
            manager.ads.Remove(transform);
            Destroy(gameObject);
            return;
        }
    }
    #endregion
    #endregion

}
