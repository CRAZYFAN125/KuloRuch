using UnityEngine;

class GameButtonScript : MonoBehaviour
{
    [SerializeField]public IClick OnClickEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            OnClickEvent.Click();
        }
    }
}

