#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public static class UnityClearPlayerpref
{
    [MenuItem("Tools/QuickAction/Clear Player Pref")]
    public static void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Pref Cleared!");
    }
}
#endif