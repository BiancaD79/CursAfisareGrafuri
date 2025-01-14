using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace GrafComplet
{
    internal class Algorithm
    {
        List<MyPoint> points;
        Graph graph;
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

            graph = new Graph(vertices);

            return graph;
        }
        public Graph Kruskal(Graph graph)
        {
            Graph ACM = new Graph(graph);
            graph.edges.Sort();
          
            foreach(Edge edge in graph.edges)
            {
                if (graph.vertices.Count - 1 == ACM.edges.Count)
                    break;
                ACM.AddEdge(edge);
                if (ACM.IsCycle())
                    ACM.RemoveEdge(edge);
            }

            return ACM;
        }

    }
}
