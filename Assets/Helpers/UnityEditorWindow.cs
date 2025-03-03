/* 
 * About:
 * Helper class to provide reusable functions regarding UnityEditor Window
 */

#if UNITY_EDITOR

using UnityEditor;

public class UnityEditorWindow
{
    public static bool IsGameWindowFocused()
    {
        return EditorWindow.focusedWindow != null && EditorWindow.focusedWindow.titleContent.text == "Game";
    }
    public static void OpenGameWindow()
    {
        EditorWindow gameView = EditorWindow.GetWindow(System.Type.GetType("UnityEditor.GameView,UnityEditor"));
        if (gameView != null)
        {
            gameView.Focus();
        }
    }

    public static bool IsHierarchyWindowFocused()
    {
        return EditorWindow.focusedWindow != null && EditorWindow.focusedWindow.titleContent.text == "Hierarchy";
    }
}
#endif