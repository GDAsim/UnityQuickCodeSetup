#if EXTENDSUGAR

using UnityEngine;

public static partial class TransformExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Destroys all child of parent gameobject 
    /// </summary>
    public static void ClearContainer(this Transform transform)
    {
        transform.gameObject.DestroyAllChildren();
    }

    /// <summary>
    /// Destroys all child of parent gameobject 
    /// </summary>
    public static void ClearContainerImmediate(this Transform transform)
    {
        transform.gameObject.DestroyAllChildrenImmediate();
    }

    //====================================================================================================
    //====================================================================================================
}

#endif