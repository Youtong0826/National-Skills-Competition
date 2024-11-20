namespace _100_4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟彩色影像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能要求ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色彩影像轉詼諧影像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.畫出詼諧影像圖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求最小詼諧和最大詼諧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求出現最多次詼諧機率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案FileToolStripMenuItem,
            this.功能要求ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(953, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案FileToolStripMenuItem
            // 
            this.檔案FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟彩色影像ToolStripMenuItem,
            this.結束離開ToolStripMenuItem});
            this.檔案FileToolStripMenuItem.Name = "檔案FileToolStripMenuItem";
            this.檔案FileToolStripMenuItem.Size = new System.Drawing.Size(91, 23);
            this.檔案FileToolStripMenuItem.Text = "檔案 (File)";
            // 
            // 開啟彩色影像ToolStripMenuItem
            // 
            this.開啟彩色影像ToolStripMenuItem.Name = "開啟彩色影像ToolStripMenuItem";
            this.開啟彩色影像ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.開啟彩色影像ToolStripMenuItem.Text = "開啟彩色影像";
            this.開啟彩色影像ToolStripMenuItem.Click += new System.EventHandler(this.開啟彩色影像ToolStripMenuItem_Click);
            // 
            // 結束離開ToolStripMenuItem
            // 
            this.結束離開ToolStripMenuItem.Name = "結束離開ToolStripMenuItem";
            this.結束離開ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.結束離開ToolStripMenuItem.Text = "結束離開";
            this.結束離開ToolStripMenuItem.Click += new System.EventHandler(this.結束離開ToolStripMenuItem_Click);
            // 
            // 功能要求ToolStripMenuItem
            // 
            this.功能要求ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.色彩影像轉詼諧影像ToolStripMenuItem,
            this.畫出詼諧影像圖ToolStripMenuItem,
            this.求最小詼諧和最大詼諧ToolStripMenuItem,
            this.求出現最多次詼諧機率ToolStripMenuItem});
            this.功能要求ToolStripMenuItem.Name = "功能要求ToolStripMenuItem";
            this.功能要求ToolStripMenuItem.Size = new System.Drawing.Size(83, 23);
            this.功能要求ToolStripMenuItem.Text = "功能要求";
            // 
            // 色彩影像轉詼諧影像ToolStripMenuItem
            // 
            this.色彩影像轉詼諧影像ToolStripMenuItem.Name = "色彩影像轉詼諧影像ToolStripMenuItem";
            this.色彩影像轉詼諧影像ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.色彩影像轉詼諧影像ToolStripMenuItem.Text = "色彩影像轉詼諧影像";
            this.色彩影像轉詼諧影像ToolStripMenuItem.Click += new System.EventHandler(this.色彩影像轉詼諧影像ToolStripMenuItem_Click);
            // 
            // 畫出詼諧影像圖ToolStripMenuItem
            // 
            this.畫出詼諧影像圖ToolStripMenuItem.Name = "畫出詼諧影像圖ToolStripMenuItem";
            this.畫出詼諧影像圖ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.畫出詼諧影像圖ToolStripMenuItem.Text = "畫出詼諧影像直圖";
            this.畫出詼諧影像圖ToolStripMenuItem.Click += new System.EventHandler(this.畫出詼諧影像圖ToolStripMenuItem_Click);
            // 
            // 求最小詼諧和最大詼諧ToolStripMenuItem
            // 
            this.求最小詼諧和最大詼諧ToolStripMenuItem.Name = "求最小詼諧和最大詼諧ToolStripMenuItem";
            this.求最小詼諧和最大詼諧ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.求最小詼諧和最大詼諧ToolStripMenuItem.Text = "求最小詼諧和最大詼諧";
            this.求最小詼諧和最大詼諧ToolStripMenuItem.Click += new System.EventHandler(this.求最小詼諧和最大詼諧ToolStripMenuItem_Click);
            // 
            // 求出現最多次詼諧機率ToolStripMenuItem
            // 
            this.求出現最多次詼諧機率ToolStripMenuItem.Name = "求出現最多次詼諧機率ToolStripMenuItem";
            this.求出現最多次詼諧機率ToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.求出現最多次詼諧機率ToolStripMenuItem.Text = "求出現最多次詼諧機率";
            this.求出現最多次詼諧機率ToolStripMenuItem.Click += new System.EventHandler(this.求出現最多次詼諧機率ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "彩色影像";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "最小詼諧亮度為";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "最大詼諧亮度為";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(294, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(221, 319);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "詼諧影像";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "出現最多詼諧亮度為";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(659, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "最多詼諧亮度之機率為";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "詼諧影像直方圖";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(536, 61);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "X";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(396, 318);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟彩色影像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束離開ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能要求ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 色彩影像轉詼諧影像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 畫出詼諧影像圖ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求最小詼諧和最大詼諧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求出現最多次詼諧機率ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

