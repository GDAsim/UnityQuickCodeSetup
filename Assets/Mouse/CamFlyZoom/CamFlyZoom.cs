/// <summary>
/// Zoom in on 3d object raycasted by camera
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
