using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS
{
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        public int[,] adj;


        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        public void Load(string data)
        {
            TextReader reader = new StreamReader(data);
            int n = int.Parse(reader.ReadLine());
            adj = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                Vertex local = new Vertex();
                local.idx = i;
                vertices.Add(local);
            }
            string buffer = "";
            while ((buffer = reader.ReadLine()) != null)
            {
                int x = int.Parse(buffer.Split(' ')[0]);
                int y = int.Parse(buffer.Split(' ')[1]);
                int z = int.Parse(buffer.Split(' ')[2]);

                adj[x, y] = z;
                adj[y, x] = z;

                edges.Add(new Edge(buffer, vertices));
            }
        }

        public void Draw(Graphics handler)
        {
            foreach (Edge edge in edges)
                edge.Draw(handler);
            foreach (Vertex vertex in vertices)
                vertex.Draw(handler);
        }

        public void Dispersion(PointF center, float radius)
        {
            float alpha = (float)(Math.PI * 2) / vertices.Count;
            for (int i = 0; i < vertices.Count; i++)
            {
                float x = center.X + (float)Math.Cos(i * alpha) * radius;
                float y = center.Y + (float)Math.Sin(i * alpha) * radius;
                vertices[i].location = new PointF(x, y);
            }
        }

        public List<Vertex> BFS(Vertex start)
        {
            List<Vertex> toR = new List<Vertex>();

            MyQueue<Vertex> queue = new MyQueue<Vertex>();
            bool[] visited = new bool[vertices.Count];
            visited[start.idx] = true;
            queue.Push(start);
            while (!queue.IsEmpty())
            {
                Vertex t = queue.Pop();
                toR.Add(t);
                foreach (Edge edge in edges)
                {
                    if (edge.start == t || edge.end == t)
                    {
                        Vertex x;
                        if (edge.start == t)
                            x = edge.end;
                        else x = edge.start;

                        if (!visited[x.idx])
                        {
                            queue.Push(x);
                            visited[x.idx] = true;
                        }
                    }
                }
            }
            return toR;
        }

        public List<Vertex> DFS(Vertex start)
        {
            List<Vertex> toR = new List<Vertex>();

            MyStack<Vertex> stack = new MyStack<Vertex>();
            bool[] visited = new bool[vertices.Count];
            visited[start.idx] = true;
            stack.Push(start);
            while (!stack.IsEmpty())
            {
                Vertex t = stack.Pop();
                toR.Add(t);
                foreach (Edge edge in edges)
                {
                    if (edge.start == t || edge.end == t)
                    {
                        Vertex x;
                        if (edge.start == t)
                            x = edge.end;
                        else x = edge.start;

                        if (!visited[x.idx])
                        {
                            stack.Push(x);
                            visited[x.idx] = true;
                        }
                    }
                }
            }
            return toR;
        }

        public List<Vertex> DFS_Rec(Vertex start)
        {
            //List<Vertex> toR = new List<Vertex>();

            bool[] visited = new bool[vertices.Count];
            values = new List<Vertex>();

            DFS_Rec_Utils(start, visited);

            return values;
        }

        public List<Vertex> values;

        private void DFS_Rec_Utils(Vertex start, bool[] visited)
        {
            visited[start.idx] = true;
            values.Add(start);
            foreach (Edge edge in edges)
            {
                if (edge.start == start || edge.end == start)
                {
                    Vertex newVertex;
                    if (edge.start == start)
                        newVertex = edge.end;
                    else newVertex = edge.start;

                    if (!visited[newVertex.idx])
                    {
                        DFS_Rec_Utils(newVertex, visited);
                    }
                }
            }
        }


    }
}
