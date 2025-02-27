using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static  class ListExtensions : MonoBehaviour
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Pretty format a list as "[ e1, e2, e3, ..., en ]".
    /// </summary>
    public static string ToStringFull<T>(this List<T> predicate)
    {
        if (predicate == null) return null;
        if (predicate.Count == 0) return "[]";

        StringBuilder sb = new StringBuilder();

        sb.Append("[ ");

        for (int i = 0; i < predicate.Count - 1; i++)
        {
            sb.Append(predicate[i].ToString());
            sb.Append(", ");
        }

        sb.Append(predicate[predicate.Count - 1].ToString());
        sb.Append(" ]");

        return sb.ToString();
    }

    //====================================================================================================
    //====================================================================================================
}
