using System.IO;
using UnityEditor;
using UnityEngine;

public class UnitySceneScreenShot
{
    // TODO
#if UNITY_STANDALONE || UNITY_WEBPLAYER
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
#endif

    /// <summary>
    /// Take Screenshot using Camera Rendertexture
    /// </summary>
    [MenuItem("Utilities/Unity/Screenshot/Take Game Screenshot #p")]
    public static void TakeGameScreenShot()
    {
        // TOUPDATE
        const int ResWidth = 4096;
        const int ResHeight = 2048;
        const string ScreenshotName = "Screenshot.png";

        string ScreenshotPath = string.Empty;
#if UNITY_EDITOR
        ScreenshotPath = Application.dataPath;
#endif
        var path = Path.Combine(ScreenshotPath, ScreenshotName);
        path = FileUtilities.GetUniqueFilePath_AppendNumber(path);

        var cam = Camera.main;
        var rt = new RenderTexture(ResWidth, ResHeight, 24);

        // Save current
        var prevRT = cam.targetTexture;
        var prevActive = RenderTexture.active;
        RenderTexture.active = rt;

        // Apply new
        cam.targetTexture = rt;
        RenderTexture.active = rt;

        // Take Screenshot
        cam.Render();

        // Extract
        var screenTex = new Texture2D(ResWidth, ResHeight, TextureFormat.ARGB32, false);
        screenTex.ReadPixels(new Rect(0, 0, ResWidth, ResHeight), 0, 0, false);
        screenTex.Apply();

        // Write File
        File.WriteAllBytes(path, screenTex.EncodeToPNG());
        Debug.Log(string.Format("Screenshot Saved : {0}", path));

        // Restore old
        cam.targetTexture = prevRT;
        RenderTexture.active = prevActive;

        // Clean up
        Object.DestroyImmediate(rt);
        Object.DestroyImmediate(screenTex);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    /// <summary>
    /// Take Screenshot using UnityEngine.ScreenCapture.CaptureScreenshot
    /// </summary>
    [MenuItem("Utilities/Unity/Screenshot/Take Game Screenshot 2")]
    public static void TakeGameScreenShot2()
    {
        // TOUPDATE
        const int ScreenshotSize = 1;
        const string ScreenshotName = "Screenshot.png";

    string ScreenshotPath = string.Empty;
#if UNITY_EDITOR
        ScreenshotPath = Application.dataPath;
#endif
        var path = Path.Combine(ScreenshotPath, ScreenshotName);
        path = FileUtilities.GetUniqueFilePath_AppendNumber(path);

        // ScreenCapture.CaptureScreenshot Cant Take a Screenshot if game is not focused
        if (!UnityWindow.IsGameWindowFocused()) UnityWindow.OpenGameWindow();

        ScreenCapture.CaptureScreenshot(path, ScreenshotSize);
        Debug.Log(string.Format("Screenshot Saved : {0}", path));

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}