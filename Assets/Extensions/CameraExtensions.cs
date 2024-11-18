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
        Ray ray = cam.ScreenPointToRay(mousePosition);

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
        Ray ray = cam.ScreenPointToRay(mousePosition);

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
        Ray ray = cam.ScreenPointToRay(mousePosition);

        return Physics.RaycastAll(ray, dist);
    }

    //====================================================================================================
    //====================================================================================================
}