using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectAdderEditorWindow : EditorWindow
{
    bool ShowInstruction = false;
    GameObject objectToSpawn;
    Vector3 offset;
    Vector3 scale = new Vector3(1,1,1);
    int ObjectsPerOne = 2;
    static List<GameObject> madeObjects;
    string objects;

    enum Axis
    {
        x,y,z
    }

    Axis axis;

    [MenuItem("Tools/Crazy/Object Adding System")]
    public static void ShowOnGUI()
    {
        madeObjects = new List<GameObject>();
        GetWindow<ObjectAdderEditorWindow>("OBJ Adding System");
    }
    private void OnGUI()
    {
        ShowInstruction = EditorGUILayout.ToggleLeft("Show Tutorial", ShowInstruction);
        if (ShowInstruction)
        {
            GUILayout.Label("First, you have to assign fields below,\nthen you need to select objects what you want to add objects,\nnext it's only press button.");
        }
        if (madeObjects.Count==0)
        {
            objectToSpawn = (GameObject)EditorGUILayout.ObjectField(objectToSpawn, typeof(GameObject),false);
            if (objectToSpawn == null)
            {
                return;
            }

            ObjectsPerOne=EditorGUILayout.IntField("Objects Per One Selected",ObjectsPerOne);
            offset=EditorGUILayout.Vector3Field("Offset",offset);
            scale = EditorGUILayout.Vector3Field("Scale", scale);
            axis = (Axis)EditorGUILayout.EnumPopup("Up axis", axis);

            if (Selection.objects.Length ==0)
            {
                GUILayout.Label("Select Object in scene to continue!");
                return;
            }
            if (GUILayout.Button("Add Objects"))
            {
                foreach (GameObject item in Selection.gameObjects)
                {
                    for (int i = 0; i < ObjectsPerOne; i++)
                    {
                        GameObject @object = Instantiate(objectToSpawn, item.transform);
                        madeObjects.Add(@object);
                        @object.transform.localScale = scale;

                        SetPosition(@object,item);
                    }
                }
                foreach (GameObject item in madeObjects)
                {
                    objects += item.name + "\n";
                }
            }
        }
        else
        {
            GUILayout.Label($"Made {madeObjects.Count} objects:\n{objects}");
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Delete objects"))
            {
                foreach (GameObject item in madeObjects)
                {
                    DestroyImmediate(item.gameObject);
                }
                madeObjects.Clear();
                objects = string.Empty;
            }
            if (GUILayout.Button("End&Save"))
            {
                madeObjects.Clear();
                objects = string.Empty;
            }
            GUILayout.EndHorizontal();
        }
        
    }
    void SetPosition(GameObject @object,GameObject item)
    {
        switch (axis)
        {
            case Axis.x:
                @object.transform.localPosition = new Vector3( item.transform.position.x, Random.Range(-item.transform.localScale.y / 2, item.transform.localScale.y / 2), Random.Range(-item.transform.localScale.z / 2, item.transform.localScale.z / 2));
                break;
            case Axis.y:
                @object.transform.localPosition = new Vector3(Random.Range(-item.transform.localScale.x / 2, item.transform.localScale.x / 2), item.transform.position.y, Random.Range(-item.transform.localScale.z / 2, item.transform.localScale.z / 2));
                break;
            case Axis.z:
                @object.transform.localPosition = new Vector3(Random.Range(-item.transform.localScale.x / 2, item.transform.localScale.x / 2), Random.Range(-item.transform.localScale.y / 2, item.transform.localScale.y / 2), item.transform.position.z);
                break;
        }
    }
}
