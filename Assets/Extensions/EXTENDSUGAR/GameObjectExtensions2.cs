#if EXTENDSUGAR

using UnityEngine;

public static partial class GameObjectExtensions
{
    public static void Activate(this GameObject go)
    {
        go.SetActive(true);
    }

    public static void Deactivate(this GameObject go)
    {
        go.SetActive(false);
    }

    public static void ToggleActive(this GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
#endif
