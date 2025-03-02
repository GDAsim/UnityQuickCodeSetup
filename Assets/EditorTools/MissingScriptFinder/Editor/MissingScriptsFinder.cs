/* 
 * About:
 * Window to search for missing scripts
 * 1. Search missing scripts in Scene
 * 2. Search missing scripts in Assets
 */

using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MissingScriptsFinder : EditorWindow
{
    [MenuItem("Tools/Missing Scripts Finder")]
    public static void ShowWindow()
    {
        GetWindow(typeof(MissingScriptsFinder));
    }

    List<GameObject> missingScripts_scene = new ();
    List<string> missingScripts_project = new ();
    Vector2 scrollPosition;

    void OnGUI()
    {
        GUIStyle style = new(GUI.skin.box);

        #region Search Scene
        GUILayout.BeginVertical(style);

        GUILayout.BeginHorizontal(style);
        if (GUILayout.Button("Search Missing Scripts In Scene")) FindMissingScriptsInScene();
        if (missingScripts_scene.Count > 0 && GUILayout.Button("Clear")) missingScripts_scene.Clear();
        GUILayout.EndHorizontal();

        // Results
        if (missingScripts_scene.Count > 0)
        {
            GUILayout.Label("Results:", EditorStyles.boldLabel);
            GUILayout.BeginVertical(style);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(120));
            foreach (var go in missingScripts_scene)
            {
                if (GUILayout.Button($"{(go.transform.parent !=null ? $"{go.GetRoot().name}../" : " ")}{go.name}"))
                {
                    EditorGUIUtility.PingObject(go);
                }
            }
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
        }
        else
        {
            GUILayout.Label("Results: None", EditorStyles.boldLabel);
        }
        GUILayout.EndVertical();
        #endregion

        GUILayout.Space(20);

        #region Search Project
        GUILayout.BeginVertical(style);

        GUILayout.BeginHorizontal(style);
        if (GUILayout.Button("Search Missing Scripts in Assets")) FindMissingScriptsInAssets();
        if (missingScripts_project.Count > 0 && GUILayout.Button("Clear")) missingScripts_project.Clear();
        GUILayout.EndHorizontal();

        // Results
        if (missingScripts_project.Count > 0)
        {
            GUILayout.Label("Results:", EditorStyles.boldLabel);
            GUILayout.BeginVertical(style);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(120));
            foreach (string path in missingScripts_project)
            {
                if (GUILayout.Button(path))
                {
                    EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(path));
                }
            }
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
        }
        else
        {
            GUILayout.Label("Results: None", EditorStyles.boldLabel);
        }
        GUILayout.EndVertical();
        #endregion
    }

    void FindMissingScriptsInScene()
    {
        missingScripts_scene.Clear();

        var rootGOsInScene = FindObjectsOfType<GameObject>(true).Where(go => go.transform.parent == null);
        foreach (var go in rootGOsInScene)
        {
            FindMissingScriptsInGameObjectRecursive(go);
        }

        void FindMissingScriptsInGameObjectRecursive(GameObject go)
        {
            var components = go.GetComponents<Component>();
            bool hasNullComponent = components.Any(c => c == null);
            if (hasNullComponent)
            {
                missingScripts_scene.Add(go);
            }

            foreach (Transform child in go.transform)
            {
                FindMissingScriptsInGameObjectRecursive(child.gameObject);
            }
        }
    }

    void FindMissingScriptsInAssets()
    {
        missingScripts_project.Clear();

        string[] prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();

        foreach (string path in prefabPaths)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            var prefabComponents = prefab.GetComponentsInChildren<Component>(true);

            bool hasNullComponent = prefabComponents.Any(c => c == null);
            if (hasNullComponent)
            {
                missingScripts_project.Add(path);
            }
        }
    }
}