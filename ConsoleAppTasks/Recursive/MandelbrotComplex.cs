using Recursive.Library;
using Recursive.Library.ComplexLib;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive
{
    internal class MandelbrotComplex
    {
        public static void Render()
        {
            const int Width = 1900;
            const int Height = 1000;
            const uint MaxIterations = 1000;
            const double PixelSize = 0.000625;
            const double CenterReal = -0.5;
            const double CenterImaginary = 0.0;

            // Bild erstellen
            using var image = new Image<Rgba32>(Width, Height);

            //Hintergrung
            Rgba32 background = new (176, 196, 222); // Stahlblau
            Geometry.Background(image, background);

            for (int yPixel = 0; yPixel < Height; yPixel++)
            {
                for (int xPixel = 0; xPixel < Width; xPixel++)
                {
                    double real = CenterReal - (Width / 2.0 * PixelSize) + xPixel * PixelSize;
                    double imaginary = CenterImaginary + (Height / 2.0 * PixelSize) - yPixel * PixelSize;

                    var complex = new Complex(real, imaginary);
                    uint iteration = ComplexLibrary.Threshold(complex, 2.0, MaxIterations);

                    Rgba32 color;

                    if (iteration >= MaxIterations)

                        color = new Rgba32(0, 0, 0); // Farbe Apfelmännchen

                    else
                    {

                        byte r = (byte)((iteration * 5) % 256);
                        byte g = (byte)((iteration * 2) % 256);
                        byte b = (byte)((iteration * 10) % 256);
                        color = new Rgba32(r, g, b);
                    }

                    image[xPixel, yPixel] = color;
                }
            }

            string imagesDir = "Images";
            Directory.CreateDirectory(imagesDir);

            string timeStamp = DateTime.Now.ToString("fff_dd.MM.yyyy");
            string pictureName = $"Mandelbrot_{timeStamp}.png";
            string fullPath = Path.Combine(imagesDir, pictureName);

            image.SaveAsPng(fullPath);
        }
    }
}
