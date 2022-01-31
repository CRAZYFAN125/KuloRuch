using UnityEngine;

class GameButtonScript : MonoBehaviour
{
    [SerializeField]public IClick OnClickEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            OnClickEvent.Click();
        }
    }
}

