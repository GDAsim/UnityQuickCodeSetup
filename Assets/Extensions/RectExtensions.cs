using UnityEngine;

public static class RectExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns a rect that encapsulate the point
    /// </summary>
    public static Rect Encapsulate(this Rect rect, Vector2 point)
    {
        var xmin = Mathf.Min(rect.min.x, rect.max.x, point.x);
        var xmax = Mathf.Max(rect.min.x, rect.max.x, point.x);
        var ymin = Mathf.Min(rect.min.y, rect.max.y, point.y);
        var ymax = Mathf.Max(rect.min.y, rect.max.y, point.y);
        return Rect.MinMaxRect(xmin, ymin, xmax, ymax);
    }


    /// <summary>
    /// Returns a rect that encapsulate the rect
    /// </summary>
    public static Rect Encapsulate(this Rect rect, Rect other)
    {
        var xmin = Mathf.Min(rect.min.x, rect.max.x, other.min.x, other.max.x);
        var xmax = Mathf.Max(rect.min.x, rect.max.x, other.min.x, other.max.x);
        var ymin = Mathf.Min(rect.min.y, rect.max.y, other.min.y, other.max.y);
        var ymax = Mathf.Max(rect.min.y, rect.max.y, other.min.y, other.max.y);
        return Rect.MinMaxRect(xmin, ymin, xmax, ymax);
    }

    /// <summary>
    /// Returns a rect that encapsulate list of rects
    /// </summary>
    public static Rect Encapsulate(this Rect rect, params Rect[] others)
    {
        Rect rectFinal = rect;
        for (int i = 0; i < others.Length; i++)
        {
            var other = others[i];
            var xmin = Mathf.Min(rect.min.x, rect.max.x, other.min.x, other.max.x);
            var xmax = Mathf.Max(rect.min.x, rect.max.x, other.min.x, other.max.x);
            var ymin = Mathf.Min(rect.min.y, rect.max.y, other.min.y, other.max.y);
            var ymax = Mathf.Max(rect.min.y, rect.max.y, other.min.y, other.max.y);

            rectFinal = Rect.MinMaxRect(xmin, ymin, xmax, ymax);
        }
        return rectFinal;
    }

    /// <summary>
    /// Extends/shrinks rect by offset
    /// </summary>
    public static Rect Extend(this Rect rect, RectOffset offset)
    {
        if (offset == null) return rect;

        rect.x -= offset.left;
        rect.y -= offset.top;
        rect.width += offset.left + offset.right;
        rect.height += offset.top + offset.bottom;
        return rect;
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Get a Random Position On Rect
    /// </summary>
    public static Vector2 RandomPosition(this Rect rect)
    {
        return new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Get a Random SubRect From Rect
    /// </summary>
    public static Rect RandomSubRect(this Rect rect, float minWidth, float minHeight)
    {
        minWidth = Mathf.Min(rect.width, minWidth);
        minHeight = Mathf.Min(rect.height, minHeight);

        var halfWidth = minWidth / 2f;
        var halfHeight = minHeight / 2f;

        var centerX = Random.Range(rect.xMin + halfWidth, rect.xMax - halfWidth);
        var centerY = Random.Range(rect.yMin + halfHeight, rect.yMax - halfHeight);

        return new Rect(centerX - halfWidth, centerY - halfHeight, minWidth, minHeight);
    }

    //====================================================================================================
    //====================================================================================================
}