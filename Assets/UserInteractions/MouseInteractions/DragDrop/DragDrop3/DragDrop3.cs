/* 
 * About:
 * Simple Script to have click drag of 3d game objects in scene.
 * This method moves the object left/right/up/down based on the objects perspective to the camera
 * 
 * How To Use:
 * Add this script to 3d gameobject that has a collider component
 * Ensure EventSystem + Standalone Input Module is in the scene
 * 
 * Note:
 * This version uses Unity Event System and StandaloneInputModule
 */

using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop3 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startDragPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startDragPos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - startDragPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

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