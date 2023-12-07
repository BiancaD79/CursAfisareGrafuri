using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS_DFS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graph demo;
        Graphics grp;
        Bitmap bmp;
        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            demo = new Graph();
            demo.Load("../../input.txt");
            demo.Dispersion(new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), 150);

            List<Vertex> t = demo.BFS(demo.vertices[0]);

            foreach (Vertex v in t)
            {
                sb.Append(v.idx + " ");
            }
            listBox1.Items.Add(sb.ToString());

            t = demo.DFS(demo.vertices[0]);
            sb.Clear();
            foreach (Vertex v in t)
            {
                sb.Append(v.idx + " ");
            }
            listBox1.Items.Add(sb.ToString());

            t = demo.DFS_Rec(demo.vertices[0]);
            sb.Clear();
            foreach (Vertex v in t)
            {
                sb.Append(v.idx + " ");
            }
            listBox1.Items.Add(sb.ToString());

            demo.Draw(grp);
            pictureBox1.Image = bmp;



            /*MyStack<int> myStack = new MyStack<int>();
            //GenericList<int> genericList = new GenericList<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            label1.Text = myStack.Pop().ToString();

            MyQueue<int> myQueue = new MyQueue<int>();
            myQueue.Push(5);
            myQueue.Push(6);
            myQueue.Push(7);
            label1.Text = myQueue.View();*/

            /*
             *      ___          ___
             *  ---| O |--------| O |---
             *      ---          ---
             *             |
             *       \            /
             *         -----------
             * 
             * 
             * 
             * 
             */

        }
}
}
