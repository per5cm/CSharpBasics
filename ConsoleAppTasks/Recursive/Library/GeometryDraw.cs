using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive.Library
{
    internal class GeometryDraw
    {
        public static void DrawImage()
        {
            Rgba32 white = new Rgba32(255, 255, 255);
            Rgba32 black = new Rgba32(0, 0, 0);

            int squareSize = 100;

            Image<Rgba32> img = new(8 * squareSize, 8 * squareSize);

            //Rgba32 c1 = new Rgba32(0, 0, 255);

            //Geometry.Background(img, c1);

            //for (int i = 0; i < 10; i++)
            //{
            //    int x = RandomNumberGenerator.GetInt32(19) + 1;
            //    Rgba32 c2 = new Rgba32(x*10, x*12, x*20, 200);

            //    Geometry.FillRect(img, c2, x, x, x + 20, x + 20);
            //}

            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if ((row + column) % 2 == 0)
                    {
                        Geometry.FillRect(img, white, column * squareSize, row * squareSize, squareSize, squareSize);
                    }
                    else
                    {
                        Geometry.FillRect(img, black, column * squareSize, row * squareSize, squareSize, squareSize);
                    }
                }
                Console.WriteLine();
            }

            string timeStamp = DateTime.Now.ToString("fff_dd.MM.yyyy");
            string fileName = $"image_{timeStamp}.png";

            string dir = "Images";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, fileName);

            img.Save(path, new PngEncoder());
        }
    }
}
