using System;
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




[Serializable]
public struct TransformData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public TransformData(Transform transform)
    {
        Position = transform.localPosition;
        Rotation = transform.localRotation;
        Scale = transform.localScale;
    }

    public void ApplyTo(Transform transform)
    {
        transform.localPosition = Position;
        transform.localRotation = Rotation;
        transform.localScale = Scale;
    }
}
