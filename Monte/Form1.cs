using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Monte
{
    public partial class Form1 : Form
    {
        double oran = 0.0;
        double sayı1, sayı2;

        string icinde = "İçerdekiler", disinda = "Dışarıdakiler";

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartYap(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (Convert.ToInt64(textBox1.Text) <= 100)
                ChartYap(4);
            else if (Convert.ToInt64(textBox1.Text) <= 1000)
                ChartYap(3);
            else if (Convert.ToInt64(textBox1.Text) <= 10000)
                ChartYap(2);
            else
                ChartYap(1);

            PI();
            button1.Enabled = true;
        }

        private void ChartYap(int boyut)
        {
            chart1.Series.Clear();
            chart1.Series.Add(icinde);
            chart1.Series.Add(disinda);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            
            chart1.Series[icinde].ChartType = SeriesChartType.FastPoint;
            chart1.Series[icinde].MarkerStyle = MarkerStyle.Circle;
            chart1.Series[icinde].MarkerSize = boyut;
            chart1.Series[icinde].MarkerColor = Color.Red;

            chart1.Series[disinda].ChartType = SeriesChartType.FastPoint;
            chart1.Series[disinda].MarkerStyle = MarkerStyle.Circle;
            chart1.Series[disinda].MarkerSize = boyut;
            chart1.Series[disinda].MarkerColor = Color.Black;
        }

        public void goster(long sayac)
        {
                oran = 4 * chart1.Series[icinde].Points.Count / (double)sayac;
                label1.Text = oran.ToString();
                label2.Text = sayac.ToString();
        }

        private void PI()
        {            
            Random r = new Random();
            for (int i = 1; i <= Convert.ToInt64(textBox1.Text); i++)
            {
                sayı1 = r.Next(0, 100001) / 100000.0;
                sayı2 = r.Next(0, 100001) / 100000.0;

                if ((sayı1 - 0.5) * (sayı1 - 0.5) + (sayı2 - 0.5) * (sayı2 - 0.5) <= 0.25)
                {
                    chart1.Series[icinde].Points.Add(new DataPoint(sayı1, sayı2));                  
                }
                else
                {
                    chart1.Series[disinda].Points.Add(new DataPoint(sayı1, sayı2));
                }

                if (i % Convert.ToInt64(textBox2.Text) == 0)
                {
                    goster(i);
                    Application.DoEvents();
                }
                
            }
            goster(Convert.ToInt64(textBox1.Text));

        }
    }
}
