using UnityEngine;

[ExecuteInEditMode]
public class DebugDrawExample : MonoBehaviour 
{
	[Header("Point")]
	public Vector3 PointPos;
	public float PointSize;
	public Color PointColor;

    [Header("Bounds")]
    public Vector3 BoundsPos;
	public Vector3 BoundsSize;
	public Color BoundsColor;

    [Header("Circle")]
    public Vector3 CirclePos;
	public float CircleRadius;
	public Color CircleColor;

    [Header("Sphere")]
    public Vector3 SpherePos;
    public float SphereRadius;
	public Color SphereColor;

    [Header("Cylinder")]
    public Vector3 CylinderStart;
    public Vector3 CylinderEnd;
	public float CylinderRadius;
	public Color CylinderColor;

    [Header("Cone")]
    public Vector3 ConePos;
    public Vector3 ConeDirection;
	public float ConeAngle;
	public Color ConeColor;

    [Header("Arrow")]
    public Vector3 ArrowPos;
    public Vector3 ArrowDirection;
	public Color ArrowColor;

    [Header("Capsule")]
    public Vector3 CapsulePos;
    public Vector3 CapsuleEnd;
	public float CapsuleRadius;
	public Color CapsuleColor;
	
	void Update() 
	{
		var direction = Vector3.up;

        DebugDraw.DebugPoint(PointPos, PointColor, PointSize);
		DebugDraw.DebugBounds(new Bounds(BoundsPos, BoundsSize), BoundsColor);
		DebugDraw.DebugCircle(CirclePos, direction, CircleColor, CircleRadius);
		DebugDraw.DebugWireSphere(SpherePos, SphereColor, SphereRadius);
		DebugDraw.DebugCylinder(CylinderStart, CylinderEnd, CylinderColor, CylinderRadius);
		DebugDraw.DebugCone(ConePos, direction, ConeColor, ConeAngle);
		DebugDraw.DebugArrow(ArrowPos, direction, ArrowColor);
        DebugDraw.DebugCapsule(CapsulePos, CapsuleEnd, CapsuleColor, CapsuleRadius);
	}
}