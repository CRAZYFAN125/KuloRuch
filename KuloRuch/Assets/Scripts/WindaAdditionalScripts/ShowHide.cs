using UnityEngine;

namespace Crazy.WindaAdds
{
    [RequireComponent(typeof(Winda))]
    public class ShowHide : MonoBehaviour, IWindaAdd
    {
        [SerializeField] private SetCameraOnWinda.CameraChangeOn When;
        public Material startMaterial;
        public Material endMaterial;

        [SerializeField] private MeshRenderer[] renderers;
        public void OnStart()
        {
            if (renderers.Length >= 0)
            {
                if (When == (SetCameraOnWinda.CameraChangeOn)1 || When == (SetCameraOnWinda.CameraChangeOn)3)
                {
                    foreach (MeshRenderer item in renderers)
                    {
                        item.material = endMaterial;
                    }
                }

            }
        }

        public void OnStop()
        {
            if (renderers.Length >= 0)
            {
                if (When == (SetCameraOnWinda.CameraChangeOn)2 || When == (SetCameraOnWinda.CameraChangeOn)3)
                {
                    foreach (MeshRenderer item in renderers)
                    {
                        item.material = endMaterial;
                    }
                }

            }
        }

        public void OnUpdate()
        {

        }
        private void Start()
        {
            if (renderers.Length == 0)
            {
                Destroy(this);
                return;
            }
            foreach (MeshRenderer item in renderers)
            {
                item.material = startMaterial;
            }
        }
    }
}