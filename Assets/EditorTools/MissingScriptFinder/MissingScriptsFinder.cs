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

    static List<GameObject> missingScript_sceneList = new ();
    static List<string> missingScript_prefabList = new ();
    Vector2 scrollPosition;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.box);

        #region Search Current Scene
        GUILayout.BeginVertical(style);

        #region Buttons
        GUILayout.BeginHorizontal(style);

        if (GUILayout.Button("Search Missing Scripts In Scene")) FindMissingScriptsInCurrentScene();
        if (missingScript_sceneList.Count > 0 && GUILayout.Button("Clear")) missingScript_sceneList.Clear();

        GUILayout.EndHorizontal();
        #endregion

        #region Results
        if (missingScript_sceneList.Count > 0)
        {
            GUILayout.Label("Results:", EditorStyles.boldLabel);
            GUILayout.BeginVertical(style);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(120));
            foreach (var go in missingScript_sceneList)
            {
                if (GUILayout.Button($"{(go.transform.parent !=null ? $"{GetGameObjectRootParentName(go)}../" : " ")}{go.name}"))
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
        #endregion

        GUILayout.EndVertical();
        #endregion

        GUILayout.Space(20);

        #region Search Current Project
        GUILayout.BeginVertical(style);

        #region Buttons
        GUILayout.BeginHorizontal(style);

        if (GUILayout.Button("Search Missing Scripts in Project")) FindMissingScriptsInAssets();
        if (missingScript_prefabList.Count > 0 && GUILayout.Button("Clear")) missingScript_prefabList.Clear();

        GUILayout.EndHorizontal();
        #endregion

        #region Results
        if (missingScript_prefabList.Count > 0)
        {
            GUILayout.Label("Results:", EditorStyles.boldLabel);
            GUILayout.BeginVertical(style);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(120));
            foreach (string path in missingScript_prefabList)
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
        #endregion

        GUILayout.EndVertical();
        #endregion

        static string GetGameObjectRootParentName(GameObject go)
        {
            while (go.transform.parent != null)
            {
                go = go.transform.parent.gameObject;
            }
            return go.name;
        }
    }

    static void FindMissingScriptsInAssets()
    {
        missingScript_prefabList.Clear();

        string[] prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();

        foreach (string path in prefabPaths)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            var prefabComponents = prefab.GetComponentsInChildren<Component>(true);

            bool hasNullComponent = prefabComponents.Any(c => c == null);
            if (hasNullComponent)
            {
                missingScript_prefabList.Add(path);
            }
        }
    }

    static void FindMissingScriptsInCurrentScene()
    {
        missingScript_sceneList.Clear();

        var rootGOsInScene = GameObject.FindObjectsOfType<GameObject>(true).Where(go => go.transform.parent == null);
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
                missingScript_sceneList.Add(go);
            }

            foreach (Transform child in go.transform)
            {
                FindMissingScriptsInGameObjectRecursive(child.gameObject);
            }
        }
    }
}