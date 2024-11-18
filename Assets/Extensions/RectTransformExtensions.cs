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
}
