/* 
 * About:
 * Simple Script to have mousewheel to have the current camera fly towards a target 3d gameobject over the mouse
 * 
 * How To Use:
 * Add this script to a camera gameobject
 * 
 * Note::
 * Uses Physics.Raycast manually
 * 3D GameObject needs to have a collider for raycast to work
 */

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamFlyZoom : MonoBehaviour
{
    public float ZoomSpeed = 0.05f;

    void Update() => flyzoom();

    void flyzoom()
    {
        if (Mathf.Abs(Input.mouseScrollDelta.y) > 0)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var targetPos = hit.point;
                Vector3 move = Input.mouseScrollDelta.y * ZoomSpeed * (targetPos - transform.position);
                transform.position += move;
            }
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
        text += "Hover over a gameobject and use MouseWheel";
        GUI.Label(rect, text, fpsstyle);
    }
}
