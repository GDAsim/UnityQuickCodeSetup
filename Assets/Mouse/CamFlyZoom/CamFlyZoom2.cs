/// <summary>
/// About:
/// Simple Script to have mousewheel to have the current camera fly towards a target 3d gameobject over the mouse
/// This method uses unity's event system for raycast
/// 
/// How To Use:
/// Add this script to 3d gameobject that has a collider component
/// Ensure EventSystem + Standalone Input Module is in the scene
/// 
/// Notes:
/// 3D GameObject needs to have a collider for raycast to work
/// </summary>

using UnityEngine;
using UnityEngine.EventSystems;

public class CamFlyZoom2 : MonoBehaviour, IScrollHandler
{
    public float zoomSpeed = 0.05f;

    void IScrollHandler.OnScroll(PointerEventData eventData)
    {
        var targetPos = eventData.pointerCurrentRaycast.worldPosition;
        Vector3 move = eventData.scrollDelta.y * zoomSpeed * (targetPos - Camera.main.transform.position);
        Camera.main.transform.position += move;
    }
}
