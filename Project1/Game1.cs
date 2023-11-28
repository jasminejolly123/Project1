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
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private Texture2D _pacman;
        public Vector2 _pacmanposition;
        public Vector2 _blockposition;
        Texture2D coverUp;
        public Texture2D PacmanTexture, WallTexture, PinkTexture, RedTexture, BlueTexture, OrangeTexture;
        public Rectangle Pacman, Red, Pink, Blue, Orange;
        private List<Rectangle> _walls;
        //private Rectangle Wall1;
        //private Rectangle Wall2;
        //private Rectangle Wall3;
        //private Rectangle Wall4;
        //private Rectangle Wall5;
        //private Rectangle Wall6;
        //private Rectangle Wall7;
        //private Rectangle Wall8;
        //private Rectangle Wall9;
        //private Rectangle Wall10;
        //private Rectangle Wall11;
        //private Rectangle Wall12;
        //private Rectangle Wall13;
        //private Rectangle Wall14;
        //private Rectangle Wall15;
        //private Rectangle Wall16;
        //private Rectangle Wall17;
        //private Rectangle Wall18;
        //private Rectangle Wall19;
        //private Rectangle Wall20;
        //private Rectangle Wall21;
        //private Rectangle Wall22;
        //private Rectangle Wall23;
        //private Rectangle Wall24;
        public Vector2 Position, Direction, Acceleration;
        public float Speed;
        private readonly List<Ghost> _ghosts = new();


        //private ShapeBatcher _shapeBatcher;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pacman = Content.Load<Texture2D>("R");
            _pacmanposition = Vector2.Zero;

            PacmanTexture = Content.Load<Texture2D>("R");
            WallTexture = Content.Load<Texture2D>("dirt");
            PinkTexture = Content.Load<Texture2D>("pinkghost");
            BlueTexture = Content.Load<Texture2D>("blue ghost");
            OrangeTexture = Content.Load<Texture2D>("orange ghost");
            RedTexture = Content.Load<Texture2D>("red ghost");
            Speed = 2;
            Pacman = new Rectangle(0, 0, 30, 30);
            Pink = new Rectangle(760, 0, 30, 30);
            Red = new Rectangle(760, 0, 30, 30);
            Blue = new Rectangle(760, 0, 30, 30);
            Orange = new Rectangle(760, 0, 30, 30);
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

            

                var ghosttexture = Content.Load<Texture2D>("pinkghost");

                var ai = new Around();
                ai.AddPoint(new(100, 100));
                ai.AddPoint(new(400, 100));
                ai.AddPoint(new(400, 400));
                ai.AddPoint(new(100, 400));

                _ghosts.Add(new(ghosttexture, new(750, 50))
                {
                    MoveAI = ai
                });
            
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            var ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape)) Exit();

            //Get the Direction Vector from the keyboard

            Acceleration = Vector2.Zero;
            //if (ks.IsKeyDown(Keys.Left)) Acceleration.X = -1;
            //else if (ks.IsKeyDown(Keys.Right)) Acceleration.X = 1;
            //if (ks.IsKeyDown(Keys.Up)) Acceleration.Y = -1;
            //else if (ks.IsKeyDown(Keys.Down)) Acceleration.Y = 1;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _pacmanposition.Y = _pacmanposition.Y - 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _pacmanposition.Y = _pacmanposition.Y + 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _pacmanposition.X = _pacmanposition.X - 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _pacmanposition.X = _pacmanposition.X + 5;
            }

            Acceleration *= Speed;

            Acceleration = Acceleration - Direction * 0.54f;//Velocity = Acceleration - Friction

            Direction += Acceleration;

            Position += Direction;

            //if (Wall.Intersects(Pacman))
            
                //Intersection is true. Now add the bouncing logic



                foreach (Rectangle rectangle in _walls)
                {
                    if (_pacmanposition.X < rectangle.Right && _pacmanposition.Y > (rectangle.Top) && _pacmanposition.Y < rectangle.Bottom)
                    {
                        _pacmanposition.X = _pacmanposition.X + 5;
                    }

                    if (_pacmanposition.X > rectangle.Left && _pacmanposition.Y > (rectangle.Top) && _pacmanposition.Y < rectangle.Bottom)
                    {
                        _pacmanposition.X = _pacmanposition.X - 5;
                    }

                    if (_pacmanposition.Y == rectangle.Bottom && _pacmanposition.X < rectangle.Right && _pacmanposition.X > -5)
                    {
                        _pacmanposition.Y = _pacmanposition.Y - 5;
                    }

                    if (_pacmanposition.Y == rectangle.Top && _pacmanposition.X < rectangle.Right && _pacmanposition.X > -5)
                    {
                        _pacmanposition.Y = _pacmanposition.Y + 5;
                    }
                }
                base.Update(gameTime);

                foreach (var ghost in _ghosts)
                {
                    ghost.Update();
                }



            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //// TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_pacman, _pacmanposition, Color.White);
            //_spriteBatch.Draw(WallTexture, Wall1, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall2, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall3, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall4, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall5, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall6, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall7, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall8, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall9, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall10, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall11, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall12, Color.BlueViolet);
            ////_spriteBatch.Draw(WallTexture, Wall13, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall14, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall15, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall16, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall17, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall18, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall19, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall20, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall21, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall22, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall23, Color.BlueViolet);
            //_spriteBatch.Draw(WallTexture, Wall24, Color.BlueViolet);
            //_spriteBatch.Draw(PacmanTexture, Pacman, Color.White);

            foreach (Rectangle wall in _walls)
            {
                _spriteBatch.Draw(WallTexture, wall, Color.BlueViolet);
            }

            foreach (var ghost in _ghosts)
            {
                ghost.Draw(_spriteBatch);
            }
            ////_spriteBatch.Draw(PinkTexture, Pink, Color.White);
            ////_spriteBatch.Draw(RedTexture, Red, Color.White);
            ////_spriteBatch.Draw(BlueTexture, Blue, Color.White);
            ////_spriteBatch.Draw(OrangeTexture, Orange, Color.White);

            _spriteBatch.End();

            //_shapeBatcher.DrawRectangle(50, 30, Color.White);
            base.Draw(gameTime);
        }
    }
}