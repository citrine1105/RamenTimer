using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RamenTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Font = SystemFonts.MessageBoxFont;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label2.Text = progressBar1.Maximum.ToString();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            label2.Text = Convert.ToString(progressBar1.Maximum - progressBar1.Value);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                MessageBox.Show("いただきます", "ラーメンタイマー", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
