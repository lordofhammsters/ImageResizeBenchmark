using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using NetVips;

namespace ImageResizeBenchmark
{
    //[SimpleJob(RuntimeMoniker.Net461)]
    [MemoryDiagnoser]
    public class ImageResize
    {
        private const string FileNameInJpgPath = "C:\\Work\\in.jpg";
        private const string FileNameOutJpgPath = "C:\\Work\\out.jpg";

        private const string FileNameInPngPath = "C:\\Work\\in.png";
        private const string FileNameOutPngPath = "C:\\Work\\out.png";
        

        [IterationSetup]
        private void CleanUp()
        {
            File.Delete(FileNameOutJpgPath);
            File.Delete(FileNameOutPngPath);
        }
        
        #region Jpeg

        [Benchmark]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 300, 300)]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 700, 700)]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 1000, 1000)]
        public void ResizeNetVipsQuant7(string fileNameIn, string fileNameOut, int width, int height)
        {
            var options = new VOption()
            {
                {"Q", 80}, {"optimize_coding", true}, {"strip", true}, {"interlace", true},
                {"trellis_quant", true},
                {"overshoot_deringing", true},
                {"optimize_scans", true},
                {"quant_table", 7}
            };

            using (var image = NetVips.Image.Thumbnail(fileNameIn, width, height))
            {
                image.WriteToFile(fileNameOut, options);
            }
        }
        

        [Benchmark]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 300, 300)]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 700, 700)]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 1000, 1000)]
        public void ResizeNetVipsQ85(string fileNameIn, string fileNameOut, int width, int height)
        {
            var options = new VOption()
            {
                {"Q", 85}, {"optimize_coding", true}, {"strip", true}, {"interlace", true},
                {"trellis_quant", true},
                {"overshoot_deringing", true},
                {"optimize_scans", true}
            };

            using (var image = NetVips.Image.Thumbnail(fileNameIn, width, height))
            {
                image.WriteToFile(fileNameOut, options);
            }
        }

        #endregion
        
        #region PNG

        [Benchmark]
        [Arguments(FileNameInPngPath, FileNameOutPngPath, 300, 300)]
        [Arguments(FileNameInPngPath, FileNameOutPngPath, 700, 700)]
        [Arguments(FileNameInPngPath, FileNameOutPngPath, 1000, 1000)]
        public void ResizeNetVips(string fileNameIn, string fileNameOut, int width, int height)
        {
            var options = new VOption() {{"Q", 90}};

            using (var image = NetVips.Image.Thumbnail(fileNameIn, width, height))
            {
                image.WriteToFile(fileNameOut, options);
            }
        }

        #endregion



        [Benchmark]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 300, 300)]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 700, 700)]
        [Arguments(FileNameInJpgPath, FileNameOutJpgPath, 1000, 1000)]
        [Arguments(FileNameInPngPath, FileNameOutPngPath, 300, 300)]
        [Arguments(FileNameInPngPath, FileNameOutPngPath, 700, 700)]
        [Arguments(FileNameInPngPath, FileNameOutPngPath, 1000, 1000)]
        public void ResizeSystemDrawing(string fileNameIn, string fileNameOut, int width, int height)
        {
            using (var image = System.Drawing.Image.FromFile(fileNameIn))
            {
                SaveResizePhotoFile(fileNameOut, width, height, image, 90);
            }
        }


        #region help methods

        private static void SaveResizePhotoFile(string resultPath, int maxWidth, int maxHeight, System.Drawing.Image image, long? quality = null, bool isRotated = false)
        {
            double resultWidth = image.Width;  // 0;
            double resultHeight = image.Height; // 0;

            if ((maxHeight != 0) && (image.Height > maxHeight))
            {
                resultHeight = maxHeight;
                resultWidth = (image.Width * resultHeight) / image.Height;
            }

            if ((maxWidth != 0) && (resultWidth > maxWidth))
            {
                resultHeight = (resultHeight * maxWidth) / resultWidth;
                resultWidth = maxWidth;
            }
            
            using (var result = new Bitmap((int)resultWidth, (int)resultHeight))
            {
                result.MakeTransparent();
                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(image, 0, 0, (int)resultWidth, (int)resultHeight);

                    graphics.Flush();
                    var ext = Path.GetExtension(resultPath);
                    var encoder = GetEncoder(ext);

                    using (var myEncoderParameters = new EncoderParameters(3))
                    {
                        myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality.Value);
                        myEncoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, (int)EncoderValue.ScanMethodInterlaced);
                        myEncoderParameters.Param[2] = new EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, (int)EncoderValue.RenderProgressive);

                        using (var stream = new FileStream(resultPath, FileMode.Create))
                        {
                            result.Save(stream, encoder, myEncoderParameters);
                            stream.Close();
                        }
                    }
                }
            }
        }

        private static ImageCodecInfo GetEncoder(string fileExt)
        {
            fileExt = fileExt.TrimStart(".".ToCharArray()).ToLower().Trim();

            //return CacheManager.Get("GetEncoder" + fileExt, () =>
            //{
            string mimeType;
            switch (fileExt)
            {
                case "jpg":
                case "jpeg":
                    mimeType = "image/jpeg";
                    break;
                case "png":
                    mimeType = "image/png";
                    break;
                case "gif":
                    mimeType = "image/gif";
                    break;
                default:
                    mimeType = "image/jpeg";
                    break;
            }

            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(x => x.MimeType == mimeType);
            //});
        }

        #endregion
    }
}
