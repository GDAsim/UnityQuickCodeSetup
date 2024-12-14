using UnityEditor;
using UnityEngine;

public class UnityForceRecompile
{
    [MenuItem("Utilities/Unity/Recompile")]
    public static void Recompile()
    {
        AssetDatabase.Refresh();
        Debug.Log("Recompiled");
    }
}