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
    public class Follow : Movement
    {
        public Pacman Target { get; set; }

        public override void Move(Sprite ghost)
        {
            Walls();
            Vector2 OldPosition = ghost.Position;

            Main();

            if (Target is null) return;

            var dir = Target.Position - ghost.Position;

            if (dir.Length() > 4)
            {
                dir.Normalize();
                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
            }

            foreach (Rectangle rectangle in _walls)
            {
                if (rectangle.Contains(ghost.Position))
                {
                    ghost.Position = OldPosition;
                }
            }
        }
    }
}

//namespace Project1
//{
//    public class Follow : Movement
//    {
//        public Pacman Target { get; set; }
//        private Red currentState = Red.Chase;
//        public SpriteBatch _spriteBatch;
//        public Texture2D _texture;
//        private Rectangle endScreen;

//        public enum Red
//        {
//            Still,
//            Chase
//        }

//        public override void Move(Sprite ghost)
//        {
//            switch (currentState)
//            {
//                case Red.Still:
//                    UpdateStill();
//                    break;
//                case Red.Chase:
//                    UpdateChase(ghost);
//                    break;

//                default: break;
//            }
//        }

//        public void UpdateChase(Sprite ghost)
//        {
//            Walls();
//            Vector2 OldPosition = ghost.Position;

//            Main();

//            //if (Target.Position == ghost.Position)
//            //{
//            //    currentState = Red.Still;
//            //}

//            var dir = Target.Position - ghost.Position;

//            if (dir.Length() > 4)
//            {
//                dir.Normalize();
//                ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
//            }

//            foreach (Rectangle rectangle in _walls)
//            {
//                if (rectangle.Contains(ghost.Position))
//                {
//                    ghost.Position = OldPosition;
//                }
//            }
//        }

//        public void UpdateStill()
//        {
//            endScreen = new Rectangle(164, 112, 144, 40);
//            _spriteBatch.Draw(_texture, endScreen, Color.Gray);
//        }

//    }
//}

