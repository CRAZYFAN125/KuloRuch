using UnityEngine;

namespace Crazy.WindaAdds
{
    [RequireComponent(typeof(Winda))]
    public class ShowHide : MonoBehaviour, IWindaAdd
    {
        public Material startMaterial;
        public Material endMaterial;

        [SerializeField] private MeshRenderer[] renderers;
        public void OnStart()
        {
            if(renderers.Length >= 0)
            {
                foreach (MeshRenderer item in renderers)
                {
                    item.material = endMaterial;
                }
            }
        }

        public void OnStop()
        {

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