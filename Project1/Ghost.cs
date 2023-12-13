using Microsoft.Xna.Framework.Graphics;
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
    public class Ghost : Sprite
    {
        public Movement MoveAI { get; set; }

        public Ghost(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 200;
        }

        public void Update()
        {
            MoveAI.Move(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            spriteBatch.Draw(Texture, rect, Color.White);
        }
    }
}
