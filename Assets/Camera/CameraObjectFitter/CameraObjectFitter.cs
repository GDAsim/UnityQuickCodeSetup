using UnityEngine;

public static class CameraObjectFitter
{
    /// <summary>
    /// Fit Object to Camera using Bounds
    /// Note: Bounds is Axis-Aligned
    public static void FitObjectToCamera(GameObject gameobject, Camera cam, float fitFactor)
    {
        // Get Object Bounds - Including Childrens - Uses Collider first, else Renderer
        Bounds? boundsnullable = gameobject.GetTotalAnyBounds();
        if (!boundsnullable.HasValue) return;
        var bounds = boundsnullable.Value;

        float size = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

        float cameraView = 2 * Mathf.Tan(0.5f * Mathf.Deg2Rad * cam.fieldOfView);
        float distance = fitFactor * size / cameraView;

        distance += 0.5f * size;

        // Update GameObject
        var dir = cam.transform.forward;
        gameobject.transform.position = cam.transform.position + distance * dir;
        
    }

    /// <summary>
    /// Fit Camera to Object using Bounds
    /// Note: Bounds is Axis-Aligned
    public static void FitCameraToObject(Camera cam, GameObject gameobject, float fitFactor)
    {
        // Get Object Bounds - Including Childrens - Uses Collider first, else Renderer
        Bounds? boundsnullable = gameobject.GetTotalAnyBounds();
        if (!boundsnullable.HasValue) return;
        var bounds = boundsnullable.Value;

        float size = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

        float cameraView = 2 * Mathf.Tan(0.5f * Mathf.Deg2Rad * cam.fieldOfView);
        float distance = fitFactor * size / cameraView;

        distance += 0.5f * size;

        // Update Camera
        var dir = gameobject.transform.forward;
        cam.transform.SetPositionAndRotation(bounds.center - distance * dir, gameobject.transform.rotation);
    }
}
