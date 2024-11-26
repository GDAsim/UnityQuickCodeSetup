/// <summary>
/// About:
/// Simple Script to have mousewheel to have the current camera fly towards a target 3d gameobject over the mouse
/// This method uses Physics.Raycast manually 
/// 
/// How To Use:
/// Add this script to a camera gameobject
/// 
/// Notes:
/// 3D GameObject needs to have a collider for raycast to work
/// </summary>

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamFlyZoom : MonoBehaviour
{
    public float zoomSpeed = 0.05f;

    void Update() => flyzoom();

    void flyzoom()
    {
        if (Mathf.Abs(Input.mouseScrollDelta.y) > 0)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var targetPos = hit.point;
                Vector3 move = Input.mouseScrollDelta.y * zoomSpeed * (targetPos - transform.position);
                transform.position += move;
            }
        }
    }
}
