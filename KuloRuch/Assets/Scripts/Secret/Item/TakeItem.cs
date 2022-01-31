using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    public ItemPrefab prefab;
    public Image image;
    public Text descriptionText;
    [HideInInspector] public GameObject @object;
    public void Found()
    {
        @object.SetActive(true);
        switch (image.gameObject.activeSelf)
        {
            case true:
                image.sprite = prefab.artWork;
                descriptionText.text = prefab.Description;
                break;
            case false:
                image.gameObject.SetActive(true);
                image.sprite = prefab.artWork;
                descriptionText.text = prefab.Description;
                break;
        }
        Destroy(gameObject, .2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Found();
        }
    }
}
