using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1
{
    internal class Random : Movement
    {
        public Pacman Target { get; set; }

        public override void Move(Sprite ghost)
        {
            if (Target is null) return;

            Random rnd = new Random();
            //int pos = rnd.next(0, 400);

            var dir = Target.Position - ghost.Position;

            if (dir.Length() > 4)
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }
        }
    }
}
