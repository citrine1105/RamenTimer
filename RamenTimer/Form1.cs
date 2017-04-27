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
            pictureBox1.Image = Image.FromFile("./images/1_1.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Font = SystemFonts.MessageBoxFont;
            label8.Font = SystemFonts.MessageBoxFont;
            button1.Font = SystemFonts.MessageBoxFont;
            numericUpDown1.Font = SystemFonts.MessageBoxFont;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                progressBar1.Value = 0;
                label2.Text = "0";
                label4.Text = "0";
                timer1.Enabled = false;
                numericUpDown1.Enabled = true;
                button1.Text = "スタート";
            }
            else
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = decimal.ToInt32(numericUpDown1.Value) * 60 * 2;   // 時間設定
                int starttime = progressBar1.Maximum / 2;
                label2.Text = string.Format("{0}", starttime / 60);
                label4.Text = string.Format("{0}", starttime % 60);
                timer1.Enabled = true;
                numericUpDown1.Enabled = false;
                button1.Text = "ストップ";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            label2.Text = Convert.ToString((progressBar1.Maximum  - progressBar1.Value) / 2 / 60);
            label4.Text = Convert.ToString((progressBar1.Maximum - progressBar1.Value) / 2 % 60);
            if (progressBar1.Maximum - progressBar1.Value < 120)    // 残り時間が1分以内の場合
            {
                if (progressBar1.Value % 2 == 0)
                {
                    pictureBox1.Image = Image.FromFile("./images/2_1.png");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("./images/2_2.png");
                }
            }
            else
            {
                if (progressBar1.Value % 2 == 0)
                {
                    pictureBox1.Image = Image.FromFile("./images/1_1.png");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("./images/1_2.png");
                }
            }
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                pictureBox1.Image = Image.FromFile("./images/3_1.png");
                MessageBox.Show("いただきます", "ラーメンタイマー", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numericUpDown1.Enabled = true;
                button1.Text = "スタート";
            }
        }
    }
}
