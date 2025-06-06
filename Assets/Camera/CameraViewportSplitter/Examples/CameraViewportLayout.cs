using UnityEngine;

/// <summary>
/// About:
/// Setup a list of Camera as a Grid Split Screen Display <br/>
/// 
/// How To Use: <br/>
/// 1. Attach this script to a GameObject <br/>
/// 2. Assign Camera GameObjects <br/>
/// </summary>
public class CameraViewportLayout : MonoBehaviour
{
    [SerializeField] GameObject[] cameraGos;

    public int ColNum = 1;
    public int RowNum = 1;

    public Color FontColor = Color.white;
    public int FontSize = 256;

    void OnValidate()
    {
        for (int i = 0; i < cameraGos.Length; i++)
        {
            if (cameraGos[i].TryGetComponent(out CameraViewportSplitter splitter)) { }
            else splitter = cameraGos[i].AddComponent<CameraViewportSplitter>();

            splitter.NumOfCols = ColNum;
            splitter.NumOfRows = RowNum;
            splitter.CurrentCol = i % ColNum;
            splitter.CurrentRow = i / RowNum;

            splitter.FontColor = FontColor; 
            splitter.FontSize = FontSize;

            splitter.OnValidate();
        }
    }
}
