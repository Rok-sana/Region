using Contur;
using Region.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Region
{

    public partial class Form1 : Form
    {
        
        Ukraine ukraine = new Ukraine();
        
        private string current = null;

        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
            HiLightRegion(new Point((int)(e.X), (int)(e.Y)));
        }

        void HiLightRegion(Point p)
        {
            string selected = ukraine.Conturs.GetPoligonePointInto(p);
            if (selected != current)
            {
                Graphics g = image.CreateGraphics();
                image.Refresh();
                if (selected != null)
                {
                    var ps = ukraine.Conturs[selected].Select(pt => new Point((int)(pt.X), (int)(pt.Y))).ToArray();
                    g.DrawLines(new Pen(Color.Yellow, 2), ps);
                }
                current = selected;
                Oblast id;
                if (Enum.TryParse(selected, out id))
                {
                    var region = ukraine.Regions.SingleOrDefault(r => r.Id == id);
                    if (region != null)
                        textBox1.Text = region.FactorValues[0].ToString();
                }

               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            image.Refresh();         
        }

        public Form1()
        {
            InitializeComponent();
            //inv = ukraine.ObInvestAppRegions();
            dataGridView1.DataSource = ukraine.Factors;
            image.Refresh();
        }

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            //for (int i = 0; i < Ukraine.REGIONS_COUNT; i++)
            //{
            //    PointF[] arr = CorrectArray(ukraine.regions[i].borderPoints);

            //    //выбрать цвет
            //    if (inv[i] >= 1)
            //    {
            //        Brush b = new SolidBrush(Color.FromArgb(100, 200, 0, 0));
            //        e.Graphics.FillPolygon(b, arr);
            //    }
            //    else if (inv[i] <= 0.9 && inv[i] >= 0.6)
            //    {
            //        Brush b = new SolidBrush(Color.FromArgb(100, 100, 0, 0));
            //        e.Graphics.FillPolygon(b, arr);
            //    }
            //    else
            //    {
            //        Brush b = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            //        e.Graphics.FillPolygon(b, arr);

            //    }
                
           // }

        }










        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
