﻿using Contur;
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

        public Form1()
        {
            InitializeComponent();
            image.Refresh();
            UiInit();
        }

        // Create labels, trackbars and initilaze trackbars with Coef values
        //
        private void UiInit()
        {
            for (int i = 0; i < Ukraine.FACTORS_NUMBER; i++)
            {
                Label l = (Label)Controls.Find("factorNamelabel" + i, true)[0];
                l.Text = ukraine.Factors[i].Name;

                l = (Label)Controls.Find("factorValuelabel" + i, true)[0];
                l.Text = ukraine.Regions[0].FactorValues[i].ToString();

                TrackBar t = (TrackBar)Controls.Find("TrackBar" + i, true)[0];
                t.Value = (int)((ukraine.Factors[i].Coef * 10) + 0.5);
            }
        }

        // Show factor values for a region
        //
        private void UiChange(int region_idx)
        {
            for (int i = 0; i < Ukraine.FACTORS_NUMBER; i++)
            {
                Label l = (Label)Controls.Find("factorValuelabel" + i, true)[0];
                l.Text = ukraine.Regions[region_idx].FactorValues[i].ToString();
            }
        }

        public void  RefColor()
        {
            Graphics g =  image.CreateGraphics();
            double[] inv = ukraine.ObInvestAppRegions();
            for(int i=0; i< Ukraine.REGIONS_COUNT; i++)
            {
                ////string name = ((Oblast)i).ToString();
                Color c= AppealToColor(inv, i);             
                Brush brush = new SolidBrush(c);
                g.FillPolygon(brush, ukraine.ConturList.List[i]);
               
            }
       
        }

        private Color AppealToColor(double[] inv, int i)
        {
           var max= inv.Max(d => d);
           var min=  inv.Min(d => d);
           var p= (int)((inv[i]-min) * 255 / (max - min));
            if (inv[i] < 0.08)
            {
                return Color.FromArgb(100, p, 0, p);
            }
            else if (inv[i] > 0.08 && inv[i] < 1.0)
            {
                return Color.FromArgb(100, 0, p/2 , p);

            }
            else if (inv[i] > 1.0 && inv[i] < 1.5)
            {
                return Color.FromArgb(100, 0, p, 0);
            }
            return Color.FromArgb(100,0, 2*p/2, 0);
        }

 
        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        
        void HiLightRegion(Point p)
        {
            Graphics g = image.CreateGraphics();
            image.Refresh();
            var points = ukraine.ConturList.ContursAroundPoint(p).FirstOrDefault();
            if (points != null)
            {
                g.DrawLines(new Pen(Color.Yellow, 2), points);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            image.Refresh();
            RefColor();         
        }



           
                   

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32((sender as TrackBar).Tag);
            ukraine.Factors[i].Coef = (sender as TrackBar).Value/10.0;

        }



        private void image_MouseDown(object sender, MouseEventArgs e)
        {
            HiLightRegion(new Point((int)(e.X), (int)(e.Y)));
            //define conturs number
             
            int conturIndex = ukraine.ConturList.ConturIndexAroundPoint(e.Location);
            InvRegion region = ukraine.Regions.Single(r => r.ConturIndex == conturIndex);
            Text = region.Name;
            int regionIndex = ukraine.Regions.IndexOf(region);
            UiChange(regionIndex);
        }
    }
}
