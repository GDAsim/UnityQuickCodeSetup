using UnityEngine;

public static class BoundsExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// this is faster than unity *.bounds.IntersectRay(ray)
    /// original source https://gamedev.stackexchange.com/a/103714/73429
    /// https://gist.github.com/unitycoder/8d1c2905f2e9be693c78db7d9d03a102
    /// Usage : if (RayBoxIntersect(ray.Origin, ray.Direction, some.bounds.min, some.bounds.max) > 0) {}
    /// </summary>
    public static float IntersectRay(this Bounds b,Vector3 rayPos, Vector3 rayDir)
    {
        Vector3 b_min = b.min;
        Vector3 b_max = b.max;

        float t1 = (b_min.x - rayPos.x) / rayDir.x;
        float t2 = (b_max.x - rayPos.x) / rayDir.x;
        float t3 = (b_min.y - rayPos.y) / rayDir.y;
        float t4 = (b_max.y - rayPos.y) / rayDir.y;
        float t5 = (b_min.z - rayPos.z) / rayDir.z;
        float t6 = (b_max.z - rayPos.z) / rayDir.z;

        float aMin = t1 < t2 ? t1 : t2;
        float bMin = t3 < t4 ? t3 : t4;
        float cMin = t5 < t6 ? t5 : t6;

        float aMax = t1 > t2 ? t1 : t2;
        float bMax = t3 > t4 ? t3 : t4;
        float cMax = t5 > t6 ? t5 : t6;

        float fMax = aMin > bMin ? aMin : bMin;
        float fMin = aMax < bMax ? aMax : bMax;

        float t7 = fMax > cMin ? fMax : cMin;
        float t8 = fMin < cMax ? fMin : cMax;

        float t9 = (t8 < 0 || t7 > t8) ? -1 : t7;

        return t9;
    }

    //====================================================================================================
    //====================================================================================================
}