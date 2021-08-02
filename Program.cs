using System;
using BenchmarkDotNet.Running;

namespace ImageResizeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ImageResize>();

            //Run();
        }

        private static void Run()
        {
            var resizer = new ImageResize();

            try
            {
                var width = 700;
                var height = 700;

                var pathIn = "C:\\Work\\jpgIn.jpg";
                
                resizer.ResizeSystemDrawing(pathIn, "C:\\Work\\jpgOut.jpg", width, height);
                resizer.ResizeNetVipsQuant7(pathIn, "C:\\Work\\jpgOut7.jpg", width, height);
                resizer.ResizeNetVipsQ85(pathIn, "C:\\Work\\jpgOut9.jpg", width, height);

                pathIn = "C:\\Work\\pngIn.png";
                resizer.ResizeSystemDrawing(pathIn, "C:\\Work\\pngOut.png", width, height);
                resizer.ResizeNetVips(pathIn, "C:\\Work\\pngOut7.png", width, height);

                pathIn = "C:\\Work\\pngIn.png";
                resizer.ResizeNetVips(pathIn, "C:\\Work\\pngOut.webp", width, height);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
