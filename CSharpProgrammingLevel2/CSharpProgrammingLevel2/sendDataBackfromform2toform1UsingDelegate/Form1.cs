using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sendDataBackfromform2toform1UsingDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender , EventArgs e)
        {
            Form2 form = new Form2();
            form.dataBack += GetDataBack;
            form.ShowDialog();
        }

        private void GetDataBack(object sender ,int id)
        {
            textBox1.Text = id.ToString();
        }
    }
}
