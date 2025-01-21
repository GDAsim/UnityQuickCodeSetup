using UnityEngine;

/// <summary>
/// About:
/// Script to Update Camera Viewport Rect based on a Grid Arrangement
/// 
/// How To Use:
/// Attach this script to a Camera
/// Adjust variables as needed
/// </summary>
[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
public class CameraViewportSplitter : MonoBehaviour
{
    public int NumOfCols = 3;
    public int NumOfRows = 3;
    public int CurrentCol = 0;
    public int CurrentRow = 0;

    public Color FontColor = Color.white;
    public int FontSize = 256;

    public bool DrawText = true;

    public void OnValidate()
    {
        // Clamp
        NumOfCols = NumOfCols < 1 ? 1 : NumOfCols;
        NumOfRows = NumOfRows < 1 ? 1 : NumOfRows;
        CurrentCol = Mathf.Clamp(CurrentCol, 0, NumOfCols - 1);
        CurrentRow = Mathf.Clamp(CurrentRow, 0, NumOfRows - 1);

        if (CurrentCol >= NumOfCols) CurrentCol = NumOfCols - 1;
        if (CurrentRow >= NumOfRows) CurrentRow = NumOfRows - 1;

        UpdateRect();
    }

    void UpdateRect()
    {
        var width = 1f / NumOfCols;
        var height = 1f / NumOfRows;
        Rect rect = new Rect(CurrentCol * width,
            1 - (CurrentRow + 1) * height,
            width,
            height);

        GetComponent<Camera>().rect = rect;
    }

    void OnGUI()
    {
        if(DrawText) DrawGUIText();
    }

    void DrawGUIText()
    {
        var x = (Screen.width / NumOfCols) * CurrentCol;
        var y = (Screen.height / NumOfRows) * CurrentRow;
        var width = 1f / NumOfCols;
        var height = 1f / NumOfRows;

        Rect rect = new Rect(x, y, width, height);

        var min = Mathf.Max(NumOfCols, NumOfRows);
        var text = gameObject.name;
         
        var style = new GUIStyle();
        style.normal.textColor = FontColor;
        style.fontSize = FontSize / min;

        GUI.Label(rect, text, style);
    }
}