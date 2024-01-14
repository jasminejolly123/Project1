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
        //public Pacman Target { get; set; }

        //public override void Move(Sprite ghost)
        //{
        //    if (Target is null) return;

        //    Random rnd = new Random();
        //    int posy = rnd.Next(0, 400);
        //    int posx = rnd.Next(0, 800);

        //    Vector2 pos = new Vector2(posx, posy);

        //    var dir = pos - ghost.Position;

        //    dir.Normalize();
        //    ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;

        //    if (pos == ghost.Position)
        //    {
        //        Move(ghost);
        //    }
        //}

        public Pacman Target { get; set; }



        private System.Random rng = new System.Random();



        public override void Move(Sprite ghost)

        {

            Walls();
            Vector2 OldPosition = ghost.Position;

            if (Target is null) return;



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
