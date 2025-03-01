using UnityEngine;

public static class CameraObjectFitter
{
    /// <summary>
    /// Fit Object Within Camera using Bounds <br/>
    /// Note: Bounds is Axis-Aligned
    /// </summary>
    public static void FitObjectWithinCamera(GameObject gameobject, Camera cam, float fitFactor)
    {
        // Get Object Bounds - Including Children
        Bounds? nullableBounds = gameobject.GetTotalAnyBounds();
        if (!nullableBounds.HasValue) return;
        var bounds = nullableBounds.Value;

        var maxSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

        var cameraView = 2 * Mathf.Tan(0.5f * Mathf.Deg2Rad * cam.fieldOfView);
        var distance = fitFactor * maxSize / cameraView;

        distance += 0.5f * maxSize;

        // Update GameObject
        var dir = cam.transform.forward;
        gameobject.transform.position = cam.transform.position + distance * dir;
        
    }

    /// <summary>
    /// Fit Camera Within Object using Bounds <br/>
    /// Note: Bounds is Axis-Aligned
    /// </summary>
    public static void FitCameraWithinObject(Camera cam, GameObject gameobject, float fitFactor)
    {
        // Get Object Bounds - Including Children
        Bounds? boundsnullable = gameobject.GetTotalAnyBounds();
        if (!boundsnullable.HasValue) return;
        var bounds = boundsnullable.Value;

        float maxSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

        float cameraView = 2 * Mathf.Tan(0.5f * Mathf.Deg2Rad * cam.fieldOfView);
        float distance = fitFactor * maxSize / cameraView;

        distance += 0.5f * maxSize;

        // Update Camera
        var dir = gameobject.transform.forward;
        cam.transform.SetPositionAndRotation(bounds.center - distance * dir, gameobject.transform.rotation);
    }
}
