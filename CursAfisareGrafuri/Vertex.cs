using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursAfisareGrafuri
{
    public class Vertex // vertex = noduri, fiecare nod are un nume si pozitiile x, y
    {
        public string name;
        public int X, Y;
        static int size = 20;//marimea cercului gen
        public Color fillColor;
        public Vertex(string data) 
        {
            string[] local = data.Split(' ');
            name = local[0];
            X = int.Parse(local[1]);
            Y = int.Parse(local[2]);

            int R = int.Parse(local[3]);
            int G = int.Parse(local[4]);
            int B = int.Parse(local[5]);
            fillColor = Color.FromArgb(R, G, B);//luam coordonatele de local[0] numele, X si Y = local[1],[2], restul de 3 coord sunt
            //coduri de culoare
        }
        public void Draw(Graphics handler)
        {
            handler.FillEllipse(new SolidBrush(fillColor), X - size, Y - size, 2 * size + 1, 2 * size + 1);//umplem elipsa de culoare
            handler.DrawEllipse(Pens.Black, X - size, Y - size, 2 * size + 1, 2 * size + 1);//o desenam
            handler.DrawString(name, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.White), new Point(X - size / 2, Y - size / 2));//desenam numele

        }
    }
}