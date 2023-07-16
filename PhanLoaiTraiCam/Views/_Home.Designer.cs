namespace PhanLoaiTraiCam.Views
{
    partial class _Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tbl_Main = new TableLayoutPanel();
            tbl_Menu = new TableLayoutPanel();
            lbl_Device = new Label();
            cmb_Device = new ComboBox();
            btn_Start = new Button();
            btn_Stop = new Button();
            btn_TakePhoto = new Button();
            tbl_Container = new TableLayoutPanel();
            pic_GrayScale = new PictureBox();
            pic_Video2 = new PictureBox();
            pic_Video1 = new PictureBox();
            dtgrid_Result = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            timer_video = new System.Windows.Forms.Timer(components);
            tbl_Main.SuspendLayout();
            tbl_Menu.SuspendLayout();
            tbl_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_GrayScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Video2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Video1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgrid_Result).BeginInit();
            SuspendLayout();
            // 
            // tbl_Main
            // 
            tbl_Main.ColumnCount = 1;
            tbl_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Main.Controls.Add(tbl_Menu, 0, 0);
            tbl_Main.Controls.Add(tbl_Container, 0, 1);
            tbl_Main.Dock = DockStyle.Fill;
            tbl_Main.Location = new Point(0, 0);
            tbl_Main.Margin = new Padding(3, 4, 3, 4);
            tbl_Main.Name = "tbl_Main";
            tbl_Main.RowCount = 2;
            tbl_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 5.9558115F));
            tbl_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 94.04419F));
            tbl_Main.Size = new Size(1924, 1055);
            tbl_Main.TabIndex = 0;
            // 
            // tbl_Menu
            // 
            tbl_Menu.ColumnCount = 6;
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 189F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 143F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Menu.Controls.Add(lbl_Device, 0, 0);
            tbl_Menu.Controls.Add(cmb_Device, 0, 1);
            tbl_Menu.Controls.Add(btn_Start, 1, 1);
            tbl_Menu.Controls.Add(btn_Stop, 2, 1);
            tbl_Menu.Controls.Add(btn_TakePhoto, 3, 1);
            tbl_Menu.Dock = DockStyle.Fill;
            tbl_Menu.Location = new Point(3, 4);
            tbl_Menu.Margin = new Padding(3, 4, 3, 4);
            tbl_Menu.Name = "tbl_Menu";
            tbl_Menu.RowCount = 2;
            tbl_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tbl_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tbl_Menu.Size = new Size(1918, 54);
            tbl_Menu.TabIndex = 0;
            // 
            // lbl_Device
            // 
            lbl_Device.AccessibleDescription = "Device";
            lbl_Device.AutoSize = true;
            lbl_Device.Dock = DockStyle.Bottom;
            lbl_Device.Location = new Point(3, 0);
            lbl_Device.Name = "lbl_Device";
            lbl_Device.Size = new Size(183, 17);
            lbl_Device.TabIndex = 0;
            lbl_Device.Text = "Device";
            // 
            // cmb_Device
            // 
            cmb_Device.Dock = DockStyle.Bottom;
            cmb_Device.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Device.FormattingEnabled = true;
            cmb_Device.Location = new Point(3, 22);
            cmb_Device.Margin = new Padding(3, 4, 3, 4);
            cmb_Device.Name = "cmb_Device";
            cmb_Device.Size = new Size(183, 28);
            cmb_Device.TabIndex = 3;
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(206, 21);
            btn_Start.Margin = new Padding(17, 4, 17, 4);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(124, 29);
            btn_Start.TabIndex = 6;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Location = new Point(364, 21);
            btn_Stop.Margin = new Padding(17, 4, 17, 4);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(109, 29);
            btn_Stop.TabIndex = 7;
            btn_Stop.Text = "Stop";
            btn_Stop.UseVisualStyleBackColor = true;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // btn_TakePhoto
            // 
            btn_TakePhoto.Location = new Point(507, 21);
            btn_TakePhoto.Margin = new Padding(17, 4, 17, 4);
            btn_TakePhoto.Name = "btn_TakePhoto";
            btn_TakePhoto.Size = new Size(124, 29);
            btn_TakePhoto.TabIndex = 8;
            btn_TakePhoto.Text = "Chụp";
            btn_TakePhoto.UseVisualStyleBackColor = true;
            btn_TakePhoto.Click += btn_TakePhoto_Click;
            // 
            // tbl_Container
            // 
            tbl_Container.ColumnCount = 2;
            tbl_Container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Container.Controls.Add(pic_GrayScale, 0, 1);
            tbl_Container.Controls.Add(pic_Video2, 1, 0);
            tbl_Container.Controls.Add(pic_Video1, 0, 0);
            tbl_Container.Controls.Add(dtgrid_Result, 1, 1);
            tbl_Container.Dock = DockStyle.Fill;
            tbl_Container.Location = new Point(3, 66);
            tbl_Container.Margin = new Padding(3, 4, 3, 4);
            tbl_Container.Name = "tbl_Container";
            tbl_Container.RowCount = 2;
            tbl_Container.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Container.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Container.Size = new Size(1918, 985);
            tbl_Container.TabIndex = 1;
            // 
            // pic_GrayScale
            // 
            pic_GrayScale.BackColor = SystemColors.ActiveBorder;
            pic_GrayScale.Dock = DockStyle.Fill;
            pic_GrayScale.Location = new Point(3, 496);
            pic_GrayScale.Margin = new Padding(3, 4, 3, 4);
            pic_GrayScale.Name = "pic_GrayScale";
            pic_GrayScale.Size = new Size(953, 485);
            pic_GrayScale.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_GrayScale.TabIndex = 3;
            pic_GrayScale.TabStop = false;
            // 
            // pic_Video2
            // 
            pic_Video2.BackColor = SystemColors.ActiveBorder;
            pic_Video2.Dock = DockStyle.Fill;
            pic_Video2.Location = new Point(962, 4);
            pic_Video2.Margin = new Padding(3, 4, 3, 4);
            pic_Video2.Name = "pic_Video2";
            pic_Video2.Size = new Size(953, 484);
            pic_Video2.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Video2.TabIndex = 1;
            pic_Video2.TabStop = false;
            // 
            // pic_Video1
            // 
            pic_Video1.BackColor = SystemColors.ActiveBorder;
            pic_Video1.Dock = DockStyle.Fill;
            pic_Video1.Location = new Point(3, 4);
            pic_Video1.Margin = new Padding(3, 4, 3, 4);
            pic_Video1.Name = "pic_Video1";
            pic_Video1.Size = new Size(953, 484);
            pic_Video1.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Video1.TabIndex = 0;
            pic_Video1.TabStop = false;
            // 
            // dtgrid_Result
            // 
            dtgrid_Result.BackgroundColor = Color.White;
            dtgrid_Result.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgrid_Result.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dtgrid_Result.Dock = DockStyle.Fill;
            dtgrid_Result.Location = new Point(962, 496);
            dtgrid_Result.Margin = new Padding(3, 4, 3, 4);
            dtgrid_Result.Name = "dtgrid_Result";
            dtgrid_Result.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dtgrid_Result.RowTemplate.Height = 25;
            dtgrid_Result.Size = new Size(953, 485);
            dtgrid_Result.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // timer_video
            // 
            timer_video.Tick += timer_video_Tick;
            // 
            // _Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(tbl_Main);
            Margin = new Padding(3, 4, 3, 4);
            Name = "_Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "_Home";
            WindowState = FormWindowState.Maximized;
            FormClosing += _Home_FormClosing;
            tbl_Main.ResumeLayout(false);
            tbl_Menu.ResumeLayout(false);
            tbl_Menu.PerformLayout();
            tbl_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_GrayScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Video2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Video1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgrid_Result).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbl_Main;
        private TableLayoutPanel tbl_Menu;
        private Label lbl_Device;
        private ComboBox cmb_Device;
        private Button btn_Start;
        private Button btn_Stop;
        private TableLayoutPanel tbl_Container;
        private PictureBox pic_Video1;
        private PictureBox pic_Video2;
        private DataGridView dtgrid_Result;
        private System.Windows.Forms.Timer timer_video;
        private Button btn_TakePhoto;
        private PictureBox pic_GrayScale;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}