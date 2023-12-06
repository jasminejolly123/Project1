using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Sprite
    {
        //public Movement MoveAI { get; set; }
        public float Speed { get; set; }
        public Vector2 Position { get; set; }
        public Around MoveAI { get; internal set; }

        protected readonly Texture2D Texture;
        protected readonly Vector2 origin;

        public Sprite(Texture2D tex, Vector2 pos)
        {
            Texture = tex;
            Position = pos;
            Speed = 250;
            origin = new(tex.Width / 2, tex.Height / 2);
        }
        //public void Update()
        //{
        //    MoveAI.Move(this);
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            Globals.spritebatch.Draw(Texture, Position, null, Color.White, 0, origin, 1, SpriteEffects.None, 1);
            //Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            //spriteBatch.Draw(Texture, rect, Color.White);
        }
    }
}
