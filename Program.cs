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

                var pathIn = "C:\\Work\\in.jpg";
                
                resizer.ResizeSystemDrawing(pathIn, "C:\\Work\\outDrawing.jpg", width, height);
                resizer.ResizeNetVipsQuant7(pathIn, "C:\\Work\\out7.jpg", width, height);
                resizer.ResizeNetVipsQ85(pathIn, "C:\\Work\\out85.jpg", width, height);

                pathIn = "C:\\Work\\in.png";
                resizer.ResizeSystemDrawing(pathIn, "C:\\Work\\outDrawing.png", width, height);
                resizer.ResizeNetVips(pathIn, "C:\\Work\\outNetVips.png", width, height);

                pathIn = "C:\\Work\\in.png";
                resizer.ResizeNetVips(pathIn, "C:\\Work\\out.webp", width, height);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
