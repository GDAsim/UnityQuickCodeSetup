/* 
 * About:
 * FPS display
 * 
 * How To Use:
 * Attach this script to a GameObject
 * 
 * Note::
 * Uses OnGUI to draw
 */

using UnityEngine;

[ExecuteInEditMode]
public class Fps3 : MonoBehaviour
{
    public float updateInterval = 0.5f;

    [SerializeField] int Size = 60;
    [SerializeField] Color FpsColor = Color.red;
    [SerializeField] TextAnchor FpsAnchor = TextAnchor.UpperRight;

    float timer;
    float framestimeLapsed;
    int framesLapsed;

    float fps;
    float ms;

    void Update()
    {
        timer += Time.deltaTime;

        framestimeLapsed += Time.timeScale / Time.deltaTime;
        framesLapsed++;

        if (timer > updateInterval)
        {
            timer -= updateInterval;

            // Calculate
            fps = (framestimeLapsed / framesLapsed);
            ms = 1000 / fps;

            framestimeLapsed = 0.0f;
            framesLapsed = 0;
        }
    }

    void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;

        Rect fpsrect = new(0, 0, width, height);

        GUIStyle fpsstyle = new();
        fpsstyle.alignment = FpsAnchor;
        fpsstyle.fontSize = Size;
        fpsstyle.normal.textColor = FpsColor;
        fpsstyle.fontStyle = FontStyle.Bold;

        string fpsText = string.Format("{0:f2} fps ({1:f1} ms)", fps, ms);
        GUI.Label(fpsrect, fpsText, fpsstyle);
    }
}