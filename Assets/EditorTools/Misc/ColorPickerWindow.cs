/* 
 * About:
 * Color picker tool within Unity
 */

using UnityEngine;
using UnityEditor;

public class ColorPickerWindow : EditorWindow
{
    Color color = Color.white;
    Color32 color32 = new(255, 255, 255, 255);
    string hexCode = "FFFFFF";

    [MenuItem("Tools/Misc/Color Picker")]
    public static void ShowWindow()
    {
        GetWindow<ColorPickerWindow>("Color Picker");
    }

    void OnGUI()
    {
        color = EditorGUILayout.ColorField("Color", color);
        if (GUI.changed)
        {
            color32 = color;
            hexCode = ColorUtility.ToHtmlStringRGB(color);
        }

        hexCode = EditorGUILayout.TextField("Hex Code", hexCode);
        if (GUI.changed)
        {
            ColorUtility.TryParseHtmlString(hexCode, out color);
        }

        color32.r = (byte)EditorGUILayout.IntSlider("Red", color32.r, 0, 255);
        color32.g = (byte)EditorGUILayout.IntSlider("Green", color32.g, 0, 255);
        color32.b = (byte)EditorGUILayout.IntSlider("Blue", color32.b, 0, 255);
        color32.a = (byte)EditorGUILayout.IntSlider("Alpha", color32.a, 0, 255);
        if (GUI.changed)
        {
            color = color32;
            hexCode = ColorUtility.ToHtmlStringRGB(color);
        }

        EditorGUILayout.TextField(
            "Color Code",
            string.Format(
                "new Color ( {0}f, {1}f, {2}f, {3}f )",
                color.r,
                color.g,
                color.b,
                color.a));

        EditorGUILayout.TextField(
            "Color32 Code",
            string.Format(
                "new Color32 ( {0}, {1}, {2}, {3} )",
                color32.r,
                color32.g,
                color32.b,
                color32.a));
    }
}