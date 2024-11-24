using UnityEngine;

public class MouseUIPan : MonoBehaviour
{
    [SerializeField] RectTransform targetUI;

    public float panSpeed = 1f;

    void Update() => Pan();


    Vector3 lastMousePos;

    /// <summary>
    /// Pan using Middle Mouse
    /// </summary>
    void Pan()
    {
        if (Input.GetMouseButton(2))
        {
            var mousePos = Input.mousePosition;

            Vector3 mouseDelta = mousePos - lastMousePos;
            Vector3 movement = new Vector3(mouseDelta.x, mouseDelta.y, 0) * panSpeed;

            targetUI.position += movement;
            lastMousePos = mousePos;
        }
        else
        {
            lastMousePos = Input.mousePosition;
        }
    }




    /// <summary>
    /// Changes Pivot of UI Object, and hold object in place (does not having the object moving, position values changes to achive this)
    /// 
    /// Context:
    /// In Unity Inspector, while changing pivot, it also automatically changes the position accordingly so that the object stays in place while pivot changes
    /// In Unity Inspector Debug mode, changing the pivot does not change the position, hence the object will move.
    /// Changing Pivot in script is the same as Unity Inspector Debug Mode.
    /// </summary>
    void ChangePivotAndHold(RectTransform rt, Vector2 newPivot)
    {
        var oldPivot = rt.pivot;

        rt.pivot = newPivot;

        var pivotDiff = newPivot - oldPivot;
        var offset = pivotDiff * (rt.rect.size * rt.localScale);

        rt.anchoredPosition += offset;
    }
}
