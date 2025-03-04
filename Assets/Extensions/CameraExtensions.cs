using UnityEngine;

public static class CameraExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns first gameobject at mouse
    /// Note: Uses Raycast Alloc
    /// </summary>
    public static GameObject GetFirstGameObjectAtMouse(this Camera cam, Vector3 mousePosition, float dist, int layermask = ~0)
    {
        var ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, dist, layermask))
        {
            return hit.transform.gameObject;
        }

        return null;
    }

    /// <summary>
    /// Returns first hit data at mouse
    /// Note: Uses Raycast Alloc
    /// </summary>
    public static RaycastHit GetFirstHitAtMouse(this Camera cam, Vector3 mousePosition, float dist, int layermask = ~0)
    {
        var ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, dist, layermask))
        {
            return hit;
        }

        return new RaycastHit();
    }

    /// <summary>
    /// Returns hits data at mouse
    /// Note: Uses Raycast Alloc
    /// </summary>
    public static RaycastHit[] GetHitsAtMouse(this Camera cam, Vector3 mousePosition, float dist)
    {
        var ray = cam.ScreenPointToRay(mousePosition);

        return Physics.RaycastAll(ray, dist);
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns the width and height of the camera view rect, at a distance
    /// </summary>
    public static Vector2 CalculateViewportWorldSizeAtDistance(this Camera camera, float distance)
    {
        var viewportHeightAtDistance = 2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad) * distance;
        var viewportWidthAtDistance = viewportHeightAtDistance * camera.aspect;

        return new Vector2(viewportWidthAtDistance, viewportHeightAtDistance);
    }

    //====================================================================================================
    //====================================================================================================
}