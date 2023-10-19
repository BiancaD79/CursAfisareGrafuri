using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursAfisareGrafuri
{
    public class Edge// o muchie e formata din 2 vertexuri, begin si end, gen A --> B (--> e muchia)
    {
        public Vertex begin;
        public Vertex end;
        Color fillColor;
        public Edge(string data, List<Vertex> vertices)
        {
            string n1 = data.Split(' ')[0];
            foreach(Vertex vertex in vertices)
            {
                if(n1 == vertex.name)
                    begin = vertex;
            }
            string n2 = data.Split(' ')[1];
            foreach (Vertex vertex in vertices)
            {
                if (n2 == vertex.name)
                    end = vertex;
            }
        }
        public void Draw(Graphics handler,string data)
        {
            string[] local = data.Split(' ');
            Pen pen = new Pen(new SolidBrush(Color.Gold), 5); 
            handler.DrawLine( pen, begin.X, begin.Y, end.X, end.Y);
        }
    }
}