/// <summary>
/// About:
/// Simple Script to have click drag of 3d game objects in scene.
/// This method moves the object left/right/up/down based on the objects perspective to the camera
/// 
/// How To Use:
/// Add this script to 3d gameobject that has a collider component
/// 
/// Notes:
/// This version uses a bool to keep track of dragging state
/// </summary>
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
}