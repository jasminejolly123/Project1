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
    public class Around : Movement
    {
        private readonly List<Vector2> _path = new();
        private int _current;
        public Pacman Target { get; set; }
        public List<Microsoft.Xna.Framework.Vector2> _points;

        public void AddPoint(Vector2 point)
        {
            _path.Add(point);
        }

        public override void Move(Sprite ghost)
        {
            Points();
            Walls();

            Vector2 OldPosition = ghost.Position;

            if (Target is null) return;

            //while (ghost.Position != Target.Position)
            //{
            //    foreach (Vector2 point in _points)
            //    {
            //        var dir = Target.Position - point;

            //        if (dir.Length() > 4)
            //        {
            //            dir.Normalize();
            //            ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            //        }
            //    }
            //}



            foreach (Rectangle rectangle in _walls)
            {
                if (rectangle.Contains(ghost.Position))
                {
                    ghost.Position = OldPosition;
                }
            }
        }

        public void Points()
        {
            _points = new List<Microsoft.Xna.Framework.Vector2>();
            _points.Add(new Microsoft.Xna.Framework.Vector2(658, 235));
            _points.Add(new Microsoft.Xna.Framework.Vector2(517, 235));
            _points.Add(new Microsoft.Xna.Framework.Vector2(517, 315));
            _points.Add(new Microsoft.Xna.Framework.Vector2(306, 315));
            _points.Add(new Microsoft.Xna.Framework.Vector2(306, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(141, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(141, 155));
            _points.Add(new Microsoft.Xna.Framework.Vector2(263, 155));
            _points.Add(new Microsoft.Xna.Framework.Vector2(263, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(352, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(352, 164));
            _points.Add(new Microsoft.Xna.Framework.Vector2(658, 164));
        }
    }
}

