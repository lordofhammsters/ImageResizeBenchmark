using System;
using BenchmarkDotNet.Running;

namespace ImageResizeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ImageResize>();
        }

        private static void MyRun()
        {
            try
            {
                new ImageResize().ResizeSystemDrawing("C:\\Work\\jpgIn.jpg", "C:\\Work\\jpgOut.jpg", 300, 300);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            Console.ReadKey();
        }
    }
}
