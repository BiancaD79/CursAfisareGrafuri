using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafComplet
{
    internal class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        int[,] adjMatrix;

        public Graph(List<Vertex> vertices) 
        { 
            this.vertices = vertices;
            edges = new List<Edge>();
            Complete();
        }
        public void Draw(Graphics handler)
        {
            foreach (Vertex vertex in vertices)
                vertex.Draw(handler);
            foreach (Edge edge in edges)
                edge.Draw(handler);
        }

        public void Complete()
        {
            adjMatrix = new int[vertices.Count,vertices.Count];

            for (int i = 0; i < vertices.Count - 1; i++)
            {
                for (int j = i+1; j < vertices.Count; j++)
                {
                    edges.Add(new Edge(vertices[i], vertices[j]));
                    adjMatrix[i, j] = 1;
                    adjMatrix[j, i] = 1;
                }
            }
        }

        bool IsCycleUtils(int start, bool[] visited, int parent)
        {
            visited[start] = true;

            //Afisam indicele

            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                if (adjMatrix[start, i] == 1)
                    if (!visited[i])
                        IsCycleUtils(i, visited, start);
                    else
                        if (parent != start)
                            return true;
            }
            return false;
        }

        bool IsCycle(int start)
        {
            bool[] visited = new bool[adjMatrix.GetLength(0)];

            return IsCycleUtils(start, visited, -1);
        }
    }
}
