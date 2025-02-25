using UnityEditor;

public class UnityWindow
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
}
