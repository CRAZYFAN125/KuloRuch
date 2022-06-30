using System.Collections;
using UnityEngine;

namespace Assets.Scripts.IBarrierOffs
{
    public class GieniekRun : MonoBehaviour,IBarrierOff
    {
        [SerializeField] GameObject Gienek;
        [SerializeField] Transform SpawnPoint;
        bool spawned = false;
        public void Run()
        {
            if (!spawned)
                Instantiate(Gienek, SpawnPoint.position, Quaternion.identity);
            spawned = true;
        }
    }
}