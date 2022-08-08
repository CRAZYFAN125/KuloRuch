using UnityEngine;

[RequireComponent(typeof(Counter))]
public class SummonSomething : MonoBehaviour, ICounterEnd
{
    public Transform summonPoint;
    public GameObject Instance;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void OnEnd()
    {
        Instantiate(Instance, summonPoint.position, Quaternion.identity);
    }
}
