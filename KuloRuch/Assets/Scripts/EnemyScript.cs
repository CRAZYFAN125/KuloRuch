using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    IEnemy enemySourceScript;
    public float moveTime = 4;
    [SerializeField]private Transform[] movePoints;
    private int pointIndex = 0;
    private float procentOfRoad = 0;
    [SerializeField] float minProcentComplete=.9f;
    float tNow;
    private void Start()
    {
        enemySourceScript = GetComponent<IEnemy>();
        if (enemySourceScript==null)
        {
            Debug.LogWarning("There is no methods script attached! Repair it!");
            Destroy(gameObject);
            return;
        }
        if (movePoints.Length==0)
        {
            Debug.LogWarning("There is no Points to move! Repair it!");
            Destroy(gameObject);
            return;
        }
    }

    public void Update()
    {
        tNow += Time.deltaTime;
        procentOfRoad = tNow/moveTime;
        procentOfRoad=Mathf.SmoothStep(0,1,procentOfRoad);

        transform.position = Vector3.Lerp(transform.position,movePoints[pointIndex].position,procentOfRoad);


        if (procentOfRoad>=minProcentComplete)
        {
            pointIndex++;
            tNow = 0;
        }
        if (pointIndex == movePoints.Length)
        {
            pointIndex = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        enemySourceScript.OnPlayerDetect(collision);
    }

    private void OnDrawGizmosSelected()
    {
        if (movePoints.Length>1)
        {
            Gizmos.color = Color.red;
            
            for (int i = 0; i < movePoints.Length-1; i++)
            {
                    Gizmos.DrawLine(movePoints[i].position, movePoints[i + 1].position);
            }


            Gizmos.color= Color.green;
            Gizmos.DrawWireCube(movePoints[0].position,new Vector3(.1f,.1f,.1f));
            Gizmos.DrawWireSphere(movePoints[movePoints.Length - 1].position, .1f);
            Gizmos.DrawLine(movePoints[movePoints.Length-1].position, movePoints[0].position);
        }
    }
}
