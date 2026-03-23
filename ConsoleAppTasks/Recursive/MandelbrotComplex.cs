using Recursive.Library;
using Recursive.Library.ComplexStruct;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recursive
{
    internal class MandelbrotComplex
    {
        public static void CreateMandelbrot()
        {
            int breite = 4300, hoehe = 4300;
            uint max = 255;

            double schrittweite = 0.000625;
            double startReal = -2.1, startImag = -1.35;

            // Bild erstellen
            Image<Rgba32> img = new Image<Rgba32>(breite, hoehe);
            //Hintergrung
            Rgba32 bg = new Rgba32(176, 196, 222); // Stahlblau
            Geometry.Background(img, bg);

            for (int yPixel = 0; yPixel < hoehe; yPixel++)
            {
                for (int xPixel = 0; xPixel < breite; xPixel++)
                {
                    double real = startReal + (xPixel * schrittweite);
                    double imag = startImag + (yPixel * schrittweite);

                    Complex c = new(real, imag);

                    uint schwelle = ComplexLibrary.Threshold(c, max);

                    Rgba32 farbe;

                    if (schwelle >= max)

                        farbe = new Rgba32(0, 0, 0); // Farbe Apfelmännchen

                    else
                    {

                        byte r = (byte)((schwelle * 5) % 256);
                        byte g = (byte)((schwelle * 2) % 256);
                        byte b = (byte)((schwelle * 10) % 256);
                        farbe = new Rgba32(r, g, b);
                    }

                    img[xPixel, yPixel] = farbe;
                }
            }

            string pfad = Path.Combine("C:", "Users", "Teilnehmer", "Desktop", "VS", "Uebungsblatter", "Bilderstellung", "PNGs");
            string timeStamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string bildName = $"Mandelbrot_{timeStamp}.png";
            img.Save(Path.Combine(pfad, bildName));

        }
    }
}
