using UnityEngine;

public class GizmoUtilitiesExample : MonoBehaviour
{
    [Header("Ray")]
    [SerializeField] Transform RayPos;

    [Header("Line")]
    [SerializeField] Transform LinePos;
    [SerializeField] GameObject LineFrom;
    [SerializeField] GameObject LineTo;

    [Header("Sphere")]
    [SerializeField] Transform SpherePos;

    [Header("Cube")]
    [SerializeField] Transform CubePos;

    [Header("Cylinder")]
    [SerializeField] Transform CylinderPos;

    [Header("Frustum")]
    [SerializeField] Camera CameraFrustum;

    [Header("Arrow")]
    [SerializeField] Transform ArrowPos;

    void OnDrawGizmos()
    {
        // Line
        if (LinePos)
        {
            GizmoUtilities.DrawLine(LineFrom.transform.position, LineTo.transform.position, Color.green);
        }

        // Ray
        if (RayPos)
        {
            GizmoUtilities.DrawRay(new Ray(RayPos.position, Vector3.up), Color.green);
        }

        // Sphere + Circle
        if (SpherePos)
        {
            var radius = 2;
            GizmoUtilities.DrawSphere(SpherePos.position, radius, Color.red);
            GizmoUtilities.DrawWireSphere(SpherePos.position + Vector3.up * 5, radius, Color.white);

            GizmoUtilities.DrawCircle(SpherePos.position + Vector3.up * 10, Vector3.forward, radius, Color.blue);
        }

        // Cube + Bounds
        if (CubePos)
        {
            var size = new Vector3(3, 3, 3);
            GizmoUtilities.DrawCube(CubePos.position, size, Color.red);
            GizmoUtilities.DrawWireCube(CubePos.position + Vector3.up * 5, size, Color.white);

            var bounds = new Bounds(CubePos.position + Vector3.up * 10, size);
            GizmoUtilities.DrawBounds(bounds, Color.blue);
        }

        // Cylinder
        if (CylinderPos)
        {
            GizmoUtilities.DrawCylinder(CylinderPos.position, CylinderPos.position + Vector3.forward * 10, Color.red, 2);
            GizmoUtilities.DrawCapsule(CylinderPos.position + Vector3.up * 5, CylinderPos.position + Vector3.up * 5 + Vector3.forward * 10, Color.white, 2);
            GizmoUtilities.DrawCone(CylinderPos.position + Vector3.up * 10, Vector3.forward * 10, Color.blue, 15);
        }

        // Frustum
        if (CameraFrustum)
        {
            GizmoUtilities.DrawFrustum(
                CameraFrustum.transform.position,
                CameraFrustum.transform.rotation,
                CameraFrustum.fieldOfView, CameraFrustum.farClipPlane, CameraFrustum.nearClipPlane, 1.77f, Color.black);
        }

        // Arrow
        if (ArrowPos)
        {
            GizmoUtilities.DrawArrow(ArrowPos.position, Vector3.forward, Color.red);
            GizmoUtilities.DrawConeArrow(ArrowPos.position + Vector3.up * 5, Vector3.forward, Color.white);
            GizmoUtilities.DrawPoint(ArrowPos.position + Vector3.up * 10, 5, Color.blue);

        }
    }
}
