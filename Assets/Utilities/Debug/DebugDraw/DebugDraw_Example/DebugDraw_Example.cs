using UnityEngine;

public class Example : MonoBehaviour {
	
	//float
	public bool debugPoint;
	public Vector3 debugPoint_Position;
	public float debugPoint_Scale;
	public Color debugPoint_Color;
	
	//vector3
	public bool debugBounds;
	public Vector3 debugBounds_Position;
	public Vector3 debugBounds_Size;
	public Color debugBounds_Color;
	
	//float, vector3
	public bool debugCircle;
	public Vector3 debugCircle_Up;
	public float debugCircle_Radius;
	public Color debugCircle_Color;
	
	//float
	public bool debugWireSphere;
	public float debugWireSphere_Radius;
	public Color debugWireSphere_Color;
	
	//vector3, float
	public bool debugCylinder;
	public Vector3 debugCylinder_End;
	public float debugCylinder_Radius;
	public Color debugCylinder_Color;
	
	//vector3, float
	public bool debugCone;
	public Vector3 debugCone_Direction;
	public float debugCone_Angle;
	public Color debugCone_Color;
	
	//vector3
	public bool debugArrow;
	public Vector3 debugArrow_Direction;
	public Color debugArrow_Color;
	
	//vector3, float
	public bool debugCapsule;
	public Vector3 debugCapsule_End;
	public float debugCapsule_Radius;
	public Color debugCapsule_Color;
	
	void Update() 
	{
		DebugDraw.DebugPoint(debugPoint_Position, debugPoint_Color, debugPoint_Scale);
		DebugDraw.DebugBounds(new Bounds(new Vector3(10, 0, 0), debugBounds_Size), debugBounds_Color);
		DebugDraw.DebugCircle(new Vector3(20, 0, 0), debugCircle_Up, debugCircle_Color, debugCircle_Radius);
		DebugDraw.DebugWireSphere(new Vector3(30, 0, 0), debugWireSphere_Color, debugWireSphere_Radius);
		DebugDraw.DebugCylinder(new Vector3(40, 0, 0), debugCylinder_End, debugCylinder_Color, debugCylinder_Radius);
		DebugDraw.DebugCone(new Vector3(50, 0, 0), debugCone_Direction, debugCone_Color, debugCone_Angle);
		DebugDraw.DebugArrow(new Vector3(60, 0, 0), debugArrow_Direction, debugArrow_Color);
		DebugDraw.DebugCapsule(new Vector3(70, 0, 0), debugCapsule_End, debugCapsule_Color, debugCapsule_Radius);
	}
}