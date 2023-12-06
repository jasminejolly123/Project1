using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
