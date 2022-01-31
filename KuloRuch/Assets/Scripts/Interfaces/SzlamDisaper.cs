using UnityEngine;


public class SzlamDisaper : MonoBehaviour, IClick
{

    public GameObject ToxicSzlam;

    public void Click()
    {
        ToxicSzlam.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
