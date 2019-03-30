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

namespace 图片代码生成器
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            this.pictureBox.AllowDrop = true;
            this.pictureBox.DragEnter += PictureBox_DragEnter;
            this.pictureBox.DragDrop += PictureBox_DragDrop;
            this.upPanel.Paint += UpPanel_Paint;
            this.imageHeightNumberUpDown.ValueChanged+= ImageHeightNumberUpDown_ValueChanged;
            this.imageHeightTrackBar.ValueChanged += ImageHeightTrackBar_ValueChanged;
        }

        /// <summary>
        /// 滑动滑动条时自动改变上下调节框的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageHeightTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.imageHeightNumberUpDown.ValueChanged -= ImageHeightNumberUpDown_ValueChanged;
            this.imageHeight = this.imageHeightTrackBar.Value;
            this.imageHeightNumberUpDown.Value = this.imageHeight;
            this.imageHeightNumberUpDown.ValueChanged += ImageHeightNumberUpDown_ValueChanged;
        }

        /// <summary>
        /// 上下调值框改变数值的时候滑动滑条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageHeightNumberUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.imageHeightTrackBar.ValueChanged += ImageHeightTrackBar_ValueChanged;
            this.imageHeight = int.Parse(this.imageHeightNumberUpDown.Text);
            this.imageHeightTrackBar.Value = this.imageHeight;
            this.imageHeightTrackBar.ValueChanged += ImageHeightTrackBar_ValueChanged;
        }

        /// <summary>
        /// 绘制边框线，美观
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.Silver), 0, 0, this.upPanel.Width - 1, 0);
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.Silver), 0, this.upPanel.Height - 1, this.upPanel.Width - 1, this.upPanel.Height - 1);
        }

        /// <summary>
        /// 拖放图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                this.infoLabel.Text = "";
                this.bitmap = new Bitmap(fileStream);
                if(this.bitmap.Height<200)
                {
                    MessageBox.Show("您放入的图片太小");
                    return;
                }

                pictureBox.BackgroundImage = this.bitmap;
                this.imageHeightTrackBar.Value = 200;
                this.imageHeightNumberUpDown.Value = 200;
                this.imageHeightTrackBar.Maximum = this.bitmap.Height;
                this.imageHeightNumberUpDown.Maximum= this.bitmap.Height;
                fileStream.Close();
                fileStream.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Bitmap bitmap = new Bitmap(pictureBox.BackgroundImage);
            int width = bitmap.Width;
            int height = bitmap.Height;
            Color[] color = new Color[] { bitmap.GetPixel(5, 5), bitmap.GetPixel(width - 5, 5), bitmap.GetPixel(width - 5, height - 5) };

            if (judgeSimilar(color[0], color[1]))
            {
                this.colorLabel.BackColor = color[0];
            }
            else if (judgeSimilar(color[0], color[2]))
            {
                this.colorLabel.BackColor = color[0];
            }
            else if (judgeSimilar(color[1], color[2]))
            {
                this.colorLabel.BackColor = color[1];
            }
            else
            {
                MessageBox.Show("背景颜色自动识别失败，请手动选择，默认为白色");
                this.colorLabel.BackColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 图片进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if(fileName.ToLower().EndsWith(".png")|| fileName.ToLower().EndsWith(".jpg"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        
        /// <summary>
        /// 点击生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButton_Click(object sender, EventArgs e)
        {
            if(this.pictureBox.BackgroundImage==null)
            {
                MessageBox.Show("请拖入要处理的图片");
                return;
            }

            //获取保存文件路径
            string fileName = "result.txt";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "选择代码文件保存路径";
            saveFileDialog.FileName = fileName;
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;   
            }
            else
            {
                return;
            }

            //向文件写入代码
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                fileStream= new FileStream(fileName, FileMode.Create);
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine("--此代码为自动生成，为UTF-8编码，by fish\n");
                streamWriter.WriteLine("--设置系统参数");
                streamWriter.WriteLine("origin is (100, 100);                                                       -- 设置原点的偏移量");
                streamWriter.WriteLine("scale is (1, 1);                                                            -- 设置横、纵坐标比例");
                streamWriter.WriteLine("rot is 0;                                                                   --设置旋转角度\n");
                streamWriter.Flush();
            }
            catch(Exception ex)
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }

                MessageBox.Show(ex.Message);
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                return;
            }

            //获取图片
            //强制将图片宽度压缩到200像素
            int width = bitmap.Width;
            int height = bitmap.Height;

            this.bitmap = new Bitmap(this.bitmap, new Size(this.imageHeight * width/height, this.imageHeight));
            width = bitmap.Width;
            height = bitmap.Height;

            //获取背景色
            Color backColor = colorLabel.BackColor;
            //生成像素点绘制代码
            for(int y=0;y<height;y++)
            {
                int leftIndex = 0;
                int length = 0;
                bool beforeIsImage = false;
                streamWriter.WriteLine("//第" + (y + 1) + "行像素代码");
                for (int x=0;x<width;x++)
                {
                    if(x==270)
                    {

                    }
                    Color pixelColor = bitmap.GetPixel(x, y);
                    if(beforeIsImage) //上一张是图片内容
                    {
                        if(!judgeSimilar(backColor, pixelColor))        //图片内容
                        {
                            length++;
                            beforeIsImage = true;
                        }
                        else
                        {
                            if(length>0)
                            {
                                streamWriter.WriteLine("For T From {0} To {1} step 0.05 draw(t,{2});", leftIndex, leftIndex + length, y);
                            }
                            beforeIsImage = false;
                            length = 0;
                        }
                        
                    }
                    else
                    {
                        if (!judgeSimilar(backColor, pixelColor))       //图片内容
                        {
                            leftIndex = x;
                            length=1;
                            beforeIsImage = true;
                        }
                        else
                        {
                            beforeIsImage = false;
                        }
                    }
                }

                if (length > 0)
                {
                    streamWriter.WriteLine("For T From {0} To {1} step 0.5 draw(t,{2});", leftIndex, leftIndex + length, y);
                }

                //写入一行像素的代码
                streamWriter.Flush();
            }

            if (streamWriter != null)
            {
                streamWriter.Close();
                streamWriter = null;
            }

            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }

            MessageBox.Show("代码生成完毕");
            System.Diagnostics.Process.Start(fileName);
        }

        /// <summary>
        /// 点击选择背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = this.colorLabel.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorLabel.BackColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// 判断另个颜色是否相近
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        /// <returns></returns>
        private bool judgeSimilar(Color color1,Color color2)
        {
            float h1 = color1.GetHue();             //色相：0~360°的标准色轮
            float s1 = color1.GetSaturation();      //饱和度：0~100%
            float b1 = color1.GetBrightness();      //亮度:0~100%

            float h2 = color2.GetHue();
            float s2 = color2.GetSaturation();
            float b2 = color2.GetBrightness();
            //int h1 = color1.R;
            //int s1 = color1.G;
            //int b1 = color1.B;

            //int h2 = color2.R;
            //int s2 = color2.G;
            //int b2 = color2.B;
            //if (h1 == h2 && s1 == s2 && b1 == b2)
            if (Math.Abs(h1-h2)<15&& Math.Abs(s1*100-s2*100)<50&& Math.Abs(b1*100-b2*100)<50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Bitmap bitmap = null;
        private int MaxHueOfHSBColor = 15;
        private int MaxSaturationOfHSBColor = 50;
        private int MaxBrightnessOfColor = 50;

        private int imageHeight=200;

    }
}
