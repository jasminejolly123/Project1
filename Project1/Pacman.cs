﻿using System;
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
        private List<Rectangle> _walls;

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

            Walls();

            foreach (Rectangle rectangle in _walls)
            {
                if (Position.X < rectangle.Right && Position.Y > (rectangle.Top) && Position.Y < rectangle.Bottom)
                {
                    Position = new Vector2(Position.X + 5, Position.Y);
                }

                if (Position.X > rectangle.Left && Position.Y > (rectangle.Top) && Position.Y < rectangle.Bottom)
                {
                    Position = new Vector2(Position.X - 5, Position.Y);
                }

                if (Position.Y > rectangle.Bottom && Position.X < rectangle.Right && Position.X > rectangle.Left)
                {
                    Position = new Vector2(Position.X, Position.Y - 5);
                }

                if (Position.Y < rectangle.Top && Position.X < rectangle.Right && Position.X > rectangle.Left)
                {
                    Position = new Vector2(Position.X, Position.Y + 5);
                }
            }

        }

        public void Walls()
        {
            _walls = new List<Rectangle>();
            _walls.Add(new Rectangle(0, 80, 80, 40));
            _walls.Add(new Rectangle(0, 400, 80, 80));
            _walls.Add(new Rectangle(164, 0, 40, 112));
            _walls.Add(new Rectangle(164, 112, 144, 40));
            _walls.Add(new Rectangle(352, 0, 40, 280));
            _walls.Add(new Rectangle(598, 0, 40, 160));
            _walls.Add(new Rectangle(486, 120, 112, 40));
            _walls.Add(new Rectangle(176, 400, 20, 80));
            _walls.Add(new Rectangle(196, 400, 80, 20));
            _walls.Add(new Rectangle(256, 320, 20, 80));
            _walls.Add(new Rectangle(276, 320, 60, 20));
            _walls.Add(new Rectangle(296, 450, 80, 30));
            //Wall13 = new Rectangle(296, 420, 40, 20);
            _walls.Add(new Rectangle(416, 400, 40, 80));
            _walls.Add(new Rectangle(456, 440, 136, 40));
            _walls.Add(new Rectangle(552, 400, 40, 80));
            _walls.Add(new Rectangle(477, 320, 64, 40));
            _walls.Add(new Rectangle(656, 304, 144, 40));
            _walls.Add(new Rectangle(760, 344, 40, 140));
            _walls.Add(new Rectangle(88, 184, 40, 148));
            _walls.Add(new Rectangle(192, 208, 96, 60));
            _walls.Add(new Rectangle(432, 36, 120, 40));
            _walls.Add(new Rectangle(432, 224, 240, 40));
            _walls.Add(new Rectangle(648, 384, 60, 52));
        }

    }
}
