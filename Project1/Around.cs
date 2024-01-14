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

        public void AddPoint(Vector2 point)
        {
            _path.Add(point);
        }

        public override void Move(Sprite ghost)
        {
            Walls();
            Vector2 OldPosition = ghost.Position;

            if (_path.Count < 1) return;

            var dir = _path[_current] - ghost.Position;
            var dir2 = Target.Position - ghost.Position;
            
            if (dir.Length() > dir2.Length())
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }
            else
            {
                _current = (_current + 1) % _path.Count;
            }


            //System.Collections.IList list = _walls;
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Rectangle rectangle = (Rectangle)list[i];
            //    if (rectangle.Contains(ghost.Position))
            //    {
            //        ghost.Position = OldPosition;
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
    }
}
