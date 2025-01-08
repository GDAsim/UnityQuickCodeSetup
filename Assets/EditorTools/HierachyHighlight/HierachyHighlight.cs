using UnityEngine;
using UnityEditor;

public class HierachyHighlight : MonoBehaviour
{
    public Color32 backgroundColor = new Color32(0, 255, 0, 255);
    public Color32 textColor = new Color32(0, 0, 0, 255);
    [Range(1,20)] public int fontSize = 12;
    public FontStyle fontStyle = FontStyle.Normal;
    public TextAnchor textAlignment = TextAnchor.UpperLeft;

    void OnValidate()
    {
        EditorApplication.RepaintHierarchyWindow();
    }
}