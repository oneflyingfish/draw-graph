namespace 绘图解释器
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
            this.upPanel = new System.Windows.Forms.Panel();
            this.richTextBoxSplitterContainer = new System.Windows.Forms.SplitContainer();
            this.codeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.RunOutputGroupBox = new System.Windows.Forms.GroupBox();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.downPanel = new System.Windows.Forms.Panel();
            this.codeKindCombobox = new System.Windows.Forms.ComboBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.codeInfoLabel = new System.Windows.Forms.Label();
            this.colorinfolabel = new System.Windows.Forms.Label();
            this.runInformationLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.objectPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.upPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.richTextBoxSplitterContainer)).BeginInit();
            this.richTextBoxSplitterContainer.Panel1.SuspendLayout();
            this.richTextBoxSplitterContainer.Panel2.SuspendLayout();
            this.richTextBoxSplitterContainer.SuspendLayout();
            this.RunOutputGroupBox.SuspendLayout();
            this.downPanel.SuspendLayout();
            this.objectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // upPanel
            // 
            this.upPanel.Controls.Add(this.richTextBoxSplitterContainer);
            this.upPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upPanel.Location = new System.Drawing.Point(2, 2);
            this.upPanel.Margin = new System.Windows.Forms.Padding(0);
            this.upPanel.Name = "upPanel";
            this.upPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.upPanel.Size = new System.Drawing.Size(966, 532);
            this.upPanel.TabIndex = 0;
            // 
            // richTextBoxSplitterContainer
            // 
            this.richTextBoxSplitterContainer.BackColor = System.Drawing.Color.Transparent;
            this.richTextBoxSplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSplitterContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.richTextBoxSplitterContainer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBoxSplitterContainer.Location = new System.Drawing.Point(0, 2);
            this.richTextBoxSplitterContainer.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxSplitterContainer.Name = "richTextBoxSplitterContainer";
            this.richTextBoxSplitterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // richTextBoxSplitterContainer.Panel1
            // 
            this.richTextBoxSplitterContainer.Panel1.Controls.Add(this.codeRichTextBox);
            this.richTextBoxSplitterContainer.Panel1MinSize = 50;
            // 
            // richTextBoxSplitterContainer.Panel2
            // 
            this.richTextBoxSplitterContainer.Panel2.Controls.Add(this.RunOutputGroupBox);
            this.richTextBoxSplitterContainer.Panel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxSplitterContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.richTextBoxSplitterContainer.Panel2MinSize = 50;
            this.richTextBoxSplitterContainer.Size = new System.Drawing.Size(966, 528);
            this.richTextBoxSplitterContainer.SplitterDistance = 443;
            this.richTextBoxSplitterContainer.SplitterWidth = 1;
            this.richTextBoxSplitterContainer.TabIndex = 3;
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.AcceptsTab = true;
            this.codeRichTextBox.BackColor = System.Drawing.Color.White;
            this.codeRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeRichTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.Size = new System.Drawing.Size(966, 443);
            this.codeRichTextBox.TabIndex = 0;
            this.codeRichTextBox.Text = "";
            this.toolTip1.SetToolTip(this.codeRichTextBox, "拖入文本文件可自动加载, ESC设置默认字体，F5运行代码");
            this.codeRichTextBox.WordWrap = false;
            this.codeRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeRichTextox_KeyDown);
            // 
            // RunOutputGroupBox
            // 
            this.RunOutputGroupBox.BackColor = System.Drawing.Color.White;
            this.RunOutputGroupBox.Controls.Add(this.outputRichTextBox);
            this.RunOutputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunOutputGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunOutputGroupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RunOutputGroupBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.RunOutputGroupBox.Location = new System.Drawing.Point(0, 2);
            this.RunOutputGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.RunOutputGroupBox.Name = "RunOutputGroupBox";
            this.RunOutputGroupBox.Padding = new System.Windows.Forms.Padding(1);
            this.RunOutputGroupBox.Size = new System.Drawing.Size(966, 82);
            this.RunOutputGroupBox.TabIndex = 2;
            this.RunOutputGroupBox.TabStop = false;
            this.RunOutputGroupBox.Text = "运行输出";
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.BackColor = System.Drawing.Color.White;
            this.outputRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputRichTextBox.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outputRichTextBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.outputRichTextBox.Location = new System.Drawing.Point(1, 21);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.ReadOnly = true;
            this.outputRichTextBox.Size = new System.Drawing.Size(964, 60);
            this.outputRichTextBox.TabIndex = 1;
            this.outputRichTextBox.Text = "";
            this.outputRichTextBox.WordWrap = false;
            // 
            // downPanel
            // 
            this.downPanel.Controls.Add(this.codeKindCombobox);
            this.downPanel.Controls.Add(this.colorLabel);
            this.downPanel.Controls.Add(this.codeInfoLabel);
            this.downPanel.Controls.Add(this.colorinfolabel);
            this.downPanel.Controls.Add(this.runInformationLabel);
            this.downPanel.Controls.Add(this.runButton);
            this.downPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.downPanel.Location = new System.Drawing.Point(2, 534);
            this.downPanel.Margin = new System.Windows.Forms.Padding(0);
            this.downPanel.Name = "downPanel";
            this.downPanel.Padding = new System.Windows.Forms.Padding(2);
            this.downPanel.Size = new System.Drawing.Size(966, 30);
            this.downPanel.TabIndex = 1;
            // 
            // codeKindCombobox
            // 
            this.codeKindCombobox.Dock = System.Windows.Forms.DockStyle.Right;
            this.codeKindCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codeKindCombobox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeKindCombobox.FormattingEnabled = true;
            this.codeKindCombobox.Items.AddRange(new object[] {
            "ANSI",
            "UTF-8",
            "Unicode"});
            this.codeKindCombobox.Location = new System.Drawing.Point(800, 2);
            this.codeKindCombobox.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.codeKindCombobox.Name = "codeKindCombobox";
            this.codeKindCombobox.Size = new System.Drawing.Size(106, 26);
            this.codeKindCombobox.TabIndex = 4;
            this.toolTip1.SetToolTip(this.codeKindCombobox, "[拖入文件编码]下次拖入生效");
            // 
            // colorLabel
            // 
            this.colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorLabel.AutoSize = true;
            this.colorLabel.BackColor = System.Drawing.Color.Red;
            this.colorLabel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colorLabel.Location = new System.Drawing.Point(667, 6);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(19, 19);
            this.colorLabel.TabIndex = 7;
            this.colorLabel.Text = " ";
            this.toolTip1.SetToolTip(this.colorLabel, "单击选择颜色");
            this.colorLabel.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // codeInfoLabel
            // 
            this.codeInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.codeInfoLabel.AutoSize = true;
            this.codeInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.codeInfoLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeInfoLabel.Location = new System.Drawing.Point(690, 6);
            this.codeInfoLabel.Name = "codeInfoLabel";
            this.codeInfoLabel.Size = new System.Drawing.Size(114, 20);
            this.codeInfoLabel.TabIndex = 5;
            this.codeInfoLabel.Text = "拖入文件编码：";
            // 
            // colorinfolabel
            // 
            this.colorinfolabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorinfolabel.AutoSize = true;
            this.colorinfolabel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.colorinfolabel.Location = new System.Drawing.Point(562, 5);
            this.colorinfolabel.Name = "colorinfolabel";
            this.colorinfolabel.Size = new System.Drawing.Size(114, 20);
            this.colorinfolabel.TabIndex = 6;
            this.colorinfolabel.Text = "当前画笔颜色：";
            this.toolTip1.SetToolTip(this.colorinfolabel, "单击右侧色彩块更换颜色");
            // 
            // runInformationLabel
            // 
            this.runInformationLabel.AutoSize = true;
            this.runInformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.runInformationLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.runInformationLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runInformationLabel.ForeColor = System.Drawing.Color.Red;
            this.runInformationLabel.Location = new System.Drawing.Point(2, 2);
            this.runInformationLabel.Name = "runInformationLabel";
            this.runInformationLabel.Size = new System.Drawing.Size(437, 20);
            this.runInformationLabel.TabIndex = 3;
            this.runInformationLabel.Text = "提示: 可将代码文件直接拖拽到上方输入框，系统将自动加载内容";
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.Transparent;
            this.runButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("runButton.BackgroundImage")));
            this.runButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.runButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.runButton.FlatAppearance.BorderSize = 0;
            this.runButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.runButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Location = new System.Drawing.Point(906, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(58, 26);
            this.runButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.runButton, "运行程序");
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // objectPanel
            // 
            this.objectPanel.Controls.Add(this.upPanel);
            this.objectPanel.Controls.Add(this.downPanel);
            this.objectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectPanel.Location = new System.Drawing.Point(0, 0);
            this.objectPanel.Name = "objectPanel";
            this.objectPanel.Padding = new System.Windows.Forms.Padding(2);
            this.objectPanel.Size = new System.Drawing.Size(970, 566);
            this.objectPanel.TabIndex = 2;
            // 
            // main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 566);
            this.Controls.Add(this.objectPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "图形界面解释器";
            this.upPanel.ResumeLayout(false);
            this.richTextBoxSplitterContainer.Panel1.ResumeLayout(false);
            this.richTextBoxSplitterContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.richTextBoxSplitterContainer)).EndInit();
            this.richTextBoxSplitterContainer.ResumeLayout(false);
            this.RunOutputGroupBox.ResumeLayout(false);
            this.downPanel.ResumeLayout(false);
            this.downPanel.PerformLayout();
            this.objectPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel upPanel;
        private System.Windows.Forms.RichTextBox codeRichTextBox;
        private System.Windows.Forms.Panel downPanel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Panel objectPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label runInformationLabel;
        private System.Windows.Forms.ComboBox codeKindCombobox;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.GroupBox RunOutputGroupBox;
        private System.Windows.Forms.Label codeInfoLabel;
        private System.Windows.Forms.SplitContainer richTextBoxSplitterContainer;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label colorinfolabel;
    }
}

