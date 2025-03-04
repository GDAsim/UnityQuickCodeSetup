using System.Collections.Generic;
using UnityEngine;

public static class ListVectorExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Get Average Vector2 from list of Vector2s
    /// </summary>
    public static Vector2 Average(this List<Vector2> list)
    {
        var sum = new Vector2();
        var count = list.Count;
        for (var i = 0; i < count; i++)
        {
            sum += list[i];
        }
        return sum / count;
    }

    /// <summary>
    /// Get Average Vector3 from list of Vector2s
    /// </summary>
    public static Vector3 Average(this List<Vector3> list)
    {
        var sum = new Vector3();
        var count = list.Count;
        for (var i = 0; i < count; i++)
        {
            sum += list[i];
        }
        return sum / count;
    }

    /// <summary>
    /// Get Average Vector4 from list of Vector2s
    /// </summary>
    public static Vector4 Average(this List<Vector4> list)
    {
        var sum = new Vector4();
        var count = list.Count;
        for (var i = 0; i < count; i++)
        {
            sum += list[i];
        }
        return sum / count;
    }

    //====================================================================================================
    //====================================================================================================
}
