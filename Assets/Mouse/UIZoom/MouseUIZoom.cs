using UnityEngine;

public class MouseUIZoom : MonoBehaviour
{
    [SerializeField] RectTransform targetUI;

    public float zoomSpeed = 1f;

    void Update() => Zoom();

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            Vector3 scaleChange = new Vector3(scrollInput, scrollInput, scrollInput) * zoomSpeed;
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
}
