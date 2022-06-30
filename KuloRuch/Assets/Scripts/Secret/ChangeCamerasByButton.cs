using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crazy.CameraCode {
    public class ChangeCamerasByButton : MonoBehaviour
    {
        private ChangeCamera cameraC;
        private GameManager manager;
        [SerializeField] GameObject Panel;
        bool isPanel = false;

        private void Start()
        {
            cameraC = ChangeCamera.instance;
            manager = GameManager.Instance;
        }
        public void ChangeAnCamera()
        {
            cameraC.ChangeCameras();
        }
        public void SendResetGameRequest()
        {
            manager.ResetLevel();
        }

        public void OpenPanel()
        {
            if (!isPanel)
            {
                isPanel = true;
                Panel.SetActive(isPanel);
                Time.timeScale = .05f;
            }
            else
            {
                isPanel = false;
                Panel.SetActive(isPanel);
                Time.timeScale = 1f;
            }
        }
        public void CloseGame()
        {
            GameManager.Instance.SaveForExit(true);
        }
    } 
}
