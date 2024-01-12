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
            if (Target is null) return;

            var dir = Target.Position - ghost.Position;

            if (dir.Length() > 4)
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            Walls();
            Vector2 OldPosition = ghost.Position;

            System.Collections.IList list = _walls;
            for (int i = 0; i < list.Count; i++)
            {
                Rectangle rectangle = (Rectangle)list[i];
                if (rectangle.Contains(ghost.Position))
                {
                    ghost.Position = OldPosition;
                }
            }
        }
    }
}
