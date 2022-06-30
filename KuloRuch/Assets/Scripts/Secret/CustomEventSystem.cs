using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Crazy.Events
{
    public class CustomEventSystem : MonoBehaviour
    {
        public Button StartButton;
        public string PrimaAprilisScene;
        public string A_0504_Scene;
        public string EasterScene;

        public static bool IsEvent = false;


        private void Awake()
        {
            OnEvent();
        }
        void OnEvent()
        {
            DateTime today = DateTime.Now;
            if (today.Month == 4 && today.Day == 5)
            {
                StartButton.onClick.RemoveAllListeners();
                StartButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(A_0504_Scene);
                });
                IsEvent = true;
            }
            if (today.Month == 4 && today.Day == 1)
            {
                StartButton.onClick.RemoveAllListeners();
                StartButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(PrimaAprilisScene);
                });
                IsEvent = true;
            }
            if (today.Month == 4 && today.Day > 7 && today.Day < 14)
            {
                StartButton.onClick.RemoveAllListeners();
                StartButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(EasterScene);
                });
                IsEvent = true;
            }
        }
    }
}