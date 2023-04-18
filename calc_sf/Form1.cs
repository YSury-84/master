using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc_sf
{
    public partial class Form1 : Form
    {

        public byte[] SetDelphiShortString(string str)
        {
            var bytes = new byte[256];
            bytes[0] = (byte)Encoding.Default.GetBytes(str, 0, str.Length, bytes, 1);
            return bytes;
        }

        public string GetDelphiShortString(byte[] bStrOf)
        {
            char[] output = new char[bStrOf[0]];
            var asciiDecoder = Encoding.Default.GetDecoder();
            asciiDecoder.GetChars(bStrOf, 1, bStrOf[0], output, 0);
            string s = "";
            for (int i = 1; i <= bStrOf[0]; i++)
                s = s + output[i - 1];
            return s;
        }


        [DllImport(@"compute.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "compute_us", ExactSpelling = true)]
        static extern void compute_us(byte[] sIf, byte accuracy, byte[] sOf);

        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button4.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button7.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button11.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string mytext = textBox1.Text;
            textBox1.Text = "";
            for (int i = 0; i < mytext.Length-1; i++)
                textBox1.Text = textBox1.Text + mytext[i];
            if (textBox1.Text == "") textBox1.Text = "0";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            byte[] sOf = new byte[256];
            compute_us(SetDelphiShortString("="+textBox1.Text),2,sOf);
            textBox1.Text = GetDelphiShortString(sOf);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button3.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button6.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button10.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button12.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button15.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text = textBox1.Text + button18.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
    }
}
