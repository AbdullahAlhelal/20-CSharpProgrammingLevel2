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
    public partial class Form2 : Form
    {

        public delegate void HandelDataBack(object sender , int id);


        public  HandelDataBack dataBack;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender , EventArgs e)
        {
            int id = -1;
            if (int.TryParse(textBox1.Text , out id))
                dataBack?.Invoke(this , id);

            this.Close();
        }
    }
}
