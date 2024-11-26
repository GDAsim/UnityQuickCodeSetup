/// <summary>
/// About:
/// Simple Script to have click drag of 3d game objects in scene.
/// This method moves the object left/right/up/down based on the objects perspective to the camera
/// 
/// How To Use:
/// Add this script to 3d gameobject that has a collider component
/// Ensure EventSystem + Standalone Input Module is in the scene
/// 
/// Notes:
/// This version uses Unity Event System and StandaloneInputModule
/// </summary>

using UnityEngine;
using UnityEngine.EventSystems;

public class CamFlyZoom3 : MonoBehaviour, IScrollHandler
{
    public float zoomSpeed = 0.05f;

    void IScrollHandler.OnScroll(PointerEventData eventData)
    {
        var targetPos = eventData.pointerCurrentRaycast.worldPosition;
        Vector3 move = eventData.scrollDelta.y * zoomSpeed * (targetPos - Camera.main.transform.position);
        Camera.main.transform.position += move;
    }
}
