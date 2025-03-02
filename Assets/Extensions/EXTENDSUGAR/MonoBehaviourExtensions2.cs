#if EXTENDSUGAR

using UnityEngine;

public static partial class MonoBehaviourExtensions2
{
    /// <summary>
    /// Quick method to start coroutine to rebuild unity UI layout
    /// Uses RectTransformExtensions
    /// </summary>
    public static void ForceRebuildLayoutImmediate_Delay(this MonoBehaviour script, RectTransform rectTransform, float delay)
    {
        script.StartCoroutine(RectTransformExtensions.ForceRebuildLayoutImmediate(rectTransform, delay));
    }
}
#endif