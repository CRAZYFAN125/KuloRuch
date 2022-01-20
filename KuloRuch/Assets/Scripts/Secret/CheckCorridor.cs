using UnityEngine;


public class CheckCorridor : MonoBehaviour
{
    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Renderer[] renderers;

    private void Start()
    {
        foreach (Renderer item in renderers)
        {
            item.material = offMaterial;
        }
    }
    void Mat()
    {

        foreach (Renderer item in renderers)
        {
            item.material = onMaterial;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Mat();
        }

    }
}

