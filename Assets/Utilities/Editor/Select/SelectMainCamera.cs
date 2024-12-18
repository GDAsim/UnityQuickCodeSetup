using UnityEditor;
using UnityEngine;  
 
public static class SelectMainCamera
{
    [MenuItem ("Utilities/Select/Main Camera")]
    static void Select()
    {
        if (Camera.main != null)
            Selection.activeObject = Camera.main.gameObject;
    }
}