/* 
 * About:
 * Use MouseWheel to Zoom in On UI
 * 
 * How It Works:
 * Zooming is done by scaling object based on mouse position
 * Special function is used due to how Unity applies pivot changes in runtime differently from inspector
 * 
 * How To Use:
 * 1. Add this script to a gameobject
 * 2. Assign targetUI in inspector
 */

using UnityEngine;

public class MouseUIZoom : MonoBehaviour
{
    [SerializeField] RectTransform targetUI;

    public float ZoomSpeed = 1f;

    void Update() => Zoom();

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            Vector3 scaleChange = new Vector3(scrollInput, scrollInput, scrollInput) * ZoomSpeed;
            Vector3 newScale = targetUI.localScale + scaleChange;

            var oldPivot = targetUI.pivot;

            targetUI.ChangePivotAndHold(new Vector2(0, 0));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(targetUI, Input.mousePosition, null, out var localPointBeforeScale);

            targetUI.ChangePivotAndHold(localPointBeforeScale / targetUI.rect.size);
            targetUI.localScale = newScale;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(targetUI, Input.mousePosition, null, out var localPointAfterScale);

            targetUI.ChangePivotAndHold(oldPivot);
        }
    }

    void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;

        Rect rect = new(0, 0, width, height);

        GUIStyle fpsstyle = new();
        fpsstyle.alignment = TextAnchor.LowerCenter;
        fpsstyle.fontSize = 24;
        fpsstyle.normal.textColor = Color.black;
        fpsstyle.fontStyle = FontStyle.Bold;

        string text = "";
        text += "Mouse Scroll Wheel Zoom";
        GUI.Label(rect, text, fpsstyle);
    }
}
