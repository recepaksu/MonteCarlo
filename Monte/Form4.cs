using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Monte
{
    public partial class Form4 : Form
    {
        long adet, artisMiktari;

        public Form4(long a, long b)
        {
            InitializeComponent();
            adet = a;
            artisMiktari = b;

            chart1.Series.Add("Noktalar");
            chart1.Series.Add("Pi");
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[1].Color = Color.Red;
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisY.Minimum = 3.0;
            chart1.ChartAreas[0].AxisY.Maximum = 3.25;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            float x, y;
            long icinde = 0, katsayi = 500, dongu = adet;
            double oran = 0.0;
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(9, 9), new Point((int)katsayi + 11, 9));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(10, (int)katsayi + 12), new Point((int)katsayi + 12, (int)katsayi + 12));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(9, 9), new Point(9, (int)katsayi + 12));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point((int)katsayi + 12, 9), new Point((int)katsayi + 12, (int)katsayi + 12));
            Random r = new Random();
            long goster;
            if (artisMiktari == 0)
                goster = r.Next(50000, 100000);
            else
                goster = artisMiktari;

            for (int i = 1; i <= dongu; i++)
            {
                x = r.Next(0, 100001) / 100000.0F;
                y = r.Next(0, 100001) / 100000.0F;

                if ((x - 0.5) * (x - 0.5) + (y - 0.5) * (y - 0.5) <= 0.25)
                {
                    icinde++;
                    e.Graphics.FillRectangle(new SolidBrush(Color.CadetBlue), 10 + x * katsayi, 10 + y * katsayi, 1, 1);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), 10 + x * katsayi, 10 + y * katsayi, 1, 1);
                }

                switch (i)
                {
                    case 10:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;

                    case 100:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;

                    case 1000:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;

                    case 10000:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;
                    case 100000:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;
                    case 1000000:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;
                    case 10000000:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;
                    case 100000000:
                        oran = 4.0 * icinde / i;
                        chart1.Series[0].Points.AddXY(i.ToString(), oran);
                        chart1.Series[1].Points.AddXY(i.ToString(), Math.PI);
                        Application.DoEvents();
                        break;

                    default:
                        break;
                }
                if (i % goster == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, katsayi + 13, katsayi + 40, 100);
                    oran = 4.0 * icinde / i;
                    e.Graphics.DrawString("PI= " + oran.ToString(), new Font("Times New Roman", 12.0F), new SolidBrush(Color.Black), 8, katsayi + 15);
                    e.Graphics.DrawString("Adet = " + i.ToString(), new Font("Times New Roman", 12.0F), new SolidBrush(Color.Black), 350, katsayi + 15);
                    
                }
                
            }
            oran = 4.0 * icinde / dongu;
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, katsayi + 13, katsayi + 40, 100);
            e.Graphics.DrawString("PI= " + oran.ToString(), new Font("Times New Roman", 12.0F), new SolidBrush(Color.Black), 8, katsayi + 15);
            e.Graphics.DrawString("Adet = " + dongu.ToString(), new Font("Times New Roman", 12.0F), new SolidBrush(Color.Black), 350, katsayi + 15);
            e.Graphics.DrawLine(new Pen(Color.White, 1), new Point(10, 10), new Point((int)katsayi + 11, 10));
            e.Graphics.DrawLine(new Pen(Color.White, 1), new Point(10, 10), new Point(10, (int)katsayi + 11));
            
            MessageBox.Show("Tamamlandı...", "", MessageBoxButtons.OK);
        }
    }
}
