using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGui;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace Project1
{
    class Enemy : Game1
    {
        private Vector2 position;
        protected int health;
        protected int speed;
        protected int radius;

        protected int state;

        public static List<Enemy> enemies = new List<Enemy>();
        private float distanceToPlayer;

        public int Health
        {
            get { return health; }
            set { health = value; }

        }

        public Vector2 Position
        {
            get { return position; }
        }

        public int Radius
        {
            get { return radius; }
        }

        public Enemy(Vector2 newPos)
        {
            position = newPos;
        }


        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            Vector2 moveDir = playerPos - position;
            moveDir.Normalize();
            //position += moveDir * speed * dt;
            distanceToPlayer = 0;
            int state = 0;

            if (state == 0)
            {
                // Everything the enemy does during "idle"
                if (distanceToPlayer < 600)
                {
                    state = 1;
                }
            }
            else if (state == 1)
            {
                // Everything the enemy does during "following"
                position += moveDir * speed * dt; // move enemy towards player
            }



        }
        public void Draw(GameTime gametime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(PinkTexture, Pink, Color.White);
            _spriteBatch.End();
        }
    }


    class Pink : Enemy
    {
        public Pink(Vector2 newPos, Texture2D texture2D) : base(newPos)
        {
            speed = 160;
            radius = 42;
            health = 3;
            texture2D = Content.Load<Texture2D>("pinkghost");

            //state = 0;
        }
    }

    class Eye : Enemy
    {
        public Eye(Vector2 newPos) : base(newPos)
        {
            speed = 80;
            radius = 45;
            health = 5;

            //state = 0;
        }

    }
}

