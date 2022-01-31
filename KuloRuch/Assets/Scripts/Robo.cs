using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Robo : MonoBehaviour
{
    public Transform Player;
    public GameManager manager;
    private PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        manager=GameManager.Instance;
        input = manager.GetComponent<PlayerInput>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            ActiveHelmet();
        }
    }
    #region CoreFunctions
    private void ActiveHelmet()
    {
        input.SwitchCurrentControlScheme("Mech", input.devices.ToArray());
    }

    #endregion

}
