using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterClick : MonoBehaviour,IClick
{
    [SerializeField] float Time = 0f;
    public void Click()
    {
        Destroy(gameObject,Time);
    }
}
