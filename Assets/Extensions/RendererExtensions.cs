using UnityEngine;

public static class RendererExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns true if camera if renderer object is visiable from the camera
    /// </summary>
    public static bool IsVisibleFromCam(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        Bounds b = renderer.bounds;
        return GeometryUtilities.TestPlanesAABBInternalFast(planes,ref b) != GeometryUtilities.TestPlanesResults.Outside;
    }

    /// <summary>
    /// Returns true if camera if renderer object is visiable from the camera
    /// </summary>
    public static bool IsVisibleFromCam2(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    /// <summary>
    /// Returns true if camera if renderer object is visiable from the camera
    /// </summary>
    public static bool IsFullyVisibleFromCam(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        Bounds b = renderer.bounds;
        return GeometryUtilities.TestPlanesAABBInternalFast(planes, ref b) == GeometryUtilities.TestPlanesResults.Inside;
    }

    //====================================================================================================
    //====================================================================================================
}