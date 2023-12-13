using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Distance : Movement
    {
        public Pacman Target { get; set; }

        public override void Move(Sprite ghost)
        {
            if (Target == null) return;

            var dir = Target.Position - ghost.Position;
            var length = dir.Length();

            var keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                dir.Normalize();
                ghost.Position = new Vector2(ghost.Position.X, ghost.Position.Y - 5);
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                dir.Normalize();
                ghost.Position = new Vector2(ghost.Position.X, ghost.Position.Y + 5);
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                dir.Normalize();
                ghost.Position = new Vector2(ghost.Position.X - 5, ghost.Position.Y);
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                dir.Normalize();
                ghost.Position = new Vector2(ghost.Position.X + 5, ghost.Position.Y);
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            else
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }
        }
    }
}
