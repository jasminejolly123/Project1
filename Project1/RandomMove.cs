using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Project1
{
    internal class RandomMove : Movement
    {
        public Pacman Target { get; set; }
        private System.Random rng = new System.Random();
        private Orange currentState = Orange.RandomMove;
        public SpriteBatch _spriteBatch;
        public Texture2D _texture;
        private Rectangle endScreen;

        public enum Orange
        {
            Still,
            Chase,
            RandomMove
        }

        public override void Move(Sprite ghost)
        {
            switch (currentState)
            {
                case Orange.Chase:
                    UpdateChase(ghost);
                    break;
                case Orange.RandomMove:
                    UpdateRandomMove(ghost);
                    break;
                default:
                    break;
            }
        }

        private void UpdateRandomMove(Sprite ghost)
        {
            Vector2 OldPosition = ghost.Position;
            Walls();

            float time = 5.0f;

            if (Globals.TotalSeconds > time)
            {
                int numX = rng.Next(0, 800);
                int numY = rng.Next(0, 400);
                ghost.Position = new Vector2(numX, numY);
                time = time + 5;
            }

            foreach (Rectangle rectangle in _walls)
            {
                if (rectangle.Contains(ghost.Position))
                {
                    ghost.Position = OldPosition;
                    return;
                }
            }

            var dir = Target.Position - ghost.Position;
            if (dir.Length() < 100)
            {
                currentState = Orange.Chase;
            }
        }

        private void UpdateChase(Sprite ghost)
        {
            var dir = Target.Position - ghost.Position;
            dir.Normalize();
            ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;

            if (dir.Length() < 100)
            {
                currentState = Orange.RandomMove;

            }

        }
    }
}