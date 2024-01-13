using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1
{
    public abstract class Movement
    {
        public abstract void Move(Sprite ghost);
        public List<Microsoft.Xna.Framework.Rectangle> _walls;
        public void Walls()
        {
            _walls = new List<Microsoft.Xna.Framework.Rectangle>();
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(0, 80, 80, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(0, 400, 80, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(164, 0, 40, 112));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(164, 112, 144, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(352, 0, 40, 280));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(598, 0, 40, 160));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(486, 120, 112, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(176, 400, 20, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(196, 400, 80, 20));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(256, 320, 20, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(276, 320, 60, 20));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(296, 450, 80, 30));
            //Wall13 = new Rectangle(296, 420, 40, 20);
            _walls.Add(new Microsoft.Xna.Framework. Rectangle(416, 400, 40, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(456, 440, 136, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(552, 400, 40, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(477, 320, 64, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(656, 304, 144, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(760, 344, 40, 140));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(88, 184, 40, 148));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(192, 208, 96, 60));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(432, 36, 120, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(432, 224, 240, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(648, 384, 60, 52));
        }
    }
}
