using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void calculate()
        {

            try
            {
                var a = Convert.ToInt32(textBox1.Text);

                int b;

                Int32.TryParse(textBox2.Text, out b);
                label3.Text = Convert.ToString(a / b);
            }
            catch (DivideByZeroException zeroException)
            {
                label3.Text = "Divide By Zero is not allowed";

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var handles = new IntPtr[300];

            for (int i = 0; i < handles.Length; i++)
            {
                handles[i] = Marshal.AllocHGlobal(100 * 1024 * 1024);
                //Marshal.FreeHGlobal();
                
                label5.Text = Convert.ToString(Marshal.SizeOf(handles[i]));
            }

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var startTime = DateTime.UtcNow;
            while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(60))
            {
                label6.Text = Convert.ToString(DateTime.UtcNow);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i=0; i < 5; i++)
            {
                Thread listenThread;
                listenThread = new Thread(new ThreadStart(ExecuteJob));
              //  listenThread.IsBackground = true;
                listenThread.Start();
              //  Thread.Sleep(3000);
            }
            

            
        }
        private void ExecuteJob()
        {
            var startTime = DateTime.UtcNow;
            int count = 0;
            while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(30))
            {
                label4.Text = Convert.ToString(count++);
            }
        }
    }
}
