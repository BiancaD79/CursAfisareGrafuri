using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursAfisareGrafuri
{
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        public bool[,] ma;
        public static Color[] defaultColors = new Color[] {Color.Violet,Color.Orange,Color.Red,Color.Blue,Color.Cyan, Color.Tan, Color.Pink,Color.Black};
        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        public void Load(string data)
        {
            TextReader reader = new StreamReader(data);
            int n = int.Parse(reader.ReadLine());
            for(int i = 0; i < n; i++)
                vertices.Add(new Vertex(reader.ReadLine()));
            string buffer = "";
            while ((buffer = reader.ReadLine()) != null)
                edges.Add(new Edge(buffer, vertices));
            ma = new bool[n, n];
            for (int i = 0; i < edges.Count; i++)
            {
                int x = Idx(edges[i].begin.name);
                int y = Idx(edges[i].end.name);
                ma[x,y] = ma[y,x] = true;
            }

        }
        public int Idx(string name)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (name == vertices[i].name)
                    return i;
            }
            return -1;
        }
        public List<string> Debug()
        {
            List<string> toR = new List<string>();
            for (int i = 0; i < vertices.Count; i++)
            {
                string buffer = "";
                for (int j = 0; j < vertices.Count; j++)
                {
                    buffer += ma[i, j] + " ";

                }
                toR.Add(buffer);
            }
            return toR;
        }
        public void Draw(Graphics handler)
        {
            foreach (Edge edge in edges)
                edge.Draw(handler, @"..\..\CoordonateGraf.txt");
            foreach (Vertex vertex in vertices)
                vertex.Draw(handler);
        }

        public void GreedyColoring()
        {
            int n = vertices.Count;
            int[] colors = new int[n];
            for (int i = 0; i < n; i++)
            {
                colors[i] = -1;
            }
            colors[0] = 0;
            for(int i = 1; i < n; i++)
            {
                bool[] local = new bool[n];
                for (int j = 0; j < n; j++)
                {
                    if (ma[i, j])
                        if (colors[j] != -1)
                            local[colors[j]] = true;
                }
                int idx = 0;
                while (local[idx]) idx++;
                colors[i] = idx;
            }
            for (int i = 0; i < n; i++)
            {
                vertices[i].fillColor = defaultColors[colors[i]];
            }
        }

    }
}