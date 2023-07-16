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
            label2 = new Label();
            label1 = new Label();
            lbl_Device = new Label();
            cmb_Device = new ComboBox();
            cmb_CNN = new ComboBox();
            cmb_Count = new ComboBox();
            btn_Start = new Button();
            btn_Stop = new Button();
            tbl_Container = new TableLayoutPanel();
            pic_Video2 = new PictureBox();
            pic_Video1 = new PictureBox();
            dtgrid_Result = new DataGridView();
            timer_video = new System.Windows.Forms.Timer(components);
            tbl_Main.SuspendLayout();
            tbl_Menu.SuspendLayout();
            tbl_Container.SuspendLayout();
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
            tbl_Main.Name = "tbl_Main";
            tbl_Main.RowCount = 2;
            tbl_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 5.9558115F));
            tbl_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 94.04419F));
            tbl_Main.Size = new Size(1904, 1041);
            tbl_Main.TabIndex = 0;
            // 
            // tbl_Menu
            // 
            tbl_Menu.ColumnCount = 6;
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tbl_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Menu.Controls.Add(label2, 2, 0);
            tbl_Menu.Controls.Add(label1, 1, 0);
            tbl_Menu.Controls.Add(lbl_Device, 0, 0);
            tbl_Menu.Controls.Add(cmb_Device, 0, 1);
            tbl_Menu.Controls.Add(cmb_CNN, 1, 1);
            tbl_Menu.Controls.Add(cmb_Count, 2, 1);
            tbl_Menu.Controls.Add(btn_Start, 3, 1);
            tbl_Menu.Controls.Add(btn_Stop, 4, 1);
            tbl_Menu.Dock = DockStyle.Fill;
            tbl_Menu.Location = new Point(3, 3);
            tbl_Menu.Name = "tbl_Menu";
            tbl_Menu.RowCount = 2;
            tbl_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 39.2857132F));
            tbl_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 60.7142868F));
            tbl_Menu.Size = new Size(1898, 56);
            tbl_Menu.TabIndex = 0;
            // 
            // label2
            // 
            label2.AccessibleDescription = "Device";
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Location = new Point(318, 7);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 2;
            label2.Text = "Count";
            // 
            // label1
            // 
            label1.AccessibleDescription = "Device";
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(168, 7);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 1;
            label1.Text = "CNN";
            // 
            // lbl_Device
            // 
            lbl_Device.AccessibleDescription = "Device";
            lbl_Device.AutoSize = true;
            lbl_Device.Dock = DockStyle.Bottom;
            lbl_Device.Location = new Point(3, 7);
            lbl_Device.Name = "lbl_Device";
            lbl_Device.Size = new Size(159, 15);
            lbl_Device.TabIndex = 0;
            lbl_Device.Text = "Device";
            // 
            // cmb_Device
            // 
            cmb_Device.Dock = DockStyle.Bottom;
            cmb_Device.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Device.FormattingEnabled = true;
            cmb_Device.Location = new Point(3, 30);
            cmb_Device.Name = "cmb_Device";
            cmb_Device.Size = new Size(159, 23);
            cmb_Device.TabIndex = 3;
            // 
            // cmb_CNN
            // 
            cmb_CNN.Dock = DockStyle.Bottom;
            cmb_CNN.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CNN.FormattingEnabled = true;
            cmb_CNN.Location = new Point(168, 30);
            cmb_CNN.Name = "cmb_CNN";
            cmb_CNN.Size = new Size(144, 23);
            cmb_CNN.TabIndex = 4;
            // 
            // cmb_Count
            // 
            cmb_Count.Dock = DockStyle.Bottom;
            cmb_Count.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Count.FormattingEnabled = true;
            cmb_Count.Items.AddRange(new object[] { "10", "20", "50", "100", "200", "500" });
            cmb_Count.Location = new Point(318, 30);
            cmb_Count.Name = "cmb_Count";
            cmb_Count.Size = new Size(108, 23);
            cmb_Count.TabIndex = 5;
            // 
            // btn_Start
            // 
            btn_Start.Dock = DockStyle.Bottom;
            btn_Start.Location = new Point(444, 30);
            btn_Start.Margin = new Padding(15, 3, 15, 3);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(108, 23);
            btn_Start.TabIndex = 6;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Dock = DockStyle.Bottom;
            btn_Stop.Location = new Point(582, 30);
            btn_Stop.Margin = new Padding(15, 3, 15, 3);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(97, 23);
            btn_Stop.TabIndex = 7;
            btn_Stop.Text = "Stop";
            btn_Stop.UseVisualStyleBackColor = true;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // tbl_Container
            // 
            tbl_Container.ColumnCount = 2;
            tbl_Container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Container.Controls.Add(pic_Video2, 1, 0);
            tbl_Container.Controls.Add(pic_Video1, 0, 0);
            tbl_Container.Controls.Add(dtgrid_Result, 1, 1);
            tbl_Container.Dock = DockStyle.Fill;
            tbl_Container.Location = new Point(3, 65);
            tbl_Container.Name = "tbl_Container";
            tbl_Container.RowCount = 2;
            tbl_Container.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Container.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Container.Size = new Size(1898, 973);
            tbl_Container.TabIndex = 1;
            // 
            // pic_Video2
            // 
            pic_Video2.BackColor = SystemColors.ActiveBorder;
            pic_Video2.Dock = DockStyle.Fill;
            pic_Video2.Location = new Point(952, 3);
            pic_Video2.Name = "pic_Video2";
            pic_Video2.Size = new Size(943, 480);
            pic_Video2.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Video2.TabIndex = 1;
            pic_Video2.TabStop = false;
            // 
            // pic_Video1
            // 
            pic_Video1.BackColor = SystemColors.ActiveBorder;
            pic_Video1.Dock = DockStyle.Fill;
            pic_Video1.Location = new Point(3, 3);
            pic_Video1.Name = "pic_Video1";
            pic_Video1.Size = new Size(943, 480);
            pic_Video1.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Video1.TabIndex = 0;
            pic_Video1.TabStop = false;
            // 
            // dtgrid_Result
            // 
            dtgrid_Result.BackgroundColor = SystemColors.ActiveBorder;
            dtgrid_Result.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgrid_Result.Dock = DockStyle.Fill;
            dtgrid_Result.Location = new Point(952, 489);
            dtgrid_Result.Name = "dtgrid_Result";
            dtgrid_Result.RowTemplate.Height = 25;
            dtgrid_Result.Size = new Size(943, 481);
            dtgrid_Result.TabIndex = 2;
            // 
            // timer_video
            // 
            timer_video.Tick += timer_video_Tick;
            // 
            // _Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(tbl_Main);
            Name = "_Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "_Home";
            WindowState = FormWindowState.Maximized;
            FormClosing += _Home_FormClosing;
            tbl_Main.ResumeLayout(false);
            tbl_Menu.ResumeLayout(false);
            tbl_Menu.PerformLayout();
            tbl_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Video2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Video1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgrid_Result).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbl_Main;
        private TableLayoutPanel tbl_Menu;
        private Label label2;
        private Label label1;
        private Label lbl_Device;
        private ComboBox cmb_Device;
        private ComboBox cmb_CNN;
        private ComboBox cmb_Count;
        private Button btn_Start;
        private Button btn_Stop;
        private TableLayoutPanel tbl_Container;
        private PictureBox pic_Video1;
        private PictureBox pic_Video2;
        private DataGridView dtgrid_Result;
        private System.Windows.Forms.Timer timer_video;
    }
}