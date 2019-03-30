namespace 图片代码生成器
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.downPanel = new System.Windows.Forms.Panel();
            this.imageHeightNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.colorLabel = new System.Windows.Forms.Label();
            this.shouColorLabel = new System.Windows.Forms.Label();
            this.selectBackgroundColor = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.upPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageHeightTrackBar = new System.Windows.Forms.TrackBar();
            this.downPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightNumberUpDown)).BeginInit();
            this.upPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // downPanel
            // 
            this.downPanel.BackColor = System.Drawing.Color.Transparent;
            this.downPanel.Controls.Add(this.imageHeightTrackBar);
            this.downPanel.Controls.Add(this.imageHeightNumberUpDown);
            this.downPanel.Controls.Add(this.colorLabel);
            this.downPanel.Controls.Add(this.shouColorLabel);
            this.downPanel.Controls.Add(this.selectBackgroundColor);
            this.downPanel.Controls.Add(this.runButton);
            this.downPanel.Controls.Add(this.label1);
            this.downPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.downPanel.Location = new System.Drawing.Point(0, 436);
            this.downPanel.Name = "downPanel";
            this.downPanel.Size = new System.Drawing.Size(642, 37);
            this.downPanel.TabIndex = 0;
            // 
            // imageHeightNumberUpDown
            // 
            this.imageHeightNumberUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.imageHeightNumberUpDown.Location = new System.Drawing.Point(254, 6);
            this.imageHeightNumberUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.imageHeightNumberUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.imageHeightNumberUpDown.Name = "imageHeightNumberUpDown";
            this.imageHeightNumberUpDown.Size = new System.Drawing.Size(52, 25);
            this.imageHeightNumberUpDown.TabIndex = 7;
            this.imageHeightNumberUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // colorLabel
            // 
            this.colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorLabel.AutoSize = true;
            this.colorLabel.BackColor = System.Drawing.Color.Maroon;
            this.colorLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colorLabel.Location = new System.Drawing.Point(414, 8);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(21, 20);
            this.colorLabel.TabIndex = 3;
            this.colorLabel.Text = "   ";
            // 
            // shouColorLabel
            // 
            this.shouColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shouColorLabel.AutoSize = true;
            this.shouColorLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shouColorLabel.Location = new System.Drawing.Point(324, 8);
            this.shouColorLabel.Name = "shouColorLabel";
            this.shouColorLabel.Size = new System.Drawing.Size(92, 20);
            this.shouColorLabel.TabIndex = 2;
            this.shouColorLabel.Text = "自动背景色: ";
            // 
            // selectBackgroundColor
            // 
            this.selectBackgroundColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectBackgroundColor.Location = new System.Drawing.Point(442, 0);
            this.selectBackgroundColor.Name = "selectBackgroundColor";
            this.selectBackgroundColor.Size = new System.Drawing.Size(125, 37);
            this.selectBackgroundColor.TabIndex = 1;
            this.selectBackgroundColor.Text = "选择图片背景色";
            this.selectBackgroundColor.UseVisualStyleBackColor = true;
            this.selectBackgroundColor.Click += new System.EventHandler(this.selectBackgroundColor_Click);
            // 
            // runButton
            // 
            this.runButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.runButton.Location = new System.Drawing.Point(567, 0);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 37);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "开始生成";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "图像最大高度：";
            this.toolTip1.SetToolTip(this.label1, "代码运行时间将伴随绘制大小平方级快速增长。");
            // 
            // upPanel
            // 
            this.upPanel.Controls.Add(this.infoLabel);
            this.upPanel.Controls.Add(this.pictureBox);
            this.upPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upPanel.Location = new System.Drawing.Point(0, 0);
            this.upPanel.Name = "upPanel";
            this.upPanel.Padding = new System.Windows.Forms.Padding(1);
            this.upPanel.Size = new System.Drawing.Size(642, 436);
            this.upPanel.TabIndex = 1;
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.infoLabel.AutoEllipsis = true;
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infoLabel.ForeColor = System.Drawing.Color.Silver;
            this.infoLabel.Location = new System.Drawing.Point(251, 221);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(144, 20);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "拖入高清图片以加载";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(1, 1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 434);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox, "建议用windows自带截图工具，目前发现QQ截图清晰度不够");
            // 
            // imageHeightTrackBar
            // 
            this.imageHeightTrackBar.AutoSize = false;
            this.imageHeightTrackBar.BackColor = System.Drawing.Color.White;
            this.imageHeightTrackBar.LargeChange = 50;
            this.imageHeightTrackBar.Location = new System.Drawing.Point(103, 4);
            this.imageHeightTrackBar.Maximum = 500;
            this.imageHeightTrackBar.Minimum = 100;
            this.imageHeightTrackBar.Name = "imageHeightTrackBar";
            this.imageHeightTrackBar.Size = new System.Drawing.Size(150, 31);
            this.imageHeightTrackBar.SmallChange = 10;
            this.imageHeightTrackBar.TabIndex = 8;
            this.imageHeightTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.imageHeightTrackBar.Value = 200;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 473);
            this.Controls.Add(this.upPanel);
            this.Controls.Add(this.downPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(660, 520);
            this.Name = "main";
            this.Text = "绘图代码自动生成器";
            this.downPanel.ResumeLayout(false);
            this.downPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightNumberUpDown)).EndInit();
            this.upPanel.ResumeLayout(false);
            this.upPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeightTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel downPanel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Panel upPanel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label shouColorLabel;
        private System.Windows.Forms.Button selectBackgroundColor;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown imageHeightNumberUpDown;
        private System.Windows.Forms.TrackBar imageHeightTrackBar;
    }
}

