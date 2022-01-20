using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] public Transform tpPoint;

    public int tpIndex = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tpIndex = 0;
            StartCoroutine(TeleportObject(collision.gameObject));
        }
    }

    IEnumerator TeleportObject(GameObject gameObject)
    {
        tpPoint.gameObject.SetActive(true);
        gameObject.transform.position = tpPoint.position;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        while(tpIndex <= 5)
        {
            tpPoint.localScale += new Vector3(.5f, .5f, .5f);
            tpIndex++;
            yield return new WaitForSeconds(.5f);
        }
        while (tpIndex>0)
        {
            tpPoint.localScale -= new Vector3(.5f, .5f, .5f);
            tpIndex--;
            yield return new WaitForSeconds(.5f);
        }
        tpPoint.gameObject.SetActive(false);
    }
}
