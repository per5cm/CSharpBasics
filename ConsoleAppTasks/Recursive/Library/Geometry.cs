using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive.Library
{
    internal class Geometry
    {
        public static void Background (Image<Rgba32> img, Rgba32 c)
        {
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    img[x, y] = c;
                }
            }               
        }

        public static void FillRect(Image<Rgba32> img, Rgba32 c, int x, int y, int width, int height)
        {
            for(int i = x; i < x + width; i++)
            {
                for(int j = y; j < y + height; j++)
                {
                    img[i, j] = c;
                }
            }
        }

        public static void DrawLine(Image<Rgba32> img, Rgba32 color, int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                if (x0 >= 0 && x0 < img.Width && y0 >= 0 && y0 < img.Height)
                    img[x0, y0] = color;

                if (x0 == x1 && y0 == y1) break;

                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x0 += sx; }
                if (e2 < dx) { err += dx; y0 += sy; }
            }
        }
    }
}
