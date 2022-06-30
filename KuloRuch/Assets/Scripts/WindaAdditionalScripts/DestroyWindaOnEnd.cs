using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Crazy.WindaAdds
{
    [RequireComponent(typeof(Winda))]
    public class DestroyWindaOnEnd : MonoBehaviour, IWindaAdd
    {
        public void OnStart()
        {

        }

        public void OnStop()
        {
            Destroy(gameObject, 15);
        }

        public void OnUpdate()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
