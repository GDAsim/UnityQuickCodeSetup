using UnityEditor;
using UnityEngine;

public static class UnityForceRecompile
{
    [MenuItem("Tools/QuickAction/Recompile Assets")]
    public static void Recompile()
    {
        AssetDatabase.Refresh();
        Debug.Log("Assets Recompiled");
    }
}