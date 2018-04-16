using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PackagingDataHelper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            EventHandler handler = (s, e) => {
                if (s == listBox1)
                    listBox2.TopIndex = listBox1.TopIndex;
                if (s == listBox2)
                    listBox1.TopIndex = listBox2.TopIndex;
            };

            this.listBox1.MouseCaptureChanged += handler;
            this.listBox2.MouseCaptureChanged += handler;
            this.listBox1.SelectedIndexChanged += handler;
            this.listBox2.SelectedIndexChanged += handler;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
