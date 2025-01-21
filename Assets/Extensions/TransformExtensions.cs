using UnityEngine;
public static partial class TransformExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Sets localPosition to Vector3.zero, localRotation to Quaternion.identity, and localScale to Vector3.one
    /// </summary>
    public static void Reset(this Transform t)
    {
        t.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        t.localScale = Vector3.one;
    }

    //====================================================================================================
    //====================================================================================================
}