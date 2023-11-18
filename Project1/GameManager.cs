using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GameManager : Game1
    {
        private readonly List<Ghost> _ghosts = new();
        public GameManager()
        { 
            var ai = new Around();
            ai.AddPoint(new(100, 100));
            ai.AddPoint(new(400, 100));
            ai.AddPoint(new(400, 400));
            ai.AddPoint(new(100, 400));

            _ghosts.Add(PinkTexture, new(50, 50)
            {
                MoveAI = ai
            });
        }
    }
}
