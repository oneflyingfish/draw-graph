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
    /// <summary>
    /// 对输入框功能进行扩展
    /// </summary>
    public static class MyRichTextbox
    {
        /// <summary>
        ///自动插入解释器输出文本信息
        /// kind=0: 最后一行追加字符串(未出错） 
        /// kind=1：另起一行加入字符串(未出错) 
        /// kind=2: 另起一行加入字符串(出错标红) 
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="kind">插入文本类型</param>
        /// <param name="code">代码内容</param>
        /// <param name="lineNumber">指示代码是第多少行</param>
        /// <param name="info">附加说明</param>
        public static void AddTextForRichTextBox(this RichTextBox richTextBox, int kind, string code, int lineNumber=-1, string info="")
        {
            switch (kind)
            {
                case 0:
                    richTextBox.SelectionColor = System.Drawing.Color.RoyalBlue;
                    richTextBox.AppendText(code);
                    break;
                case 1:
                    richTextBox.AppendText("\n");
                    richTextBox.SelectionColor = System.Drawing.Color.RoyalBlue;
                    richTextBox.AppendText("正常（第" + lineNumber.ToString() + "行）: " + "“" + code + "”，执行完毕");
                    break;
                case 2:
                    richTextBox.AppendText("\n");
                    richTextBox.SelectionColor = System.Drawing.Color.Red;
                    richTextBox.AppendText("错误（第"+ lineNumber.ToString()+"行）：" + "“" + code + "”，" + info);
                    break;
                default:
                    return;
            }
            richTextBox.ScrollToCaret();
        }
    }
}
