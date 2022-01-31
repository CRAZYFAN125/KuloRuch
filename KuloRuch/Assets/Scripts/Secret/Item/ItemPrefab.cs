using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 5)]
public class ItemPrefab : ScriptableObject
{
    public GameObject prefab;
    public Sprite artWork;
    [TextArea(10, 50)] public string Description;

    
}
