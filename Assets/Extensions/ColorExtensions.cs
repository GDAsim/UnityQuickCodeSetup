using UnityEngine;

public static class ColorExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// Returns the average color in each channel R,G,B
    /// </summary>
    public static Color CombineColors(this Color color, params Color[] otherColors)
    {
        foreach (Color c in otherColors)
        {
            color += c;
        }
        color /= otherColors.Length + 1;

        return color;
    }

    /// <summary>
    /// Returns color as HSV in RGB channel
    /// </summary>
    public static Color ToHSV(
         this Color color,  // color to transform
         float H,      // hue shift (in degrees)
         float S,      // saturation multiplier (scalar)
         float V)      // value multiplier (scalar)
    {

        float VSU = V * S * Mathf.Cos(H * Mathf.PI / 180);
        float VSW = V * S * Mathf.Sin(H * Mathf.PI / 180);

        Color col = new();
        col.r = (.299f * V + .701f * VSU + .168f * VSW) * color.r
                + (.587f * V - .587f * VSU + .330f * VSW) * color.g
                + (.114f * V - .114f * VSU - .497f * VSW) * color.b;
        col.g = (.299f * V - .299f * VSU - .328f * VSW) * color.r
                + (.587f * V + .413f * VSU + .035f * VSW) * color.g
                + (.114f * V - .114f * VSU + .292f * VSW) * color.b;
        col.b = (.299f * V - .300f * VSU + 1.25f * VSW) * color.r
                + (.587f * V - .588f * VSU - 1.05f * VSW) * color.g
                + (.114f * V + .886f * VSU - .203f * VSW) * color.b;
        col.a = 1f;

        if (col.r < 0) col.r = 0;
        if (col.g < 0) col.g = 0;
        if (col.b < 0) col.b = 0;

        return col;
    }

    //====================================================================================================
    //====================================================================================================
}