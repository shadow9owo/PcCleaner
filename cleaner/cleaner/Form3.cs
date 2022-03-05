using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace cleaner
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 125)
            {
                timer1.Stop();
                DialogResult dr = MessageBox.Show("scanning succefuly has been completed", "PcCleaner",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
            }else
            {
                progressBar1.Value++;
            }
        }
    }
}
