using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crazy.CameraCode {
    public class ChangeCamerasByButton : MonoBehaviour
    {
        private ChangeCamera cameraC;
        private void Start()
        {
            cameraC = ChangeCamera.instance;
        }
        public void ChangeAnCamera()
        {
            cameraC.ChangeCameras();
        }
    } 
}
