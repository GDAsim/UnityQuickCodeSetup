using System.Collections.Generic;
using UnityEngine;

public static class RectTransformUtilities
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Return true if mouse is clicked outside of RectTransforms
    /// </summary>
    public static bool IsMouseClickedOutsideOfRect(RectTransform rt)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rt.gameObject.activeSelf && RectTransformUtility.RectangleContainsScreenPoint(rt, Input.mousePosition))
            {
                return false;
            }
            return true;
        }
        return false;
    }


    /// <summary>
    /// Return true if mouse is clicked outside of list of RectTransforms
    /// </summary>
    public static bool IsMouseClickedOutsideOfRects(List<RectTransform> rts)
    {
        if (rts == null || rts.Count == 0) return false;

        if (Input.GetMouseButtonDown(0))
        {
            foreach (RectTransform rt in rts)
            {
                if (rt.gameObject.activeSelf && RectTransformUtility.RectangleContainsScreenPoint(rt, Input.mousePosition))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    //====================================================================================================
    //====================================================================================================

}