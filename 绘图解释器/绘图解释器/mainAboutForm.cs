using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 绘图解释器
{
    partial class main
    {
        public main()
        {
            InitUi();
            printEndInformation = PrintEndInformation;
        }

        /// <summary>
        /// 图形界面相关事件及设置
        /// </summary>
        private void InitUi()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.upPanel.Paint += UpPanel_Paint;
            this.codeRichTextBox.AllowDrop = true;                                              //设置编辑框允许拖入文件
            this.codeKindCombobox.SelectedIndex = 0;                                            //设置默认ANSI编码
            this.codeRichTextBox.DragDrop += CodeRichTextox_DragDrop;
            this.codeRichTextBox.DragEnter += CodeRichTextox_DragEnter;
            this.richTextBoxSplitterContainer.Paint += RichTextBoxSplitterContainer_Paint;
        }

        /// <summary>
        /// 绘图界面关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RunStoped = true;
            this.paintGraphics.Dispose();
            this.paintGraphics = null;
            this.paintForm = null;
        }

        /// <summary>
        /// 重置代码为默认字体以及字号
        /// </summary>
        private void AutoSetFont()
        {
            this.codeRichTextBox.SelectAll();
            this.codeRichTextBox.SelectionFont = new Font("Consolas",12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        /// <summary>
        /// 重置绘图窗体
        /// </summary>
        private void SetDefaultPaintForm()
        {
            //设置绘图界面初始值
            if (this.paintForm != null)
            {
                this.paintForm.Close();
            }

            bitmap = new Bitmap(1000, 800);
            this.paintForm = new PaintForm();
            paintGraphics = Graphics.FromImage(bitmap);     //创建绘图对象
            this.paintForm.pictureBox.Image = bitmap;
            paintGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.paintForm.FormClosing += PaintForm_FormClosing;
            this.RunStoped = false;
        }

        /// <summary>
        /// 单击选择绘图颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorLabel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = this.colorLabel.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorLabel.BackColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// 编辑文本框绘制边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.Silver), 0, 1, this.upPanel.Width - 1, 1);
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.Silver), 0, this.upPanel.Height - 1, this.upPanel.Width - 1, this.upPanel.Height - 1);
        }

        /// <summary>
        /// 绘制分割线，美观
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichTextBoxSplitterContainer_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.richTextBoxSplitterContainer.SplitterRectangle;
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.LightGray), 0, rect.Y + rect.Height / 2, this.richTextBoxSplitterContainer.Width - 1, rect.Y + rect.Height / 2);
        }

        /// <summary>
        /// 设置编辑器tab按钮为4个空格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeRichTextox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Tab)
            {
                //shift+tab退格
                int endIndex = this.codeRichTextBox.SelectionStart;
                int startIndex = endIndex - 4;
                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                string newString = this.codeRichTextBox.Text.Substring(startIndex, endIndex - startIndex).TrimEnd(' ');
                this.codeRichTextBox.Text = this.codeRichTextBox.Text.Remove(startIndex, endIndex - startIndex);
                this.codeRichTextBox.Text = this.codeRichTextBox.Text.Insert(startIndex, newString);
                this.codeRichTextBox.Select(startIndex + newString.Length, 0);
                e.SuppressKeyPress = true;

            }
            else if (e.KeyCode == Keys.Tab)
            {
                this.codeRichTextBox.SelectedText = "    ";
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.runButton.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.AutoSetFont();
                e.SuppressKeyPress = true;
            }
        }


        /// <summary>
        /// 拖入代码时，识别文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeRichTextox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 读取拖入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeRichTextox_DragDrop(object sender, DragEventArgs e)
        {
            this.runInformationLabel.Text = "正在加载文件，请稍等...";
            bool alreadyShowInformation = false;
            string[] filename = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filename.Length > 1)
            {
                this.runInformationLabel.Text = "系统消息: 您拖入了多个文件，仅加载获取到的第一个文件，您可以重复拖入以覆盖原来的内容";
                alreadyShowInformation = true;
            }

            FileStream codeFile = null;
            try
            {
                codeFile = new FileStream(filename[0], FileMode.Open);
                StreamReader reader = null;
                if (this.codeKindCombobox.SelectedItem.ToString() == "ANSI")
                {
                    reader = new StreamReader(codeFile, System.Text.Encoding.Default);
                }
                else if (this.codeKindCombobox.SelectedItem.ToString() == "Unicode")
                {
                    reader = new StreamReader(codeFile, System.Text.Encoding.Unicode);
                }
                else if (this.codeKindCombobox.SelectedItem.ToString() == "UTF-8")
                {
                    reader = new StreamReader(codeFile, System.Text.Encoding.UTF8);
                }
                else
                {
                    codeFile.Close();
                    this.codeRichTextBox.LoadFile(filename[0], RichTextBoxStreamType.RichText);

                }
                this.codeRichTextBox.Text = reader.ReadToEnd().Replace("\t", "    ");
                if (!alreadyShowInformation)
                {
                    this.runInformationLabel.Text = "系统消息：代码加载完毕";
                }
            }
            catch
            {
                this.runInformationLabel.Text = "警告:代码加载过程中出现问题";
            }
            finally
            {
                if (codeFile != null)
                {
                    codeFile.Close();
                }
            }
        }

        /// <summary>
        /// 打印结束信息
        /// </summary>
        private void PrintEndInformation()
        {
            this.outputRichTextBox.AddTextForRichTextBox(0, String.Format("\n运行完成，error({0})", errorTimes));
        }

        //用来跨线程执行代码
        private delegate void ExecThisThead();
        ExecThisThead printEndInformation;

        PaintForm paintForm = null;
        Graphics paintGraphics = null;
        Bitmap bitmap = null;
    }
}
