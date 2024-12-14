using UnityEditor;
using UnityEngine;

public class UnityClearPlayerpref
{
    [MenuItem("Utilities/Unity/Clear Player Pref")]
    public static void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Pref Deleted");
    }
}