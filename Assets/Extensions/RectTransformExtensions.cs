using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class RectTransformExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Rebuild Unity UI Layout system after a delay
    /// This is required to fix bugs regarding UI layout + contentsize fitter updates not being done correctly
    /// </summary>
    public static IEnumerator ForceRebuildLayoutImmediate(RectTransform rectTransform, float delay)
    {
        yield return new WaitForSeconds(delay);

        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns the the rect as world space coordinate
    /// Note: should be Used for UI Recttransform Overlays only
    /// </summary>
    public static Rect GetWorldRect(this RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        if (rt.rotation != Quaternion.identity) Debug.LogWarning("GetWorldRect Works on NonRotated RectTransform");

        return new Rect(corners[0], corners[2] - corners[0]);
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Changes Pivot of UI Object, and hold object in place (does not having the object moving, position values changes to achive this)
    /// 
    /// Context:
    /// In Unity Inspector, while changing pivot, it also automatically changes the position accordingly so that the object stays in place while pivot changes
    /// In Unity Inspector Debug mode, changing the pivot does not change the position, hence the object will move.
    /// Changing Pivot in script is the same as Unity Inspector Debug Mode.
    /// </summary>
    public static void ChangePivotAndHold(this RectTransform rt, Vector2 newPivot)
    {
        var oldPivot = rt.pivot;

        rt.pivot = newPivot;

        var pivotDiff = newPivot - oldPivot;
        var offset = pivotDiff * (rt.rect.size * rt.localScale);

        rt.anchoredPosition += offset;
    }

    //====================================================================================================
}
