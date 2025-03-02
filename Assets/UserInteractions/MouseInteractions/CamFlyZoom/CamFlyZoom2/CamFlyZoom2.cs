/* 
 * About:
 * Simple Script to have mousewheel to have the current camera fly towards a target 3d gameobject over the mouse
 * 
 * How To Use:
 * Add this script to 3d gameobject that has a collider component
 * Ensure EventSystem + Standalone Input Module is in the scene
 * 
 * Note::
 * Uses unity's event system for raycast
 * 3D GameObject needs to have a collider for raycast to work
 */

using UnityEngine;
using UnityEngine.EventSystems;

public class CamFlyZoom2 : MonoBehaviour, IScrollHandler
{
    public float ZoomSpeed = 0.05f;

    void IScrollHandler.OnScroll(PointerEventData eventData)
    {
        var targetPos = eventData.pointerCurrentRaycast.worldPosition;
        Vector3 move = eventData.scrollDelta.y * ZoomSpeed * (targetPos - Camera.main.transform.position);
        Camera.main.transform.position += move;
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
        text += "Hover over a gameobject and use MouseWheel";
        GUI.Label(rect, text, fpsstyle);
    }
}
