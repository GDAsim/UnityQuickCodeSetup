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
}