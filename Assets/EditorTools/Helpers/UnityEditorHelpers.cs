using UnityEditor;

    public static class UnityEditorHelpers
    {
        public static bool IsHierarchyWindowFocused => EditorWindow.focusedWindow != null && EditorWindow.focusedWindow.titleContent.text == "Hierarchy";
    }
