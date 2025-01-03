/// <summary>
/// About:
/// Simple Script to have click drag of 3d game objects in scene.
/// This method moves the object left/right/up/down based on the objects perspective to the camera
/// 
/// How To Use:
/// Add this script to an empty gameobject in scene
/// 
/// Notes:
/// This version does not keep track of dragging state
/// </summary>

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
}