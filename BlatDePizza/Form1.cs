using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlatDePizza
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();
        Graphics g;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Can add rozmarin, busuioc, blatul mai regulat? up down up down

            //Blat
            PointF[] demo = GeneratePoints(new PointF(300,300), 100,105, 36);
            g.FillPolygon(new SolidBrush(Color.Yellow), demo);
            g.DrawPolygon(new Pen(Color.Black), demo);
            
            //Tomato Sauce
            PointF[] demo2 = GeneratePoints(new PointF(300, 300), 90, 95, 36);
            g.FillPolygon(new SolidBrush(Color.Red), demo2);
            g.DrawPolygon(new Pen(Color.Black), demo2);

            // Mozzarella
            for (int j = 0; j < 100; j++)
            {
                float alpha = (float)(rnd.NextDouble() * Math.PI * 2);
                float d = (float)rnd.NextDouble() * 80;
                float x = 300 + d * (float)Math.Cos(alpha);
                float y = 300 + d * (float)Math.Sin(alpha);

                PointF[] demo3 = Dispersie(new PointF(x, y), 90, 10);

                for (int i = 0; i < demo3.Length; i++)
                {
                    int t = rnd.Next(1, 4);
                    g.FillEllipse(new SolidBrush(Color.White), demo3[i].X - t, demo3[i].Y - t, 2*t + 1, 2*t + 1);
                }
            }

            //Pepperoni
            for (int i = 0; i < 10; i++)
            {
                float alpha = (float)(rnd.NextDouble() * Math.PI * 2);
                float d = (float)rnd.NextDouble() * 70;
                float x = 300 + d * (float)Math.Cos(alpha);
                float y = 300 + d * (float)Math.Sin(alpha);

                Pepperoni(new PointF(x,y));
            }

            pictureBox1.Image = bmp;
        }

        public void Pepperoni(PointF center)
        {
            PointF[] t = GeneratePoints(center, 15, 16, 36);
            g.FillPolygon(new SolidBrush(Color.DarkRed), t);
            g.DrawPolygon(new Pen(Color.Black), t);

            PointF[] d = Dispersie(center, 15, 20);
            for (int i = 0; i < d.Length; i++)
            {
                int x = rnd.Next(1, 2);
                g.FillEllipse(new SolidBrush(Color.RosyBrown), d[i].X - x, d[i].Y - x
                    , 2 * x + 1, 2 * x + 1);
            }
        }

        public PointF[] Dispersie(PointF center, float Rmax, int n)
        {
            PointF[] toR = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                float alpha = (float)(rnd.NextDouble() * Math.PI * 2);
                float d = (float)rnd.NextDouble() * Rmax;
                float x = center.X + d * (float)Math.Cos(alpha);
                float y = center.Y + d * (float)Math.Sin(alpha);
                toR[i] = new PointF(x, y);
            }

            return toR;
        }

        public PointF[] GeneratePoints(PointF center, float Dmin, float Dmax, int k)
        {
            PointF[] toR = new PointF[k]; 
            float[] d = new float[k];
            float alpha = (2 * (float)Math.PI) / k;
            for (int i = 0; i < k; i++)
            {
                d[i] = (float)rnd.NextDouble() * (Dmax- Dmin) + Dmin;
            }

            for (int i = 0; i < k; i++)
            {
                float x = center.X + d[i] * (float)Math.Cos(alpha * i); 
                float y = center.Y + d[i] * (float)Math.Sin(alpha * i);
                toR[i] = new PointF(x, y);
            }

            return toR;
        }
    }
}
