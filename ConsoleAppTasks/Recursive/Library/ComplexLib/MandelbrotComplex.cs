using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Recursive.Library.ComplexLib
{
    internal class MandelbrotComplex
    {
        public static void Render()
        {
            const int width = 1900;
            const int height = 1000;
            const uint maxIterations = 1000;
            const double pixelSize = 0.000625;
            const double centerReal = -0.5;
            const double centerImaginary = 0.0;

            // Bild erstellen
            using var image = new Image<Rgba32>(width, height);

            //Hintergrung
            Rgba32 background = new (176, 196, 222); // Stahlblau
            Geometry.Background(image, background);

            for (int yPixel = 0; yPixel < height; yPixel++)
            {
                for (int xPixel = 0; xPixel < width; xPixel++)
                {
                    double real = centerReal - (width / 2.0 * pixelSize) + xPixel * pixelSize;
                    double imaginary = centerImaginary + (height / 2.0 * pixelSize) - yPixel * pixelSize;

                    var complex = new Complex(real, imaginary);
                    uint iteration = ComplexLibrary.Threshold(complex, 2.0, maxIterations);

                    Rgba32 color;

                    if (iteration >= maxIterations)

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
