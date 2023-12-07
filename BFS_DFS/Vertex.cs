using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS
{
    public class Vertex
    {
        public int idx;
        public PointF location;

        public void Draw(Graphics handler)
        {
            handler.DrawString(idx.ToString(), new Font("Arial", 20), Brushes.Black, location);
            handler.DrawEllipse(Pens.Black, location.X - 5, location.Y - 5, 11, 11);
        }
    }
}
