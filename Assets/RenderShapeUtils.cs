using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderShapeUtils
{
    public static Texture2D DrawCircle(ref Texture2D tex, Color color, int x, int y, int radius = 3)
    {
        float rSquared = radius * radius;

        for (int u = x - radius; u < x + radius + 1; u++)
        for (int v = y - radius; v < y + radius + 1; v++)
            if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared)
                tex.SetPixel(u, v, color);

        return tex;
    }
    
    public static Texture2D DrawHollowCircle(ref Texture2D tex, Color color, int x, int y, int radius = 3, float borderWidth = 1)
    {
        float rSquared = radius * radius;

        for (int u = x - radius; u < x + radius + 1; u++)
        for (int v = y - radius; v < y + radius + 1; v++)
        {
            float threshold = (x - u) * (x - u) + (y - v) * (y - v);
            if (threshold < rSquared && threshold > rSquared - borderWidth)
            tex.SetPixel(u, v, color);
        }

        return tex;
    }
}
