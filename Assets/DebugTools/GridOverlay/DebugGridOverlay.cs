/* 
 * About:
 * Simple script to draw a debug Grid in Play Mode
 * 
 * How To Use:
 * Attach this script to camera
 * 
 * Note:
 * Uses Camera OnPostRender with GL to draw
 * 
 * Reference:
 * https://docs.unity3d.com/ScriptReference/GL.html
 */

using UnityEngine;

public class DebugGridOverlay : MonoBehaviour
{
    public bool Show = true;
    public bool Centralized = false;
    public int GridSizeX = 10;
    public int GridSizeY = 10;
    public int GridSizeZ = 10;
    public float GridSizeMultipllier = 1;
    public Color MainColor = new(0f, 1f, 0f, 1f);

    Material lineMaterial;

    void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            var shader = Shader.Find("Hidden/Internal-Colored");

            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;

            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);

            lineMaterial.SetInt("_ZWrite", 0);
        }
    }
    void OnPostRender()
    {
        CreateLineMaterial();

        if (Show && GridSizeMultipllier != 0)
        {
            // Set material for rendering
            lineMaterial.SetPass(0);

            var GridPosition = transform.position;

            int starti = 0;
            int startj = 0;
            int startk = 0;
            int endi = GridSizeX;
            int endj = GridSizeY;
            int endk = GridSizeZ;
            if (Centralized)    
            {
                starti = -GridSizeX / 2;
                startj = -GridSizeY / 2;
                startk = -GridSizeZ / 2;
                endi = (GridSizeX+1) / 2;
                endj = (GridSizeY+1) / 2;
                endk = (GridSizeZ+1) / 2;
            }
            //x
            for (int i = starti; i < endi + 1; i++)
            {
                //y
                for (int j = startj; j < endj + 1; j++)
                {
                    GL.Begin(GL.LINES);
                    GL.Color(MainColor);
                    //z
                    for (int k = startk; k < endk + 1; k++)
                    {
                        //x
                        if(i+1 < endi + 1)
                        {
                            GL.Vertex3(GridPosition.x+i* GridSizeMultipllier, GridPosition.y+j* GridSizeMultipllier, GridPosition.z+k* GridSizeMultipllier);
                            GL.Vertex3(GridPosition.x+(i+1)* GridSizeMultipllier, GridPosition.y+j* GridSizeMultipllier, GridPosition.z+k* GridSizeMultipllier);
                        }
                        //y
                        if(j+1 < endj + 1)
                        {
                            GL.Vertex3(GridPosition.x+i* GridSizeMultipllier, GridPosition.y+j* GridSizeMultipllier, GridPosition.z+k* GridSizeMultipllier);
                            GL.Vertex3(GridPosition.x+i* GridSizeMultipllier, GridPosition.y+(j+1)* GridSizeMultipllier, GridPosition.z+k* GridSizeMultipllier);
                        }
                        //z
                        if(k+1 < endk + 1)
                        {
                            GL.Vertex3(GridPosition.x+i* GridSizeMultipllier, GridPosition.y+j* GridSizeMultipllier, GridPosition.z+k* GridSizeMultipllier);
                            GL.Vertex3(GridPosition.x+i* GridSizeMultipllier, GridPosition.y+j* GridSizeMultipllier, GridPosition.z+(k+1)* GridSizeMultipllier);
                        }
                    }
                    GL.End();
                }
            }
        }
    }
}