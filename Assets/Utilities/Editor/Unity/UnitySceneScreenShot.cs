using System.IO;
using UnityEditor;
using UnityEngine;

public class UnitySceneScreenShot
{
    // TOUPDATE
    public static int ScreenshotSize = 1;
    public static string ScreenshotName = "Screenshot.png";

    // TODO
#if UNITY_STANDALONE || UNITY_WEBPLAYER
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
#endif

    [MenuItem("Utilities/Unity/Screenshot/Take Game Screenshot #p")]
    public static void TakeGameScreenShot()
    {
        string ScreenshotPath = string.Empty;

#if UNITY_EDITOR
        ScreenshotPath = Application.dataPath;
#endif

        var path = Path.Combine(ScreenshotPath, ScreenshotName);

        path = FileUtilities.GetUniqueFilePath_AppendNumber(path);

        // Cant Take a Screenshot if game is not focused
        if (!UnityWindow.IsGameWindowFocused()) UnityWindow.OpenGameWindow();

        ScreenCapture.CaptureScreenshot(path);

        AssetDatabase.Refresh();

        Debug.Log(string.Format("Screenshot Saved : {0}", path));
    }
}