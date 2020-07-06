using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.MessageSucceded = true;
            Form1.MessageContent = b_Puvodni.Text;
            this.DialogResult = DialogResult.OK;

        }

        private void b_Zkomprimovanou_Click(object sender, EventArgs e)
        {
            Form1.MessageSucceded = true;
            Form1.MessageContent = b_Zkomprimovanou.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
