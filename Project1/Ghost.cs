using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Ghost
    {
        public Movement MoveAI { get; set; }
        public float Speed;
        public Vector2 Position;
        public Texture2D Texture;

        public Ghost(Texture2D tex, Vector2 pos)
        {
            Texture = tex;
            Position = pos;
            Speed = 250;
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
