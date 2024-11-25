/// <summary>
/// Zoom in on 3d object raycasted by camera
/// </summary>

using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CamFlyZoom : MonoBehaviour
{
    public float zoomSpeed = 1f;

    void Update() => flyzoom();

    void flyzoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var targetPos = hit.point;
                Vector3 move = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * (targetPos - transform.position);
                transform.position += move;
            }
        }
    }
}
