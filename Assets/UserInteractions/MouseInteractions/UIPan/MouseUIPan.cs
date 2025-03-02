/* 
 * About:
 * Use Middle Mouse pan UI
 * 
 * How It Works:
 * Calculates and Apply mouse delta on Mouse Down and Up
 * 
 * How To Use:
 * 1. Add this script to a gameobject
 * 2. Assign targetUI in inspector
 * 
 * Note:
 * This version uses a bool to keep track of dragging state
 */

using UnityEngine;

public class MouseUIPan : MonoBehaviour
{
    [SerializeField] RectTransform targetUI;

    public float PanSpeed = 1f;

    Vector3 lastMousePos;

    void Update() => Pan();

    void Pan()
    {
        // Middle Mouse Button
        if (Input.GetMouseButton(2))
        {
            var mousePos = Input.mousePosition;

            Vector3 mouseDelta = mousePos - lastMousePos;
            Vector3 movement = new Vector3(mouseDelta.x, mouseDelta.y, 0) * PanSpeed;

            targetUI.position += movement;
            lastMousePos = mousePos;
        }
        else
        {
            lastMousePos = Input.mousePosition;
        }
    }

    void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;
        float max = Mathf.Max(width, height);

        Rect rect = new(0, 0, width, height);

        GUIStyle fpsstyle = new();
        fpsstyle.alignment = TextAnchor.LowerCenter;
        fpsstyle.fontSize = (int)(max * 0.025f);
        fpsstyle.normal.textColor = Color.black;
        fpsstyle.fontStyle = FontStyle.Bold;

        string text = "";
        text += "Middle Mouse Drag";
        GUI.Label(rect, text, fpsstyle);
    }
}
