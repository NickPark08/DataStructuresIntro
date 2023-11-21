using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualizer
{
    class Square
    {
        public Color Color;
        public Rectangle Hitbox;
        public bool isClicked = false;

        public Square(Rectangle hb, Color col)
        {
            Hitbox = hb;
            Color = col;
        }
    }
}
