using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class MeshInfo
{
    [MenuItem("Tools/Mesh/Show Mesh Stats &z")]
    public static void ShowCount()
    {
        int vertices = 0;
        int triangles = 0;
        int meshCount = 0;

        // 1. Loop Selection, filter based on GameObjects
        foreach (GameObject go in Selection.GetFiltered(typeof(GameObject), SelectionMode.TopLevel))
        {
            Component[] meshFilters = go.GetComponentsInChildren(typeof(MeshFilter));
            Component[] skinnedMeshes = go.GetComponentsInChildren(typeof(SkinnedMeshRenderer));

            List<Mesh> meshes = new List<Mesh>(meshFilters.Length + skinnedMeshes.Length);

            foreach (Component comp in meshFilters)
            {
                var mf = (MeshFilter)comp;

                if (mf.sharedMesh == null)
                {
                    Debug.LogWarning("Missing Mesh in Scene Detected!", comp);
                    continue;
                }

                meshes.Add(mf.sharedMesh);
            }
            foreach (Component comp in skinnedMeshes)
            {
                var smr = (SkinnedMeshRenderer)comp;

                if (smr.sharedMesh == null)
                {
                    Debug.LogWarning("Missing Mesh in Scene Detected!", comp);
                    continue;
                }

                meshes.Add(smr.sharedMesh);
            }

            foreach (Mesh mesh in meshes)
            {
                vertices += mesh.vertexCount;
                triangles += mesh.triangles.Length / 3;
                meshCount++;
            }
        }

        var Title = "Show Mesh Stats";
        var Content =
            $"There are {vertices} vertices in selection. \n" +
            $"There are {triangles} triangles in selection. \n" +
            $"There are {meshCount} meshes in selection. \n";

        if (triangles > 0)
        {
            var average = vertices / triangles;
            Content += $"Average of {average} vertices per triangle. \n";
        }
        if (meshCount > 0)
        {
            var tripermesh = triangles / meshCount;
            Content += $"Average of {tripermesh} triangles per mesh. \n";
        }

        EditorUtility.DisplayDialog(Title, Content, "OK", "");
    }
}