using Region.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Region
{

    public partial class Form1 : Form
    {        
        Ukraine ukraine = new Ukraine();
        ConturHelper conturHelper = new ConturHelper("xconturs.txt");
        Image front = new Bitmap("UkraineTrans.png");

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
                toolTip1.SetToolTip(l, ukraine.Factors[i].Comment);

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

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32((sender as TrackBar).Tag);
            ukraine.Factors[i].Coef = (sender as TrackBar).Value/10.0;
            image.Refresh();
        }


        private void image_MouseDown(object sender, MouseEventArgs e)
        { 
            int conturIndex = conturHelper.ConturIndexAroundPoint(e.Location);
            if (conturIndex < Ukraine.REGIONS_COUNT)
            {
                HiLightRegion(e.Location);
            
                InvRegion region = ukraine.Regions.Single(r => r.ConturIndex == conturIndex);
                int regionIndex = ukraine.Regions.IndexOf(region);
                UiChange(regionIndex);

                regionLabel.Text = region.Name;
            }
        }

        void HiLightRegion(Point p)
        {
            image.Refresh();
            Graphics g = image.CreateGraphics();
            var points = conturHelper.ContursAroundPoint(p).FirstOrDefault();
            g.DrawLines(new Pen(Color.Blue, 3), points);
        }

        private void image_Paint(object sender, PaintEventArgs e)
        {
            if (conturHelper != null)
                RefreshColor(e.Graphics);
        }

        public void RefreshColor(Graphics g)
        {
            ukraine.CalcInvestAppRegions();
            var sortedRegs = ukraine.Regions.OrderByDescending(r => r.InvApp).ToArray();

            for (int i = 0; i < Ukraine.REGIONS_COUNT; i++)
            {
                int rait = sortedRegs.TakeWhile(r => r.Name != ukraine.Regions[i].Name).Count();
              
                Color color = RaitToColor(rait);
                Brush brush = new SolidBrush(color);
                int idx = ukraine.Regions[i].ConturIndex;
                g.FillPolygon(brush, conturHelper.List[idx]);
            }

            // sort regions by rait
            string[] names = sortedRegs.Select((r, i) => (i+1) + ". " + r.Name).ToArray();
            raitLabel.Text = string.Join("\r\n", names);
        }

        private Color RaitToColor(int rait)
        {
            int red = rait * 255 / Ukraine.REGIONS_COUNT;
            return Color.FromArgb(100, red, 255 - red, 0);
        }


        private Color AppealToColor(double[] inv, int i)
        {
            var A = 100;
            var max = inv.Max(d => d);
            var min = inv.Min(d => d);
            var p = (int)((inv[i] - min) * 255 / (max - min));
            if (inv[i] < 0.08)
            {
                return Color.FromArgb(A, p, 0, p);
            }
            else if (inv[i] > 0.08 && inv[i] < 1.0)
            {
                return Color.FromArgb(A, 0, p / 2, p);

            }
            else if (inv[i] > 1.0 && inv[i] < 1.5)
            {
                return Color.FromArgb(A, 0, p, 0);
            }
            return Color.FromArgb(A, 0, 2 * p / 2, 0);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
