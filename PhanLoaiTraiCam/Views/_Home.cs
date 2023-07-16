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

namespace PhanLoaiTraiCam.Views
{
    public partial class _Home : Form
    {
        private FilterInfoCollection _devices;
        private VideoCaptureDevice cam;
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
                pic_Video2.Image = ((Bitmap)pic_Video1.Image.Clone()).ToGrayScale();
            }
        }
    }
}
