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
    class Enemy 
    {
        private Vector2 position;
        protected int speed;
        protected int radius;

        protected int state;

        public static List<Enemy> enemies = new List<Enemy>();
        private float distanceToPlayer;


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
            distanceToPlayer = 0;
            int state = 0;

            if (state == 0)
            {
                if (distanceToPlayer < 600)
                {
                    state = 1;
                }
            }
            else if (state == 1)
            {
                position += moveDir * speed * dt;
            }



        }
        public void Draw(SpriteBatch _spritebatch)
        {
            
            _spritebatch.Draw(Globals.content.Load<Texture2D>("pinkghost"), new Vector2(750, 20), Color.White);
            
        }
    }


    class Pink : Enemy
    {
        public Pink(Vector2 newPos, Texture2D texture2D) : base(newPos)
        {
            speed = 160;
            radius = 42;
            texture2D = Globals.content.Load<Texture2D>("pinkghost");
        }
    }

    class Orange : Enemy
    {
        public Orange(Vector2 newPos, Texture2D texture2D) : base(newPos)
        {
            speed = 160;
            radius = 42;
            texture2D = Globals.content.Load<Texture2D>("orange ghost");
        }

    }

    class Blue : Enemy
    {
        public Blue(Vector2 newPos, Texture2D texture2D) : base(newPos)
        {
            speed = 160;
            radius = 42;
            texture2D = Globals.content.Load<Texture2D>("blue ghost");
        }

    }

    class Red : Enemy
    {
        public Red(Vector2 newPos, Texture2D texture2D) : base(newPos)
        {
            speed = 160;
            radius = 42;
            texture2D = Globals.content.Load<Texture2D>("red ghost");
        }

    }
}

