/* 
 * About:
 * Simple Script to have click drag of 3d game objects in scene.
 * This method moves the object left/right/up/down based on the objects perspective to the camera
 * 
 * How To Use:
 * Add this script to 3d gameobject that has a collider component
 * 
 * Note:
 * This version uses a bool to keep track of dragging state
 */

using UnityEngine;

public class DragDrop : MonoBehaviour
{
    bool dragging = false;
    Vector3 startDragPos;

    void Update()
    {
        if(dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - startDragPos);
        }
    }
    void OnMouseDown()
    {
        startDragPos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        dragging = true;
    }
    void OnMouseUp()
    {
        dragging = false;    
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
        text += "Left Mouse Drag + Drop";
        GUI.Label(rect, text, fpsstyle);
    }
}