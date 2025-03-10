﻿/* 
 * About:
 * Tool to easily change selected gameobject's material all in one go
 * 
 * TODO: 
 * 1. Add display selected object names in a textbox
 * 
 */

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class ChangeMaterialsInScene : EditorWindow
{
    Material m;
    bool changeChild;

    int prevselectedcount = 0;
    Transform[] selectedobj;

    [MenuItem("Tools/GameObject/Change Selected Object Material")]
    public static void ShowWindow()
    {
        var window = GetWindow<ChangeMaterialsInScene>("Change Selected Object Material");
        window.Show();
        window.Focus();
        window.Repaint();
    }

    void Update()
    {
        selectedobj = Selection.transforms;
        if (selectedobj.Length != prevselectedcount)
        {
            Focus();
        }
    }

    void OnGUI()
    {
        prevselectedcount = selectedobj.Length;
        if (selectedobj.Length == 0)
        {
            EditorGUILayout.TextField("Please Select Object in Scene");
            return;
        }
        GUILayout.BeginVertical();
        {
            changeChild = EditorGUILayout.Toggle("Change Child?", changeChild);

            m = (Material)EditorGUILayout.ObjectField(m, typeof(Material), true);

            if (GUILayout.Button("Change Material")) // when this button is clicked
            {
                if (changeChild)
                {
                    foreach (Transform parentObject in selectedobj)
                    {
                        MeshRenderer[] children;
                        children = parentObject.GetComponentsInChildren<MeshRenderer>(); // get all children's renderer component

                        foreach (MeshRenderer rend in children)
                        {
                            Material[] mats = new Material[rend.sharedMaterials.Length];
                            for (int j = 0; j < rend.sharedMaterials.Length; j++) // for each material in each children component, change
                            {
                                mats[j] = m;
                            }
                            Undo.RecordObject(rend, "Changed Material");
                            rend.sharedMaterials = mats;
                        }
                    }
                }
                else
                {
                    foreach (Transform parentObject in selectedobj)
                    {
                        MeshRenderer parent = parentObject.GetComponent<MeshRenderer>();
                        Material[] mats = new Material[parent.sharedMaterials.Length];
                        if (parent == null) return;
                        for (var j = 0; j < parent.sharedMaterials.Length; j++)
                        {
                            mats[j] = m;
                        }
                        Undo.RecordObject(parent, "Changed Material");
                        parent.sharedMaterials = mats;
                    }
                }
            }
        }
        GUILayout.EndVertical();
    }
}
#endif