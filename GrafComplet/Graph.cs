using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public Graph(Graph graph)
        {
            this.vertices = graph.vertices;
            this.adjMatrix = graph.adjMatrix;
            edges = new List<Edge>();
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

        bool IsCycleUtils(int crt_vertice, bool[] visited, int parent)
        {
            visited[crt_vertice] = true;

            //Afisam indicele

            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                if (adjMatrix[crt_vertice, i] != 0)
                    if (!visited[i])
                    {
                        if (IsCycleUtils(i, visited, crt_vertice))
                            return true;
                    }
                    else
                        if (i != parent)
                           return true;
            }
            return false;
        }

        public bool IsCycle()
        {
            bool[] visited = new bool[adjMatrix.GetLength(0)];
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                visited[i] = false;
            }


            for (int i = 0; i < vertices.Count; i++)
            {
                if (!visited[i])
                    if(IsCycleUtils(i, visited, -1))
                        return true;
            }

            return false;
        }

        internal void AddEdge(Edge edge)
        {
            this.edges.Add(edge);
        }

        internal void RemoveEdge(Edge edge)
        {
            edges.Remove(edge);
        }
    }
}
