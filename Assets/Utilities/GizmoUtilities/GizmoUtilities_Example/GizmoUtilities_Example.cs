using UnityEngine;

public class GizmoUtilities_Example : MonoBehaviour
{
    public GameObject LineFrom;
    public GameObject LineTo;
    

    void OnDrawGizmos()
    {
        GizmoUtilities.DrawSphere(transform.position,2, Color.red);
        GizmoUtilities.DrawWireSphere(transform.position, 2, Color.white);

        GizmoUtilities.DrawCube(transform.position + new Vector3(1, 0, 0), new Vector3(3,3,3), Color.red);
        GizmoUtilities.DrawWireCube(transform.position + new Vector3(1, 0, 0), new Vector3(3, 3, 3), Color.white);

        GizmoUtilities.DrawLine(LineFrom.transform.position, LineTo.transform.position, Color.green);
        GizmoUtilities.DrawRay(new Ray(transform.position, Vector3.up), Color.green);

        GizmoUtilities.DrawFrustum(transform.position, 35, 100, 10, 1.77f, Color.black);


        GizmoUtilities.DrawPoint(transform.position, 2, Color.blue);
        GizmoUtilities.DrawBounds(new Bounds(transform.position+new Vector3(10, 0, 0), new Vector3(3,3,3)), Color.blue);
        GizmoUtilities.DrawCircle(transform.position + new Vector3(20, 0, 0), Vector3.forward, 2, Color.blue);
        GizmoUtilities.DrawCylinder(transform.position + new Vector3(40, 0, 0), new Vector3(50, 0, 0), Color.blue, 2);
        GizmoUtilities.DrawCone(transform.position + new Vector3(50, 0, 0),Vector3.forward, Color.blue, 45);
        GizmoUtilities.DrawArrow(transform.position + new Vector3(60, 0, 0), Vector3.forward, Color.blue);
        GizmoUtilities.DrawCapsule(transform.position + new Vector3(70, 0, 0), new Vector3(80, 0, 0), Color.blue, 2);
    }
}
