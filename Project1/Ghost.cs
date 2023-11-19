using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Ghost : Game1
    {
        public Movement MoveAI { get; set; }
        public Ghost(Texture2D tex, Vector2 pos)
        {
            Speed = 250;
        }
        public void Update()
        {
            MoveAI.Move(this);
        }
    }
}
