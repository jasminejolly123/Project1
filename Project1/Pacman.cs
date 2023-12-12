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
    public class Pacman : Sprite
    {
        public Vector2 Direction { get; set; }

        public Pacman(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
        }

        public void Update()
        {
            Direction = InputManager.Direction;

            if (Direction != Vector2.Zero )
            {
                Direction = Vector2.Normalize(Direction);
                Position += Direction * Speed * Globals.TotalSeconds;
            }
            Move(new Vector2(0, 0));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            spriteBatch.Draw(Texture, rect, Color.White);
        }

        public void Move(Vector2 pos)
        {
            var keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                pos.Y = pos.Y - 5;
                Position = new Vector2(Position.X, Position.Y - 5);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pos.Y = pos.Y + 5;
                Position = new Vector2(Position.X, Position.Y + 5);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pos.X = pos.X - 5;
                Position = new Vector2(Position.X - 5, Position.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position = new Vector2(Position.X + 5, Position.Y);
                pos.X = pos.X + 5;
            }

        }

    }
}
