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
    internal class RandomMove : Movement
    {
        public Pacman Target { get; set; }
        private System.Random rng = new System.Random();
        public override void Move(Sprite ghost)
        {
            Walls();
            Vector2 OldPosition = ghost.Position;
            
            if (Target is null) return;

            Main();

            //int num = rng.Next(0, 400);
            //int num2 = rng.Next(0, 800);
            //Vector2 pos = new Vector2(num2, num);

            //float dis1 = (ghost.Position.X - Target.Position.X) * (ghost.Position.X - Target.Position.X);
            //float dis2 = (ghost.Position.Y - Target.Position.Y) * (ghost.Position.Y - Target.Position.Y);
            //float dis3 = dis1 + dis2;
            //float dis4 = (float)Math.Sqrt(dis3);

            //float dis5 = (ghost.Position.X - pos.X) * (ghost.Position.X - pos.X);
            //float dis6 = (ghost.Position.Y - pos.Y) * (ghost.Position.Y - pos.Y);
            //float dis7 = dis5 + dis6;
            //float dis8 = (float)Math.Sqrt(dis7);
            //var dir1 = Target.Position - ghost.Position;
            //var dir2 = pos - ghost.Position;




            //if (dir1.Length() > 4 && dis8 < dis4)
            //{
            //    dir1.Normalize();
            //    ghost.Position += dir2 * ghost.Speed * Globals.TotalSeconds;
            //}
            //else
            //{
            //    dir2.Normalize();
            //    ghost.Position += dir1 * ghost.Speed * Globals.TotalSeconds;
            //}

            int pos = rng.Next(0, 400);

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

