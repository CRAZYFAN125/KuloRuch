using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeCamera : MonoBehaviour
{
    public static ChangeCamera instance;
    public GameObject[] cameras;
    public int cameraIndex;

    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void ChangeCameras()
    {
        if (cameraIndex+1>cameras.Length-1)
        {
            cameras[cameraIndex].SetActive(false);
            cameraIndex = 0;
            cameras[cameraIndex].SetActive(true);
        }
        else
        {
            cameras[cameraIndex].SetActive(false);
            cameraIndex++;
            cameras[cameraIndex].SetActive(true);
        }
    }
    public void ChangeCameras(int _cameraIndex)
    {
        if (_cameraIndex > 0 && _cameraIndex < cameras.Length - 1&&_cameraIndex!=cameraIndex)
        {
            cameras[cameraIndex].SetActive(false);
            cameraIndex = _cameraIndex;
            cameras[cameraIndex].SetActive(true);
        }
    }
    
}
