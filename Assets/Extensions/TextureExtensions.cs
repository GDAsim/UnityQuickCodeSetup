using UnityEngine;

public class TextureExtensions
{
    public static Texture2D DownSample(Texture2D src)
    {
        int width = 1024, height = 512;
        Texture2D dst = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Color[] cs = new Color[width * height];
        for (int x = 0; x < width; ++x)
            for (int y = 0; y < height; ++y)
            {
                int dstIndex = x + y * width;
                Color dstColor = Color.black;

                for (int subX = 0; subX < 4; ++subX)
                    for (int subY = 0; subY < 4; ++subY)
                    {
                        Color srcColor = src.GetPixel(x * 4 + subX, y * 4 + subY);
                        dstColor += srcColor;
                    }

                dstColor /= 16.0f;
                dstColor.a = 1.0f;

                cs[dstIndex] = dstColor;
            }
        dst.SetPixels(cs);
        dst.Apply();

        return dst;
    }
}
