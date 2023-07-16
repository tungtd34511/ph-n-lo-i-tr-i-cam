using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Threading;
using System.Drawing;
using Emgu.CV.Reg;
using static System.Net.Mime.MediaTypeNames;

namespace phân_loại__trái_cam
{

    partial class Form1 : Form
    {
        private FilterInfoCollection cameras;
        private VideoCaptureDevice cam;
        private Bitmap _curentImage;
            private Bitmap _curentImage2;
        private Thread _curentThread;
        public Form1()
        {
            InitializeComponent();
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in cameras)
            {
                comboBox1.Items.Add(info.Name);
            }
            comboBox1.SelectedIndex = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); }
            _curentImage = (Bitmap)eventArgs.Frame.Clone();
            _curentImage2 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = _curentImage;
        }

        private void ConvertImage()
        {
            if (pictureBox2.Image != null) { pictureBox2.Image.Dispose(); }
            pictureBox2.Invalidate();
            pictureBox2.Image = _curentImage2.ConvertToBinaryImage();
        }
        private void convertImage(object sender, NewFrameEventArgs eventArgs) {
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.SignalToStop();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(cameras[comboBox1.SelectedIndex].MonikerString);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += (o, e) =>
            {
                ConvertImage();
            };
            cam.NewFrame += Cam_NewFrame;
            //timer.Start();
            cam.Start();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.SignalToStop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.InitialDirectory = "C:\\Users\\Admin\\source\\repos\\phân loại  trái cam\\model-image";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }
    }
    public static class GrayscaleConverter
    {
        public static Bitmap ConvertToGrayscale(this Bitmap bitmap)
        {
            // Tạo một bitmap mới với định dạng màu xám
            var image = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
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

    public static class BinaryConverter
    {
        public static Bitmap ConvertToBinaryImage(this Bitmap image)
        {
            // Tạo đối tượng Bitmap mới với kích thước và định dạng tương tự như ảnh gốc
            Bitmap binaryImage = (Bitmap)image.Clone();

            // Lặp qua từng điểm ảnh trong ảnh gốc
            for (int y = 0; y < binaryImage.Height; y++)
            {
                for (int x = 0; x < binaryImage.Width; x++)
                {
                    // Lấy giá trị màu của điểm ảnh
                    Color pixelColor = binaryImage.GetPixel(x, y);

                    // Chuyển đổi giá trị màu sang giá trị nhị phân
                    int grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color binaryColor = grayScale > 128 ? Color.White : Color.Black;

                    // Gán giá trị màu cho điểm ảnh trong ảnh nhị phân
                    binaryImage.SetPixel(x, y, binaryColor);
                }
            }
            return binaryImage;
        }
    }
}