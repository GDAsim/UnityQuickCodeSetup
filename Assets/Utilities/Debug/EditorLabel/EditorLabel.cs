/// <summary>
/// About:
/// Creates a Debug Label above the Object for better identification
/// 
/// How It Works:
/// Uses OnGizmo to do a raycast and Uses Old GUI to Draw a Label above the object
/// Resizes and changes transparency depending on distance to camera
/// 
/// How To Use:
/// Attach this script to a GameObject that has a Renderer component + Collider
/// 
/// </summary>

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class EditorLabel : MonoBehaviour
{
    public float LabelHeightMin = 0;
    public float LabelHeightMax = 2;
    public Vector2 BGPadding;
    public float MaxSize = 64;
    public float MinSize = 12;
    public float MinDist = 3;
    public float MaxDist = 5; 

    public string Text;

    static GUIStyle style;
    static GUIStyle Style
    {
        get
        {
            if (style == null)
            {
                style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;
                style.normal.textColor = new Color(0.9f, 0.9f, 0.9f);
                style.fontSize = 32;
            }
            return style;
        }
    }

    void OnDrawGizmos()
    {
        if (string.IsNullOrWhiteSpace(Text)) return;

        var ray = new Ray(transform.position + Camera.current.transform.up * 8f, -Camera.current.transform.up);
        if (GetComponent<Collider>().Raycast(ray, out RaycastHit hit, 8f + 2f))
        {
            float dist = (hit.point - Camera.current.transform.position).magnitude;

            var heightOffset = Mathf.Clamp(dist * 0.2f, LabelHeightMin, LabelHeightMax);
            Vector3 worldPos = hit.point + Camera.current.transform.up * heightOffset;

            Vector3 screenPos = Camera.current.WorldToScreenPoint(worldPos);

            if (screenPos.z <= 0) return; // Dont draw if is behind the screen

            screenPos.y = Screen.height - screenPos.y; // Flip Y

            float alpha = Mathf.Clamp(1 - (dist - (MaxDist - MinDist)) / MinDist, 0f, 1f);

            // Draw
            Handles.BeginGUI();
            var oldColor = GUI.color;

            // Draw Background
            Vector2 textSize = Style.CalcSize(new GUIContent(Text));
            Rect backgroundRect = new Rect((textSize.x + BGPadding.x)/2f, (textSize.y + BGPadding.y)/2f, textSize.x + BGPadding.x, textSize.y + BGPadding.y);
            backgroundRect.center = screenPos;

            GUI.color = new Color(0f, 0f, 0f, 0.8f * alpha);
            GUI.DrawTexture(backgroundRect, EditorGUIUtility.whiteTexture);

            // Draw Text
            Style.fontSize = (int)Mathf.Lerp(MaxSize, MinSize, dist / 10f);
            GUI.color = new Color(1, 1, 1, 0.8f * alpha);
            GUI.Label(backgroundRect, Text, Style);

            GUI.color = oldColor;
            Handles.EndGUI();
        }
    }
}
#endif