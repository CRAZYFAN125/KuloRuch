using UnityEngine;

class GameButtonScript : MonoBehaviour
{
    private IClick[] OnClickEvents;

    private void Start()
    {
        OnClickEvents = gameObject.GetComponents<IClick>();
        if (OnClickEvents.Length==0)
        {
            Destroy(this);
            return;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Methods.CheckForPlayer(collision))
        {
            foreach(IClick OnClickEvent in OnClickEvents)
                OnClickEvent.Click();
        }
    }
}

