using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long adet = Convert.ToInt64(textBox1.Text), artisMiktari = Convert.ToInt64(textBox2.Text);
            Form4 a = new Form4(adet, artisMiktari);
            this.Hide();
            
            a.ShowDialog();
            this.Show();
        }
    }
}
