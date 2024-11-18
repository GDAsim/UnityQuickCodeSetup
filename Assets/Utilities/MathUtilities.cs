using System;
using UnityEngine;

public static class MathUtilities 
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Convert horizontal fov value to vertical fov value
    /// </summary>
    public static double HorizontalToVerticalFov(double h_fov, double screenWidth, double screenHeight)
    {
        return 2.0 * Math.Atan(Math.Tan(h_fov * 0.5 * Mathf.Deg2Rad) * screenHeight / screenWidth) * Mathf.Rad2Deg;
    }

    /// <summary>
    /// Convert vertical fov value to horizontal fov value
    /// </summary>
    public static double VerticalToHorizontalFov(double v_fov, double screenWidth, double screenHeight)
    {
        return 2.0 * Math.Atan(Math.Tan(v_fov * 0.5 * Mathf.Deg2Rad) * screenWidth / screenHeight) * Mathf.Rad2Deg;
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Safe version to prevent value being out of range by clamping
    /// </summary>
    public static double Safe_Acos(double d)
    {
        return Math.Acos(Math.Min(1.0, Math.Max(-1.0, d)));
    }

    /// <summary>
    /// Safe version to prevent value being out of range by clamping
    /// </summary>
    public static double Safe_Asin(double d)
    {
        return Math.Asin(Math.Min(1.0, Math.Max(-1.0, d)));
    }

    /// <summary>
    /// Safe version to prevent value being out of range by clamping
    /// </summary>
    public static float Safe_Acos(float f)
    {
        return Mathf.Acos(Mathf.Min(1.0f, Mathf.Max(-1.0f, f)));
    }

    /// <summary>
    /// Safe version to prevent value being out of range by clamping
    /// </summary>
    public static float Safe_Asin(float f)
    {
        return Mathf.Asin(Mathf.Min(1.0f, Mathf.Max(-1.0f, f)));
    }

    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns if number is finite
    /// </summary>
    public static bool IsFinite(float f)
    {
        return !(float.IsInfinity(f) || float.IsNaN(f));
    }

    /// <summary>
    /// Returns if number is finite
    /// </summary>
    public static bool IsFinite(double d)
    {
        return !(double.IsInfinity(d) || double.IsNaN(d));
    }

    //====================================================================================================
    //====================================================================================================
}