using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFomsDoWorkAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int slowFunc(int a, int b)
        {
            System.Threading.Thread.Sleep(10000);
            return a + b;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            var someTask = Task<int>.Factory.StartNew(() => slowFunc(1, 2));
            await someTask;
            this.label1.Text = "Result: " + someTask.Result.ToString();
            this.button1.Enabled = true;
        }
    }
}
