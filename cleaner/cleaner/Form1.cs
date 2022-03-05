using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace cleaner
{
    public partial class Form1 : Form
    {
        static bool isrunning = false;
        string[] plugincode = new string[4] { $"@echo off", $"cd /D %temp%", $"for /d %%D in (*) do rd /s /q  %% D", $"del /f /q *" };
        string programdirectory = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\PcCleaner";
        string plugindirectory = @"C:\Users\" +  Environment.UserName + @"\AppData\Roaming\PcCleaner\plugin.bat";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(programdirectory))
            {

            } else
            {
                Directory.CreateDirectory(programdirectory);
                File.WriteAllLines(plugindirectory, plugincode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isrunning == true)
            {
                return;
            }
            else
            {
                isrunning = true;
                Form3 f3 = new Form3();
                f3.ShowDialog();
                Process ps = new Process();
                ps.StartInfo.FileName = plugindirectory;
                ps.StartInfo.CreateNoWindow = true;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                ps.Start();
                Thread.Sleep(100);
                isrunning = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ab = new Form2();
            ab.ShowDialog();
        }
    }
}
