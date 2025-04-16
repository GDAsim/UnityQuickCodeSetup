#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Text;

public class MeshInfoWindow : EditorWindow
{
    [MenuItem("Tools/Mesh/Mesh Info Window")]

    public static void ShowWindow()
    {
        GetWindow(typeof(MeshInfoWindow));
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }

    public void OnGUI()
    {
        MeshInfo staticMeshInfo = new();
        MeshInfo staticMeshInfo_Disabled = new();

        MeshInfo skinnedMeshInfo = new();
        MeshInfo skinnedMeshInfo_Disabled = new();

        StringBuilder sbMesh = new StringBuilder();
        StringBuilder sbSkinnedMesh = new StringBuilder();

        foreach (GameObject go in Selection.GetFiltered(typeof(GameObject), SelectionMode.TopLevel))
        {
            Component[] meshFilters = go.GetComponentsInChildren(typeof(MeshFilter), true);
            foreach (Component comp in meshFilters)
            {
                var mf = (MeshFilter)comp;

                if (mf.sharedMesh == null)
                {
                    sbMesh.AppendLine($"Missing Mesh in {comp.gameObject.name}");
                    continue;
                }

                MeshRenderer mr = comp.GetComponent<MeshRenderer>();
                bool isRendering = mr && mr.enabled && mf.gameObject.activeInHierarchy;
                var mesh = mf.sharedMesh;

                if (isRendering)
                {
                    staticMeshInfo.MeshCount++;
                    staticMeshInfo.Vertices += mesh.vertexCount;
                    staticMeshInfo.Triangles += mesh.triangles.Length / 3;
                }
                else
                {
                    staticMeshInfo_Disabled.MeshCount++;
                    staticMeshInfo_Disabled.Vertices += mesh.vertexCount;
                    staticMeshInfo_Disabled.Triangles += mesh.triangles.Length / 3;
                }
            }

            Component[] skinnedMeshes = go.GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
            foreach (Component comp in skinnedMeshes)
            {
                var smr = (SkinnedMeshRenderer)comp;

                if (smr.sharedMesh == null)
                {
                    sbSkinnedMesh.AppendLine($"Missing Mesh in {comp.gameObject.name}");
                    continue;
                }

                bool isRendering = smr.enabled && smr.gameObject.activeInHierarchy;
                var mesh = smr.sharedMesh;
                if (isRendering)
                {
                    skinnedMeshInfo.MeshCount++;
                    skinnedMeshInfo.Vertices += mesh.vertexCount;
                    skinnedMeshInfo.Triangles += mesh.triangles.Length / 3;
                }
                else
                {
                    skinnedMeshInfo_Disabled.MeshCount++;
                    skinnedMeshInfo_Disabled.Vertices += mesh.vertexCount;
                    skinnedMeshInfo_Disabled.Triangles += mesh.triangles.Length / 3;
                }
            }
        }

        string labelText = "Select Mesh";
        if (Selection.gameObjects.Length == 1)
        {
            labelText = Selection.gameObjects[0].name;
        }
        else
        {
            labelText = "*Multiple*";
        }


        //MeshInfo staticMeshInfo = new();
        //MeshInfo staticMeshInfo_Disabled = new();

        //MeshInfo skinnedMeshInfo = new();
        //MeshInfo skinnedMeshInfo_Disabled = new();

        DrawGUI();

        void DrawGUI()
        {
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.MiddleCenter;

            GUILayout.Label("Selected Object: " + labelText);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Mesh Count: " + staticMeshInfo.MeshCount);
            GUILayout.Label("Disabled Mesh Count: " + staticMeshInfo_Disabled.MeshCount);
            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.Label("Active Mesh");
            GUILayout.BeginHorizontal("box");

            GUILayout.BeginVertical("box");
            GUILayout.Label("Total Mesh Count " + (staticMeshInfo.MeshCount + skinnedMeshInfo.MeshCount), centeredStyle);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Static: " + staticMeshInfo.MeshCount);
            GUILayout.Label("Skinned: " + skinnedMeshInfo.MeshCount);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Total Vertices Count " + (staticMeshInfo.Vertices + skinnedMeshInfo.Vertices), centeredStyle);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Static: " + staticMeshInfo.Vertices);
            GUILayout.Label("Skinned: " + skinnedMeshInfo.Vertices);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Total Triangles Count " + (staticMeshInfo.Triangles + skinnedMeshInfo.Triangles), centeredStyle);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Static: " + staticMeshInfo.Triangles);
            GUILayout.Label("Skinned: " + skinnedMeshInfo.Triangles);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();

            GUILayout.Space(5);
            GUILayout.Label("Disabled Mesh");

            GUILayout.BeginHorizontal("box");

            GUILayout.BeginVertical("box");
            GUILayout.Label("Total Mesh Count " + (staticMeshInfo_Disabled.MeshCount + skinnedMeshInfo_Disabled.MeshCount), centeredStyle);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Static: " + staticMeshInfo_Disabled.MeshCount);
            GUILayout.Label("Skinned: " + skinnedMeshInfo_Disabled.MeshCount);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Total Vertices Count " + (staticMeshInfo_Disabled.Vertices + skinnedMeshInfo_Disabled.Vertices), centeredStyle);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Static: " + staticMeshInfo_Disabled.Vertices);
            GUILayout.Label("Skinned: " + skinnedMeshInfo_Disabled.Vertices);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Total Triangles Count " + (staticMeshInfo_Disabled.Triangles + skinnedMeshInfo_Disabled.Triangles), centeredStyle);
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Static: " + staticMeshInfo_Disabled.Triangles);
            GUILayout.Label("Skinned: " + skinnedMeshInfo_Disabled.Triangles);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }
    }

    struct MeshInfo
    {
        public int MeshCount;
        public int Vertices;
        public int Triangles;
    }
}
#endif