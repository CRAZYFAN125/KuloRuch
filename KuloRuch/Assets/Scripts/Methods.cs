using UnityEngine;


public class Methods : MonoBehaviour
{
    public static bool CheckForPlayer(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}