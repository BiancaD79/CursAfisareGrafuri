using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafComplet
{
    internal class MyPoint
    {
        float X, Y;
        public static Random rnd = new Random();

        public MyPoint()
        {
            X = rnd.Next(800);
            Y = rnd.Next(600);
        }

        public Vertex ConvertToVertex(string name)
        {
            string data = name + " " + X.ToString() +" "
                + Y.ToString() + " 128 128 128";
            return new Vertex(data);      
        }
    }
}
