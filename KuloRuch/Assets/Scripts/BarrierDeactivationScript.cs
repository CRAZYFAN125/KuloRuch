using System.Collections;
using UnityEngine;

public class BarrierDeactivationScript : MonoBehaviour
{
    public GameObject[] barriers;
    public int targetLight = 2;
    Color NormalColor;
    [ColorUsage(false, true)] public Color DeactivationColor;
    [SerializeField] private bool isSwitch = false;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DeactiveBarrier());
        }
    }
    IEnumerator DeactiveBarrier()
    {
        if (isSwitch)
        {
            foreach (GameObject barrier in barriers)
            {
                int x = 0;
                Renderer rend = barrier.GetComponent<Renderer>();
                NormalColor = rend.material.GetColor("_mainColor");

                while (x < targetLight)
                {

                    rend.material.SetColor("_mainColor", Color.Lerp(NormalColor, DeactivationColor, 50f));

                    x++;
                    yield return new WaitForSeconds(.5f);
                }
                barrier.SetActive(!barrier.activeSelf);
            }
        }
        else
        {
            foreach (GameObject barrier in barriers)
            {
                int x = 0;
                Renderer rend = barrier.GetComponent<Renderer>();
                NormalColor = rend.material.GetColor("_mainColor");

                while (x < targetLight)
                {

                    rend.material.SetColor("_mainColor", Color.Lerp(NormalColor, DeactivationColor, 50f));

                    x++;
                    yield return new WaitForSeconds(.5f);
                }
                barrier.SetActive(false);
            }
        }
    }
}
