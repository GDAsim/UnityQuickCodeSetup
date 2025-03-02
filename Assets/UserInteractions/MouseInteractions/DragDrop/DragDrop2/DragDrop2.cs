/* 
 * About:
 * Simple Script to have click drag of 3d game objects in scene.
 * This method moves the object left/right/up/down based on the objects perspective to the camera
 * 
 * How To Use:
 * Add this script to an empty gameobject in scene
 * 
 * Note:
 * This version does not keep track of dragging state
 */

using UnityEngine;

public class DragDrop2 : MonoBehaviour
{
    Transform draggingGO;
    Vector3 startDragPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                draggingGO = hit.transform;
                startDragPos = Input.mousePosition - Camera.main.WorldToScreenPoint(draggingGO.position);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            draggingGO = null;
        }

        if (draggingGO != null)
        {
            draggingGO.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - startDragPos);
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
        text += "Left Mouse Drag + Drop";
        GUI.Label(rect, text, fpsstyle);
    }
}