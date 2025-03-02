/* 
 * About:
 * Simple script to draw a debug Grid
 * 
 * How To Use:
 * Attach this script to a GameObject
 * 
 * Note:
 * Uses Unity Gizmos to draw
 * 
 * Reference:
 * https://docs.unity3d.com/ScriptReference/Gizmos.html
 */

using UnityEngine;

public class DebugGridOverlayGizmo : MonoBehaviour
{
    public bool Show = true;
    public bool Centralized = false;
    public int GridSizeX = 10;
    public int GridSizeY = 10;
    public int GridSizeZ = 10;
    public float GridSizeMultipllier = 1;
    public Color MainColor = new(0f, 1f, 0f, 1f);

    void OnDrawGizmos()
    {
        if (Show && GridSizeMultipllier != 0)
        {
            Gizmos.color = MainColor;
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
                endi = (GridSizeX + 1) / 2;
                endj = (GridSizeY + 1) / 2;
                endk = (GridSizeZ + 1) / 2;
            }
            Vector3 startline;
            Vector3 endline;

            // X
            for (int i = starti; i < endi + 1; i++)
            {
                // Y
                for (int j = startj; j < endj + 1; j++)
                {
                    // X
                    for (int k = startk; k < endk + 1; k++)
                    {
                        // X
                        if (i + 1 < endi + 1)
                        {
                            startline = new Vector3(GridPosition.x + i * GridSizeMultipllier, GridPosition.y + j * GridSizeMultipllier, GridPosition.z + k * GridSizeMultipllier);
                            endline = new Vector3(GridPosition.x + (i + 1) * GridSizeMultipllier, GridPosition.y + j * GridSizeMultipllier, GridPosition.z + k * GridSizeMultipllier);
                            Gizmos.DrawLine(startline, endline);
                        }
                        // Y
                        if (j + 1 < endj + 1)
                        {
                            startline = new Vector3(GridPosition.x + i * GridSizeMultipllier, GridPosition.y + j * GridSizeMultipllier, GridPosition.z + k * GridSizeMultipllier);
                            endline = new Vector3(GridPosition.x + i * GridSizeMultipllier, GridPosition.y + (j + 1) * GridSizeMultipllier, GridPosition.z + k * GridSizeMultipllier);
                            Gizmos.DrawLine(startline, endline);
                        }
                        // Z
                        if (k + 1 < endk + 1)
                        {
                            startline = new Vector3(GridPosition.x + i * GridSizeMultipllier, GridPosition.y + j * GridSizeMultipllier, GridPosition.z + k * GridSizeMultipllier);
                            endline = new Vector3(GridPosition.x + i * GridSizeMultipllier, GridPosition.y + j * GridSizeMultipllier, GridPosition.z + (k + 1) * GridSizeMultipllier);
                            Gizmos.DrawLine(startline, endline);
                        }
                    }
                }
            }
        }
    }
}
