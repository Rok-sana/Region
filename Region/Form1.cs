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

        public Form1()
        {
            InitializeComponent();
            image.Refresh();
            UiInit();
        }

        private void UiInit()
        {
            factorNamelabel0.Text= ukraine.Factors[0].Name;
            factorNamelabel1.Text = ukraine.Factors[1].Name;
        }
        private void UiChange(Oblast id)
        {
            factorValuelabel0.Text = ukraine.Regions[id].FactorValues[0].ToString();
            factorValuelabel1.Text = ukraine.Regions[id].FactorValues[1].ToString();
        }
        public void  RefColor()
        {
            Graphics g =  image.CreateGraphics();
            double[] inv = ukraine.ObInvestAppRegions();
            for(int i=0; i< Ukraine.REGIONS_COUNT; i++)
            {
                string name = ((Oblast)i).ToString();
                Color c= AppealToColor(inv, i);             
                Brush brush = new SolidBrush(c);
                g.FillPolygon(brush, ukraine.Conturs[name]);
               
            }
       
        }

        private Color AppealToColor(double[] inv, int i)
        {
           var max= inv.Max(d => d);
           var min=  inv.Min(d => d);
           var p= (int)((inv[i]-min) * 255 / (max - min));
           return Color.FromArgb(0, p, 0);
        }

 
        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
            HiLightRegion(new Point((int)(e.X), (int)(e.Y)));
            string selected = ukraine.Conturs.GetPoligonePointInto(e.Location);
            if (selected != null)
            {
                Oblast id = (Oblast)Enum.Parse(typeof(Oblast), selected);
                UiChange(id);
            }
           
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
                //Oblast id;
                //if (Enum.TryParse(selected, out id))
                //{
                //    var region = ukraine.Regions.SingleOrDefault(r => r.Id == id);
                //    if (region != null)
                //        //textBox1.Text = region.FactorValues[0].ToString();
                //}

               
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            image.Refresh();
            RefColor();         
        }
        


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           //// Ukraine ukraine = new Ukraine();
           // double[] inv = ukraine.ObInvestAppRegions();
           // Oblast id;
           // using (StreamReader reader = new StreamReader("Regions.txt"))
           // {
           //     for (int i = 0; i < Ukraine.REGIONS_COUNT; i++)
           //     {
           //      if( selected = ukraine.Conturs.GetPoligonePointInto(ukraine.Conturs[selected]);
           // for (int i = 0; i < Ukraine.REGIONS_COUNT; i++)
           // {

           //     //выбрать цвет
           //     if (inv[i] >= 1)
           //     {
                    
           //         if (Enum.TryParse(selected, out id))
           //         {
           //             Brush n = new SolidBrush(Color.FromArgb(100, 200, 0, 0));
           //             e.Graphics.FillPolygon(n, ukraine.Conturs[selected]);
                        //    var region = ukraine.Regions.SingleOrDefault(r => r.Id == id);

                        //    if (region != null)

                        //        textBox1.Text = region.FactorValues[0].ToString();
                        //    //var ps = ukraine.Conturs[selected].Select(pt => new Point((int)(pt.X), (int)(pt.Y))).ToArray();
                        //        //g.(new Pen(Color.Yellow, 2), ps);
                        //        Brush n = new SolidBrush(Color.FromArgb(100, 200, 0, 0));
                        //e.Graphics.FillPolygon(n, ukraine.Conturs[selected]);
                    }


                    //}
                    //else if (inv[i] <= 0.9 && inv[i] >= 0.6)
                    //{
                    //    Brush b = new SolidBrush(Color.FromArgb(100, 100, 0, 0));
                    //    e.Graphics.FillPolygon(b, arr);
                    //}
                    //else
                    //{
                    //    Brush b = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
                    //    e.Graphics.FillPolygon(b, arr);

                    //}

                

            
        









        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
