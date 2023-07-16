using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using PhanLoaiTraiCam.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PhanLoaiTraiCam.Views
{
    public partial class _Home : Form
    {
        private FilterInfoCollection _devices;
        private VideoCaptureDevice cam;
        private Bitmap afterSuppression;
        private Bitmap afterEdgeTrack;
        public _Home()
        {
            InitializeComponent();
            _devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in _devices)
            {
                cmb_Device.Items.Add(Device.Name);
            }
            if (cmb_Device.Items.Count > 0)
            {
                cmb_Device.SelectedIndex = 0;
                timer_video.Start();
            }
            else
            {
                btn_Start.Enabled = false;
                MessageBox.Show("Chưa kết nối đến camera vui lòng kiểm tra!");
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(_devices[cmb_Device.SelectedIndex].MonikerString);
            cam.NewFrame += FinalFrame_NewFrame;
            cam.Start();
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pic_Video1.Image != null) { pic_Video1.Image.Dispose(); }
            pic_Video1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void _Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.SignalToStop();
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.SignalToStop();
            }
        }

        private void timer_video_Tick(object sender, EventArgs e)
        {
            if (pic_Video1.Image != null)
            {
            }
        }

        private void btn_TakePhoto_Click(object sender, EventArgs e)
        {
            var image = (Bitmap)pic_Video1.Image.Clone();
            if (pic_Video2.Image != null) { pic_Video2.Image.Dispose(); }
            pic_Video2.Image = image;
            if (pic_GrayScale.Image != null) { pic_GrayScale.Image.Dispose(); }
            Bitmap  afterGrey = image.ImageToGrey();
            Bitmap afterGauss;
            double sigma = 0;
            afterGauss = afterGrey.GaussianFilter(sigma);
            Bitmap afterSobel = afterGauss.SobelConvolve();
            afterSuppression = afterSobel.NonMaximumSuppression();
            Bitmap afterThreshold = afterSuppression.DoubleThreshold(100, 10);
            afterEdgeTrack = afterThreshold.EdgeTracking();
            Bitmap afterRestoration = afterEdgeTrack.BorderRestoration(3);
            pic_GrayScale.Image = afterThreshold;
            // Phân ngưỡng ảnh xám để tách vùng đối tượng
            // Tạo bộ lọc liên kết để nối các điểm ảnh thành vùng
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.ProcessImage(afterThreshold);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // Tính tổng diện tích của các vùng
            int totalArea = 0;
            foreach (Blob blob in blobs)
            {
                totalArea += blob.Area;
            }
            MessageBox.Show(totalArea.ToString());
        }
    }
}
