/* 
 * About:
 * Simple script to display see Mesh normals
 * 
 * How To Use:
 * Attach this script to a GameObject that has MeshFilter
 * 
 * Note:
 * Uses OnDrawGizmo to draw
 */

using UnityEngine;

[ExecuteInEditMode]
public class SimpleMeshNormalsVisualizer : MonoBehaviour
{
    public float Scale = 0.1f;
    public Color Color = Color.red;

    void OnDrawGizmos()
    {
        if (!enabled) return;

        if (!TryGetComponent<MeshFilter>(out var meshFilter)) return;

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null) return;

        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        Gizmos.color = Color;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 startLine = vertices[i];
            Vector3 endLine = startLine + (normals[i] * Mathf.Clamp(Scale, 0, Scale));
            Gizmos.DrawLine(startLine + transform.position, endLine + transform.position);
        }
    }
}