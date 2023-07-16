using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanLoaiTraiCam.Utilities.Extensions
{
    internal static class ImageExtension
    {
        public static Bitmap ToGrayScale(this Bitmap bmp)
        {
            var image = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayValue = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    Color grayPixel = Color.FromArgb(grayValue, grayValue, grayValue);
                    image.SetPixel(x, y, grayPixel);
                }
            }
            return image;
        }
    }
}
