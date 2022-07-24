using UnityEditor;
using UnityEngine;

public class MakeCustomMaterials : ScriptableObject
{
    [MenuItem("Tools/Crazy/CustomMaterializer")]
    static void DoIt()
    {
        GameObject[] data = Selection.gameObjects;
        if(data.Length == 0)
        {
            EditorUtility.DisplayDialog("CustomMaterializer", "Select 1 game object to begin!", "OK");
            return;
        }
        Material source = data[0].GetComponent<Renderer>().sharedMaterial;
        if (source != null)
        {
            if (EditorUtility.DisplayDialog("CustomMaterializer", "Are you sure about that?", "Yes", "No"))
            {
                Material mat = new Material(source);
                mat.name = source.name + "-changed";
                string s = string.Empty;
                foreach (GameObject item in data)
                {
                    s += $"-{item.name}\n";
                    item.GetComponent<Renderer>().material=mat;
                }
                Debug.Log("Finished\n"+s);
            }
            else
            {
                Debug.LogWarning("Canceled");
            }
        }
        else
        {
            Debug.LogWarning("Not detected material on " + data[0].name);
        }
    }
}
