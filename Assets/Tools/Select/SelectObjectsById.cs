/* 
 * About:
 * A Window to select objects by id
 */

#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class SelectObjectsById : EditorWindow
{
    string inputText;

    [MenuItem("Tools/Select/Select Objects by ID")]
    public static void ShowWindow()
    {
        var window = GetWindow<SelectObjectsById>("Select Objects by ID");
        window.Show();
        window.Focus();
        window.Repaint();
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();

        inputText = GUILayout.TextArea(inputText, int.MaxValue, GUILayout.ExpandHeight(true));

        GUILayout.BeginHorizontal();

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Select", GUILayout.Width(125)))
        {
            try
            {
                var instanceIds = inputText.Trim().Split(new[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<Object> objects = new();
                foreach (var id in instanceIds)
                {
                    Object obj = EditorUtility.InstanceIDToObject(int.Parse(id.Trim()));
                    if (obj != null) objects.Add(obj);
                }

                Selection.objects = objects.ToArray();
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex.Message);
            }
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}
#endif