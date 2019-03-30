using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 绘图解释器
{
    public partial class PaintForm : Form
    {
        public PaintForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
