using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Crazy.WindaAdds
{
    [RequireComponent(typeof(Winda))]
    public class SetCameraOnWinda : MonoBehaviour, IWindaAdd
    {
        public enum CameraChangeOn:short
        {
            Start = 1,
            Stop,
            StartAndStop
        }
        
        public CameraChangeOn cameraChangeOn;
        public int cameraIndex = 0;
        ChangeCamera manager;

        public void OnStart()
        {
            if (cameraChangeOn==CameraChangeOn.Start||cameraChangeOn==CameraChangeOn.StartAndStop)
            {
                manager.ChangeCameras(cameraIndex);
            }
        }

        public void OnStop()
        {
            if (cameraChangeOn == CameraChangeOn.Stop || cameraChangeOn == CameraChangeOn.StartAndStop)
            {
                manager.ChangeCameras(cameraIndex);
            }
        }

        public void OnUpdate()
        {

        }

        
        void Start()
        {
            manager = FindObjectOfType<ChangeCamera>();
        }
    }
}
