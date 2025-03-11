using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sendDatafrom_form1toform2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender , EventArgs e)
        {
            int _personid = -1;

            if(int.TryParse(textBox1.Text,out _personid) && _personid != -1)
            {
                Form2 form2 = new Form2( _personid);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect input Plaese input number " , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }

        }
    }
}
