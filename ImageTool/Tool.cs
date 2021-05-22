using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ImageTool
{
    public class Tool
    {
        public static byte[] getThumbNail(string filename, int multi = 1)
        {
            byte[] data = System.IO.File.ReadAllBytes(filename);

            using (var file = new MemoryStream(data))
            {
                int width = 200 * multi;
                using (var image = Image.FromStream(file, true, true)) /* Creates Image from specified data stream */
                {
                    int X = image.Width;
                    int Y = image.Height;
                    int height = (int)((width * Y) / X);

                    using (var thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero))
                    {
                        var jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/png").First(); /* Returns array of image encoder objects built into GDI+ */
                        using (var encParams = new EncoderParameters(1))
                        {
                            using (var samllfile = new MemoryStream())
                            {
                                long quality = 100;
                                encParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                                thumb.Save(samllfile, jpgInfo, encParams);
                                return samllfile.ToArray();
                            }
                        };
                    };
                };
            };
        }
    }
}