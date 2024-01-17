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
        public GameManager _gameManager;
        public Sprite _sprite;
        public Ghost _ghost;
        public SpriteBatch _spriteBatch;
        private Texture2D _pacman;
        public Vector2 _pacmanposition;
        public Vector2 _blockposition;
        Texture2D coverUp;
        public Texture2D PacmanTexture, WallTexture, PinkTexture, RedTexture, BlueTexture, OrangeTexture;
        public Pacman _Pacman;
        private List<Rectangle> _walls;
        public Vector2 Position, Direction, Acceleration;
        public float Speed;
        private readonly List<Sprite> _ghosts = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = Content;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pacman = Content.Load<Texture2D>("R");
            _pacmanposition = Vector2.Zero;

            PacmanTexture = Content.Load<Texture2D>("R");
            WallTexture = Content.Load<Texture2D>("dirt");
            PinkTexture = Content.Load<Texture2D>("pink");
            BlueTexture = Content.Load<Texture2D>("blue");
            OrangeTexture = Content.Load<Texture2D>("orangeghost");
            RedTexture = Content.Load<Texture2D>("redghost");
            Speed = 2;
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


            _ghost = new Ghost(Content.Load<Texture2D>("orangeghost"), new Vector2(0));
            _gameManager = new GameManager();
            _Pacman = new Pacman(Content.Load<Texture2D>("R"), new Vector2(0));

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            var ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape)) Exit();


            Acceleration = Vector2.Zero;


            Acceleration *= Speed;

            Acceleration = Acceleration - Direction * 0.54f;

            Direction += Acceleration;

            Position += Direction;

            base.Update(gameTime);

            _gameManager.Update();
            _Pacman.Update();

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.Update(gameTime);
            _spriteBatch.Begin();


            foreach (Rectangle wall in _walls)
            {
                _spriteBatch.Draw(WallTexture, wall, Color.BlueViolet);
            }

            _gameManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

