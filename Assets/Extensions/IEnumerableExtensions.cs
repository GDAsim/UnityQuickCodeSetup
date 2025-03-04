using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;

public static class IEnumerableExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Shuffle the ienumbrable and returns the shuffled list
    /// very simple shuffle algo
    /// </summary>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        T[] s = source.ToArray();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            int swapIndex = Random.Range(0, i + 1);
            yield return s[swapIndex];
            s[swapIndex] = s[i];
        }
    }

    /// <summary>
    /// Shuffle the ienumbrable and returns the shuffled list.
    /// Uses Linq OrderBy && System.GUID
    /// </summary>
    public static IEnumerable<T> Shuffle2<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(n => System.Guid.NewGuid());
    }

    //====================================================================================================
    //====================================================================================================


    public static IEnumerable<T> test<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(n => System.Guid.NewGuid());
    }
}