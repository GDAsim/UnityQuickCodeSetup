/// <summary>
/// Very Simple Script to See Mesh Normals
/// 
/// How To Use:
/// Attach this script a GameObject that has MeshFilter
/// 
/// Note:
/// Uses OnDrawGizmo to draw
/// </summary>

using UnityEngine;

[ExecuteInEditMode]
public class SimpleMeshNormalsVisualizer : MonoBehaviour
{
    public float scaleNormals = 1;
    public Color color = Color.white;

    void OnDrawGizmos()
    {
        if (!enabled) return;

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null) return;

        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        Gizmos.color = color;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 startLine = vertices[i];
            Vector3 endLine = startLine + (normals[i] * Mathf.Clamp(scaleNormals, 0, scaleNormals));
            Gizmos.DrawLine(startLine + transform.position, endLine + transform.position);
        }
    }
}