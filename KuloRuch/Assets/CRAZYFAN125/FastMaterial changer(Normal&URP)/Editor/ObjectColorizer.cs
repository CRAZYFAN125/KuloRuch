using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectColorizer : EditorWindow
{
    Material mat;
    bool getChilds = false;

    [MenuItem("Tools/Crazy/Material Changer")]
    static void ShowWindow()
    {
        GetWindow<ObjectColorizer>("Material Changer");
    }
    private void OnGUI()
    {
        mat = (Material)EditorGUILayout.ObjectField(mat,typeof(Material), false);
        if (mat==null)
        {
            GUILayout.Label("Select material!");
            return;
        }
        if (Selection.objects.Length!=0)
        {
            GUILayout.Label("If child have \"!\" in front of name it won't have changed Material");
            getChilds = EditorGUILayout.Toggle("Change material in childs",getChilds);
            if (GUILayout.Button("Remat objects"))
            {
                foreach (GameObject item in Selection.objects)
                {
                    if (getChilds&&item.transform.childCount>0)
                    {
                        ChangeMatInChilds(item.transform);
                    }
                    Renderer renderer = item.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.material = mat;
                        }
                }
            }
        }
        else
        {
            GUILayout.Label("Select Objects!");
        }
    }
    void ChangeMatInChilds(Transform item)
    {
        List<int> childIndexes = new List<int>();
        for (int i = 0; i < item.transform.childCount; i++)
        {
            char[] letters = item.transform.GetChild(i).name.ToCharArray();
            if (letters[0].ToString() == "!") { Debug.Log(item.GetChild(i).name + " has been skipped"); if (item.GetChild(i).childCount > 0) childIndexes.Add(i); }
            else
            {
                Renderer rendererCh = item.transform.GetChild(i).GetComponent<Renderer>();
                if (rendererCh != null)
                {
                    rendererCh.material = mat;
                }
                if (item.GetChild(i).childCount > 0) childIndexes.Add(i);
            }
        }
        for (int i = 0; i < childIndexes.Count; i++)
        {
            ChangeMatInChilds(item.GetChild(i));
        }
    }
}
