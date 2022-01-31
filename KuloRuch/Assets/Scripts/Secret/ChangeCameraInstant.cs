using UnityEngine;

namespace Crazy.CameraCode
{
    public class ChangeCameraInstant : MonoBehaviour
    {
        public int index;
        public ChangeCamera changeCamera;

        private void Start()
        {
            if (changeCamera != null)
            {
                changeCamera = ChangeCamera.instance;
                if (changeCamera == null)
                {
                    Destroy(this);
                }
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                changeCamera.ChangeCameras(index);
            }
        }
    }
}
