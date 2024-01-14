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
    public class Follow : Movement
    {
        public Pacman Target { get; set; }

        public override void Move(Sprite ghost)
        {
            Walls();
            Vector2 OldPosition = ghost.Position;

            if (Target is null) return;

            var dir = Target.Position - ghost.Position;

            if (dir.Length() > 4)
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            foreach (Rectangle rectangle in _walls)
            {
                if (rectangle.Contains(ghost.Position))
                {
                    ghost.Position = OldPosition;
                }
            }
        }
    }
}
