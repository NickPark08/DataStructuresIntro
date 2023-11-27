using DataStructures;

using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualizer
{
    class Square <T>
    {
        public Color Color;
        public Rectangle Hitbox;
        public WDVertex<T> Vertex;
        public bool isClicked = false;

        public Square(Rectangle hb, Color col, WDVertex<T> vertex)
        {
            Hitbox = hb;
            Color = col;
            Vertex = vertex;
        }
    }
}
