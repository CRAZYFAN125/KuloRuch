using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crazy.EnemyMemory
{
    [RequireComponent(typeof(EnemyScript))]
    public class OdchwaszczaczScript : MonoBehaviour, IEnemy
    {
        public void OnPlayerDetect(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.Instance.ResetLevel();
            }
        }
    }
}
