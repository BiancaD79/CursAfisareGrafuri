using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafComplet
{
    internal class Edge
    {
        public Vertex begin;
        public Vertex end;
        public float cost;
        public Edge(string data, List<Vertex> vertices)
        {
            string n1 = data.Split(' ')[0];
            foreach (Vertex vertex in vertices)
            {
                if (n1 == vertex.name)
                    begin = vertex;
            }
            string n2 = data.Split(' ')[1];
            foreach (Vertex vertex in vertices)
            {
                if (n2 == vertex.name)
                    end = vertex;
            }
        }// TODO: adaugat cost

        public Edge (Vertex begin, Vertex end)
        {
            this.begin = begin;
            this.end = end;
            this.cost = MyMath.distEuclid(new PointF(begin.X, begin.Y) 
                , new PointF(end.X, end.Y));
        }

        public void Draw(Graphics handler, string data)
        {
            string[] local = data.Split(' ');
            Pen pen = new Pen(new SolidBrush(Color.Gold), 5);
            handler.DrawLine(pen, begin.X, begin.Y, end.X, end.Y);
        }

        public void Draw(Graphics handler)
        {
            handler.DrawLine(Pens.Black, begin.X, begin.Y, end.X, end.Y);
        }
    }
}
