/*
 * About:
 * Modifies the camera to allows you to control the fog settings for that camera separately from the global scene fog or other cameras. 
 */

using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraFog : MonoBehaviour
{
    public bool Enabled;
    public float StartDistance;
    public float EndDistance;
    public FogMode Mode;
    public float Density;
    public Color Color;

    bool originalEnabled;
    float originalStartDistance;
    float originalEndDistance;
    FogMode originalMode;
    float originalDensity;
    Color originalColor;

    void OnPreRender()
    {
        originalStartDistance = RenderSettings.fogStartDistance;
        originalEndDistance = RenderSettings.fogEndDistance;
        originalMode = RenderSettings.fogMode;
        originalDensity = RenderSettings.fogDensity;
        originalColor = RenderSettings.fogColor;
        originalEnabled = RenderSettings.fog;

        RenderSettings.fog = Enabled;
        RenderSettings.fogStartDistance = StartDistance;
        RenderSettings.fogEndDistance = EndDistance;
        RenderSettings.fogMode = Mode;
        RenderSettings.fogDensity = Density;
        RenderSettings.fogColor = Color;
    }

    void OnPostRender()
    {
        RenderSettings.fog = originalEnabled;
        RenderSettings.fogStartDistance = originalStartDistance;
        RenderSettings.fogEndDistance = originalEndDistance;
        RenderSettings.fogMode = originalMode;
        RenderSettings.fogDensity = originalDensity;
        RenderSettings.fogColor = originalColor;
    }
}
