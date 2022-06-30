using UnityEngine;


public class InstantianateInstantByCollision : MonoBehaviour
{
    [System.Serializable]
    public class Dat
    {
        public GameObject Object;
        public Transform spawnPoint;
    }
    [SerializeField] Dat[] toInstantiate;
    [SerializeField] GameObject[] toActiveOrDisable;
    [SerializeField] string colliderTag;
    [SerializeField] int Uses = 1;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag==colliderTag&&Uses>0)
        {
            Uses--;
            if (toActiveOrDisable.Length>0)
            {
                foreach (GameObject item in toActiveOrDisable)
                {
                    item.SetActive(!item.activeSelf);
                }
            }
            foreach (Dat item in toInstantiate)
            {
                Instantiate(item.Object,item.spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
