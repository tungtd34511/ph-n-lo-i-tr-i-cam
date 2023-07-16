﻿using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PhanLoaiTraiCam.Utilities.Extensions
{
    internal static class ImageExtension
    {
        private static double[,] angles;
        private static Color NotBorder = Color.FromArgb(0, 0, 0);

        private static double[,] StandartGaussMatrix = new double[,] {
                                    { 2, 4, 5, 4, 2 },
                                    { 4, 9, 12, 9, 4 },
                                    { 5, 12, 15, 12, 5 },
                                    { 4, 9, 12, 9, 4 },
                                    { 2, 4, 5, 4, 2 } };

        private static int[,] SobelX = new int[,] {
                                 { 1, 2, 1 },
                                 { 0, 0, 0 },
                                 { -1, -2, -1 } };

        private static int[,] SobelY = new int[,] {
                                 { -1, 0, 1 },
                                 { -2, 0, 2 },
                                 { -1, 0, 1 } };

        private static int[,] laplas = new int[,] {
                                 { 0, 1, 0 },
                                 { 1, -4, 1 },
                                 { 0, 1, 0 } };
        private static Color WhiteBorder = Color.FromArgb(255, 255, 255);
        public static Bitmap ToGrayScale(this Bitmap bmp)
        {
            var image = (Bitmap)bmp.Clone();
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
        public static Bitmap BorderRestoration(this Bitmap bmp, int rad)
        {
            Bitmap resbmp = new Bitmap(bmp);

            for (int i = rad; i < bmp.Width - rad; i++)
            {
                for (int j = rad; j < bmp.Height - rad; j++)
                {
                    if (bmp.GetPixel(i, j).B == 255)
                    {
                        for (int n = 1; n < rad; n++)
                        {
                            if (bmp.GetPixel(i - n, j - n).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i - n + k, j - n + k).B == 0)
                                        resbmp.SetPixel(i - n + k, j - n + k, WhiteBorder);
                            if (bmp.GetPixel(i - n, j).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i - n + k, j).B == 0)
                                        resbmp.SetPixel(i - n + k, j, WhiteBorder);
                            if (bmp.GetPixel(i - n, j + n).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i - n + k, j + n - k).B == 0)
                                        resbmp.SetPixel(i - n + k, j + n - k, WhiteBorder);

                            if (bmp.GetPixel(i, j - n).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i + k, j - n + k).B == 0)
                                        resbmp.SetPixel(i + k, j - n + k, WhiteBorder);
                            if (bmp.GetPixel(i, j + n).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i + k, j + n - k).B == 0)
                                        resbmp.SetPixel(i + k, j + n - k, WhiteBorder);

                            if (bmp.GetPixel(i + n, j - n).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i + n - k, j - n + k).B == 0)
                                        resbmp.SetPixel(i - n + k, j - n + k, WhiteBorder);
                            if (bmp.GetPixel(i + n, j).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i + n - k, j).B == 0)
                                        resbmp.SetPixel(i + n - k, j, WhiteBorder);
                            if (bmp.GetPixel(i - n, j + n).B == 255)
                                for (int k = 1; k < n; k++)
                                    if (bmp.GetPixel(i + n - k, j + n - k).B == 0)
                                        resbmp.SetPixel(i + n - k, j + n - k, WhiteBorder);
                        }
                    }
                }
            }
            return resbmp;
        }

        public static Bitmap ImageToGrey(this Bitmap bmp)
        {
            Bitmap resbmp = new Bitmap(bmp.Width, bmp.Height);
            byte brightness;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    brightness = (byte)(0.299 * bmp.GetPixel(i, j).R + 0.587 * bmp.GetPixel(i, j).G + 0.114 * bmp.GetPixel(i, j).B);
                    resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
                }
            }
            return resbmp;
        }

        public static Bitmap GaussianFilter(this Bitmap bmp, double sigma)
        {
            Bitmap resbmp = new Bitmap(bmp);
            for (int i = 2; i < bmp.Width - 2; i++)
            {
                for (int j = 2; j < bmp.Height - 2; j++)
                {
                    int[,] mas = new int[5, 5];

                    for (int k = -2; k < 3; k++)
                        for (int l = -2; l < 3; l++)
                            mas[k + 2, l + 2] = bmp.GetPixel(i + k, j + l).B;


                    int brightness = (int)MultGauss(mas, sigma);
                    resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
                }
            }
            return resbmp;
        }


        private static double MultGauss(int[,] matr, double sigma)
        {
            double br = 0;
            double[,] gauss;
            if (sigma == 0)
                gauss = StandartGaussMatrix;
            else
                gauss = GetGaussMatrBySigma(sigma);
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(0); j++)
                {
                    br += (matr[i, j] * (gauss[i, j]));
                }
            if (sigma == 0)
                br = br / 159;
            return br;
        }

        private static double[,] GetGaussMatrBySigma(double sigma)
        {
            double[,] gauss = new double[5, 5];
            for (int i = 1; i <= 5; i++)
                for (int j = 1; j <= 5; j++)
                {
                    double e = Math.Exp(-(Math.Pow(i - 3, 2) + Math.Pow(j - 3, 2)) / (2 * Math.Pow(sigma, 2)));
                    gauss[i - 1, j - 1] = (e / (2 * Math.PI * Math.Pow(sigma, 2)));
                }
            return gauss;
        }

        public static Bitmap SobelConvolve(this Bitmap bmp)
        {
            Bitmap resbmp = new Bitmap(bmp.Width, bmp.Height);
            angles = new double[bmp.Width, bmp.Height];
            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    int[,] mas = new int[3, 3];

                    for (int k = -1; k < 2; k++)
                        for (int l = -1; l < 2; l++)
                            mas[k + 1, l + 1] = bmp.GetPixel(i + k, j + l).B;

                    int ggx = SobelMult(mas, SobelX);
                    int ggy = SobelMult(mas, SobelY);

                    byte brightness = (byte)Math.Sqrt(Math.Pow(ggx, 2) + Math.Pow(ggy, 2));

                    resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));

                    double a = Math.Atan2(ggy, ggx) * 180 / Math.PI;
                    angles[i, j] = GetAngleMult45(a);
                }
            }
            return resbmp;
        }

        private static int SobelMult(int[,] matr, int[,] g)
        {
            int br = 0;
            for (int i = 0; i < g.GetLength(0); i++)
                for (int j = 0; j < g.GetLength(0); j++)
                    br += (matr[i, j] * g[i, j]);
            return br;
        }

        private static double GetAngleMult45(double angle)
        {
            double a = Math.Round(angle / 45) * 45;
            if (a < 0)
                a += 360;
            return a;
        }

        public static Bitmap NonMaximumSuppression(this Bitmap bmp)
        {
            Bitmap resbmp = new Bitmap(bmp);
            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    double angle = angles[i, j];
                    if (angle == 0 || angle == 180)
                    {
                        if ((bmp.GetPixel(i - 1, j).B > bmp.GetPixel(i, j).B || bmp.GetPixel(i, j).B < bmp.GetPixel(i + 1, j).B))
                        {
                            resbmp.SetPixel(i, j, NotBorder);
                        }
                    }
                    if (angle == 90 || angle == 270)
                    {
                        if ((bmp.GetPixel(i, j - 1).B > bmp.GetPixel(i, j).B || bmp.GetPixel(i, j).B < bmp.GetPixel(i, j + 1).B))
                        {
                            resbmp.SetPixel(i, j, NotBorder);
                        }
                    }
                    if (angle == 45 || angle == 225)
                    {
                        if ((bmp.GetPixel(i - 1, j + 1).B > bmp.GetPixel(i, j).B || bmp.GetPixel(i, j).B < bmp.GetPixel(i + 1, j - 1).B))
                        {
                            resbmp.SetPixel(i, j, NotBorder);
                        }
                    }
                    if (angle == 135 || angle == 315)
                    {
                        if ((bmp.GetPixel(i + 1, j + 1).B > bmp.GetPixel(i, j).B || bmp.GetPixel(i, j).B < bmp.GetPixel(i - 1, j - 1).B))
                        {
                            resbmp.SetPixel(i, j, NotBorder);
                        }
                    }
                }
            }
            return resbmp;
        }

        public static Bitmap DoubleThreshold(this Bitmap bmp, int top, int low)
        {
            Bitmap resbmp = new Bitmap(bmp);
            byte brightness;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    brightness = bmp.GetPixel(i, j).G;
                    Color color;
                    if (brightness < low)
                    {
                        color = NotBorder;
                    }
                    else
                    {
                        if (brightness > top)
                        {
                            color = WhiteBorder;
                        }
                        else
                            color = Color.FromArgb(100, 100, 100);
                    }
                    resbmp.SetPixel(i, j, color);
                }
            }
            return resbmp;
        }

        public static Bitmap EdgeTracking(this Bitmap bmp)
        {
            Bitmap resbmp = new Bitmap(bmp);

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    byte br = bmp.GetPixel(i, j).B;
                    if (br == 100)
                    {
                        bool check = true;
                        for (int x = -1; x < 2; x++)
                            if (check)
                            {
                                for (int y = -1; y < 2; y++)
                                    if (angles[i, j] == angles[i + x, j + y] && bmp.GetPixel(i + x, j + y).B == 255)
                                    {
                                        check = true;
                                    }
                                    else
                                    {
                                        check = false;
                                        break;
                                    }
                            }
                            else
                                break;
                        if (check)
                            resbmp.SetPixel(i, j, WhiteBorder);
                        else
                            resbmp.SetPixel(i, j, NotBorder);
                    }
                }
            }
            return resbmp;
        }


        public static Bitmap FadeDetection(Bitmap bmp)
        {
            Bitmap resbmp = new Bitmap(bmp);

            angles = new double[bmp.Width, bmp.Height];

            byte brightness = (byte)Math.Sqrt(Math.Pow((bmp.GetPixel(0, 0).G - bmp.GetPixel(1, 0).G), 2) + Math.Pow((bmp.GetPixel(0, 0).G - bmp.GetPixel(0, 1).G), 2));
            resbmp.SetPixel(0, 0, Color.FromArgb(brightness, brightness, brightness));

            for (int i = 1; i < bmp.Width; i++)
            {
                for (int j = 1; j < bmp.Height; j++)
                {

                    int gx = (bmp.GetPixel(i, j).G - bmp.GetPixel(i - 1, j).G);
                    int gy = (bmp.GetPixel(i, j).G - bmp.GetPixel(i, j - 1).G);

                    brightness = (byte)Math.Sqrt(Math.Pow(gx, 2) + Math.Pow(gy, 2));
                    resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));

                    double a = Math.Atan((double)gy / gx) * 180 / Math.PI;
                    angles[i, j] = GetAngleMult45(a);
                }
            }

            //Крайние точки
            //нижняя и верхняя часть
            for (int i = 1; i < bmp.Width - 1; i++)
            {
                brightness = (byte)Math.Sqrt(Math.Pow((bmp.GetPixel(i, bmp.Height - 1).G - bmp.GetPixel(i - 1, bmp.Height - 1).G), 2));
                resbmp.SetPixel(i, bmp.Height - 1, Color.FromArgb(brightness, brightness, brightness));

                brightness = (byte)Math.Sqrt(Math.Pow((bmp.GetPixel(i, 0).G - bmp.GetPixel(i - 1, 0).G), 2) + Math.Pow((bmp.GetPixel(i, 0).G - bmp.GetPixel(i, 1).G), 2));
                resbmp.SetPixel(i, 0, Color.FromArgb(brightness, brightness, brightness));
            }

            //правая и левая часть
            for (int i = 1; i < bmp.Height - 1; i++)
            {
                brightness = (byte)Math.Sqrt(Math.Pow((bmp.GetPixel(bmp.Width - 1, i).G - bmp.GetPixel(bmp.Width - 1, i - 1).G), 2) + Math.Pow((bmp.GetPixel(bmp.Width - 2, i).G - bmp.GetPixel(bmp.Width - 2, i - 1).G), 2));
                resbmp.SetPixel(bmp.Width - 1, i, Color.FromArgb(brightness, brightness, brightness));

                brightness = (byte)Math.Sqrt(Math.Pow((bmp.GetPixel(0, i).G - bmp.GetPixel(0, i - 1).G), 2) + Math.Pow((bmp.GetPixel(0, i).G - bmp.GetPixel(1, i).G), 2));
                resbmp.SetPixel(0, i, Color.FromArgb(brightness, brightness, brightness));
            }
            return resbmp;
        }

        public static Bitmap FadeLaplassThreshold(Bitmap bmp, int border)
        {
            Bitmap resbmp = new Bitmap(bmp);
            byte brightness;
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    brightness = bmp.GetPixel(i, j).B;
                    if (brightness < border)
                        brightness = 0;
                    else
                        brightness = 255;
                    resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
                }
            }
            return resbmp;
        }

        public static Bitmap LaplassianDetection(Bitmap bmp)
        {
            Bitmap resbmp = new Bitmap(bmp);

            //byte brightness = (byte)Math.Sqrt(Math.Pow((bmp.GetPixel(0, 0).G - bmp.GetPixel(1, 0).G), 2) + Math.Pow((bmp.GetPixel(0, 0).G - bmp.GetPixel(0, 1).G), 2));
            //resbmp.SetPixel(0, 0, Color.FromArgb(brightness, brightness, brightness));

            byte brightness;
            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {

                    int gx = (bmp.GetPixel(i + 1, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i - 1, j).G);
                    int gy = (bmp.GetPixel(i, j + 1).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i, j - 1).G);

                    brightness = (byte)(Math.Abs(gx + gy));
                    resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
                }
            }

            //Крайние точки
            //нижняя и верхняя часть
            for (int i = 1; i < bmp.Width - 1; i++)
            {
                int j = bmp.Height - 1;
                int gx = (bmp.GetPixel(i + 1, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i - 1, j).G);
                int gy = (bmp.GetPixel(i, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i, j - 1).G);

                brightness = (byte)(Math.Abs(gx + gy));
                resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));

                j = 0;
                gx = (bmp.GetPixel(i + 1, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i - 1, j).G);
                gy = (bmp.GetPixel(i, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).G);

                brightness = (byte)(Math.Abs(gx + gy));
                resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
            }

            //правая и левая часть
            for (int j = 1; j < bmp.Height - 1; j++)
            {
                int i = bmp.Width - 1;
                int gx = (bmp.GetPixel(i, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i - 1, j).G);
                int gy = (bmp.GetPixel(i, j + 1).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i, j - 1).G);

                brightness = (byte)(Math.Abs(gx + gy));
                resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));


                i = 0;
                gx = (bmp.GetPixel(i, j).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).G);
                gy = (bmp.GetPixel(i, j + 1).G - 2 * bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).G);

                brightness = (byte)(Math.Abs(gx + gy));
                resbmp.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
            }
            return resbmp;
        }

        public static Bitmap ReverseColor(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    byte B = bmp.GetPixel(i, j).B;
                    B = (byte)Math.Abs(255 - B);
                    bmp.SetPixel(i, j, Color.FromArgb(B, B, B));
                }
            }
            return bmp;
        }
    }
}
