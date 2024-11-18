#if EXTENDSUGAR

public static partial class ObjectExtensions
{
    public static T InstantiateNew<T>(this T source, Vector3 pos, Quaternion rot) where T : Object
    {
        return Object.Instantiate(source, pos, rot);
    }
    public static T InstantiateNew<T>(this T source, Vector3 pos) where T : Object
    {
        return Object.Instantiate(source, pos, Quaternion.identity);
    }
    public static T InstantiateNew<T>(this T source) where T : Object
    {
        return Object.Instantiate(source, Vector3.zero, Quaternion.identity);
    }

    /// <summary>
    /// Calls Destroy if we are in playmode
    /// Calls DestroyImmediate if we are in editor
    /// </summary>

    public static void Destroy(this Object obj, bool destoryAssets = false)
    {
        if (Application.isPlaying)
        {
            Object.DestroyImmediate(obj, destoryAssets);
        }
        else
        {
            Object.Destroy(obj);
        }
    }
}

#endif