using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafComplet
{
    internal class Algorithm
    {
        List<MyPoint> points;
        public Algorithm(int n)
        {
            points = new List<MyPoint>();
            for (int i = 0; i < n; i++)
            {
                points.Add(new MyPoint());
            }
        }

        public Graph Action()
        {
            List<Vertex> vertices = new List<Vertex>();

            for (int i = 0; i < points.Count; i++)
            {
                vertices.Add(points[i].
                    ConvertToVertex(i.ToString()));
            }

            Graph local = new Graph(vertices);

            return local;
        }
    }
}
