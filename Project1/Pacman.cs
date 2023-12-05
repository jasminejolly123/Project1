using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Pacman : Sprite
    {
        public Vector2 Direction { get; set; }

        public Pacman(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
        }

        public void Update()
        {
            Direction = InputManager.Direction;

            if (Direction != Vector2.Zero )
            {
                Direction = Vector2.Normalize(Direction);
                Position += Direction * Speed * Globals.TotalSeconds;
            }
        }
    }
}
