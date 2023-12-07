using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafComplet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = new MyGraphics(pictureBox1);
        }

        MyGraphics graphics;
        Algorithm algorithm;
        private void Form1_Load(object sender, EventArgs e)
        {
            algorithm = new Algorithm(20);
            Graph demo = algorithm.Action();
            demo.Draw(graphics.grp);
            graphics.Refresh();
        }
    }
}
