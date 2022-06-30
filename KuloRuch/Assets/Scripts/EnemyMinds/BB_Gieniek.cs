using System.Collections;
using UnityEngine;

namespace Crazy.Gieniek.EnemyMind
{
    public class BB_Gieniek : MonoBehaviour
    {
        Transform target;
        Rigidbody rb;
        [SerializeField] Transform partToRotate;
        [SerializeField] float rotationSpeed;
        [SerializeField] float speed = 2f;
        // Use this for initialization
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            rb = GetComponent<Rigidbody>();
            speed = GameManager.Instance.GSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);

            
            rb.MovePosition(transform.position + (dir * Time.deltaTime * speed));
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.Instance.ResetLevel();
            }
        }
    }
}