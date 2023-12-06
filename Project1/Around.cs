using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Around : Movement
    {
        private readonly List<Vector2> _path = new();
        private int _current;

        public void AddPoint(Vector2 point)
        {
            _path.Add(point);
        }

        public override void Move(Sprite ghost)
        {
            if (_path.Count < 1) return;

            var dir = _path[_current] - ghost.Position;
            
            if (dir.Length() > 4)
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }
            else
            {
                _current = (_current + 1) % _path.Count;
            }
        }
    }
}
