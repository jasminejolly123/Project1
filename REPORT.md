## Artificial Intelligence for Games
For the “Epic Boss Battle” I decided to make Pac-Man where each Pac-Man ghost has a specific AI steering behaviours, and Pac-Man is controlled by the user. I designed my own map for the game with walls for Pac-Man and the ghosts to maneuver around.
### My Code
#### Sprite
```cs
namespace Project1
{
    public class Sprite
    {
        public float Speed { get; set; }
        public Vector2 Position { get; set; }
        public Around MoveAI { get; internal set; }

        protected readonly Texture2D Texture;
        protected readonly Vector2 origin;

        public Sprite(Texture2D tex, Vector2 pos)
        {
            Texture = tex;
            Position = pos;
            Speed = 250;
            origin = new(tex.Width / 2, tex.Height / 2);
        }
    }
}
```
This code allows texture, position and speed to all sprites this includes Pac-Man and all the ghosts
#### Pacman
```cs
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
            Walls();
            Vector2 OldPosition = Position;
            Direction = InputManager.Direction;

            if (Direction != Vector2.Zero)
            {
                Direction = Vector2.Normalize(Direction);
                Position += Direction * Speed * Globals.TotalSeconds;
            }

            foreach (Rectangle rectangle in _walls)
            {
                if (rectangle.Contains(Position))
                {
                    Position = OldPosition;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            spriteBatch.Draw(Texture, rect, Color.White);
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
```
This creates the movement of Pac-Man uses the input manager and stops Pac-Man frm moving through walls. It also allows Pac-Man to be outputted in its texture and position.
#### ghost
```cs
namespace Project1
{
    public class Ghost : Sprite
    {
        public Movement MoveAI { get; set; }
        private List<Rectangle> _walls;

        public Ghost(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 200;
        }

        public void Update()
        {
            Walls();
            MoveAI.Move(this);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            spriteBatch.Draw(Texture, rect, Color.White);
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
```
This sets the speed for the ghosts and allows the ghosts to be drawn
#### Game Manager
```cs
namespace Project1
{
    public class GameManager 
    {
        private readonly Pacman _player;
        private readonly List<Ghost> _ghosts = new();

        public GameManager()
        {
            _player = new(Globals.content.Load<Texture2D>("R"), new(0, 0));
            var ghosttexture1 = Globals.content.Load<Texture2D>("pink");
            var ghosttexture2 = Globals.content.Load<Texture2D>("orangeghost");
            var ghosttexture3 = Globals.content.Load<Texture2D>("blue");
            var ghosttexture4 = Globals.content.Load<Texture2D>("redghost");


            _ghosts.Add(new(ghosttexture4, new(750, 50))
            {
                MoveAI = new Follow
                {
                    Target = _player
                }
            });

            _ghosts.Add(new(ghosttexture1, new(750, 50))
            {
                MoveAI = new Distance
                {
                    Target = _player
                }
            });

            _ghosts.Add(new(ghosttexture2, new(750, 50))
            {
                MoveAI = new RandomMove
                {
                    Target = _player
                }
            });

            _ghosts.Add(new(ghosttexture3, new(750, 50))
            {
                MoveAI = new Around
                {
                    Target = _player
                }
            });

        }
        public void Update()
        {
            InputManager.Update();
            _player.Update();
            foreach (var ghost in _ghosts)
            {
                ghost.Update();
            }
        }
        public void Draw(SpriteBatch _spritebatch)
        {
            _player.Draw(_spritebatch);
            foreach (var ghost in _ghosts)
            {
                ghost.Draw(_spritebatch);
            }
        }
    }
}
```
This is where all the sprites are updated and drawn. The ghosts are put into a list where they are given their texture, position and steering behaviour.
#### Globals
```cs
namespace Project1
{
    public static class Globals
    {
        public static float TotalSeconds { get; set; }
        public static ContentManager content {  get; set; }
        public static SpriteBatch spritebatch { get; set; }

        public static void Update(GameTime gameTime)
        {
            TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
```
This creates variables available to all classes
#### Input Manager
```cs
namespace Project1
{
    public static class InputManager
    {
        private static Vector2 _direction;
        public static Vector2 Direction => _direction;

        public static void Update()
        {
            var keyboardState = Keyboard.GetState();

            _direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
            if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
            if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;
        }
    }
}
```
This takes the input of the user and uses to determine the direction the user wants to travel
#### Move
```cs
namespace Project1
{
    public abstract class Movement : Dijkstra
    {
        public abstract void Move(Sprite ghost);
        public List<Microsoft.Xna.Framework.Rectangle> _walls;
        public void Walls()
        {
            _walls = new List<Microsoft.Xna.Framework.Rectangle>();
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(0, 80, 80, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(0, 400, 80, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(164, 0, 40, 112));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(164, 112, 144, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(352, 0, 40, 280));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(598, 0, 40, 160));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(486, 120, 112, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(176, 400, 20, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(196, 400, 80, 20));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(256, 320, 20, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(276, 320, 60, 20));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(296, 450, 80, 30));
            //Wall13 = new Rectangle(296, 420, 40, 20);
            _walls.Add(new Microsoft.Xna.Framework. Rectangle(416, 400, 40, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(456, 440, 136, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(552, 400, 40, 80));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(477, 320, 64, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(656, 304, 144, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(760, 344, 40, 140));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(88, 184, 40, 148));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(192, 208, 96, 60));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(432, 36, 120, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(432, 224, 240, 40));
            _walls.Add(new Microsoft.Xna.Framework.Rectangle(648, 384, 60, 52));
        }

        
    }
}
```
Movement inherits from Dijkstra so each steering behaviour can use dijkstra to get around the walls and a list of Walls is included so ghosts can be stopped from passing through them
#### Dijkstra
```cs
namespace Project1
{
    

        public class Dijkstra
        {
            static int num = 9;
            int minDistance(int[] dist,
                            bool[] sptSet)
            {
                int min = int.MaxValue, min_index = -1;

                for (int i = 0; i < num; i++)
                    if (sptSet[i] == false && dist[i] <= min)
                    {
                        min = dist[i];
                        min_index = i;
                    }

                return min_index;
            }

            void printSolution(int[] dist, int n)
            {
                Console.Write("Vertex     Distance "
                              + "from Source\n");
                for (int i = 0; i < num; i++)
                    Console.Write(i + " \t\t " + dist[i] + "\n");
            }
            void dijkstra(int[,] graph, int src)
            {
                int[] dist = new int[num]; 
                bool[] sptSet = new bool[num];

                for (int i = 0; i < num; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                }

                dist[src] = 0;

                for (int count = 0; count < num - 1; count++)
                {
                    int u = minDistance(dist, sptSet);
                    sptSet[u] = true;
                    for (int v = 0; v < num; v++)
                    {
                        if (!sptSet[v] && graph[u, v] != 0 &&
                            dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                            dist[v] = dist[u] + graph[u, v];
                    }
                }

                printSolution(dist, num);
            }

            public static void Main()
            {
                int[,] graph = new int[,] { { 0, 5, 0, 0, 0, 2, 0, 0, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 7, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 4, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 3, 0, 0, 0, 7 },
                                      { 0, 0, 0, 0, 5, 0, 6, 7, 0 } };
                Dijkstra t = new Dijkstra();
                t.dijkstra(graph, 0);
            }
        }
    }
```
This is Dijkstra's path finding algorithm, it does not work. Its supposed to take points and allows ghosts to move around the map avoiding the walls. My ghosts don't respond to this at all.
#### Game1
```cs
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
```
#### Around
```cs
namespace Project1
{
    public class Around : Movement
    {
        private readonly List<Vector2> _path = new();
        private int _current;
        public Pacman Target { get; set; }
        public List<Microsoft.Xna.Framework.Vector2> _points;

        public override void Move(Sprite ghost)
        {
            Points();
            Vector2 OldPosition = ghost.Position;

            if (Target is null) return;

            while (ghost.Position != Target.Position)
            {
                foreach (Vector2 point in _points)
                {
                    var dir = Target.Position - point;

                    if (dir.Length() > 4)
                    {
                        dir.Normalize();
                        ghost.Position += dir * ghost.Speed * Globals.TotalSeconds;
                    }
                }
            }


            
            foreach (Rectangle rectangle in _walls)
            {
                if (rectangle.Contains(ghost.Position))
                {
                    ghost.Position = OldPosition;
                }
            }
        }

        public void Points()
        {
            _points = new List<Microsoft.Xna.Framework.Vector2>();
            _points.Add(new Microsoft.Xna.Framework.Vector2(658, 235));
            _points.Add(new Microsoft.Xna.Framework.Vector2(517, 235));
            _points.Add(new Microsoft.Xna.Framework.Vector2(517, 315));
            _points.Add(new Microsoft.Xna.Framework.Vector2(306, 315));
            _points.Add(new Microsoft.Xna.Framework.Vector2(306, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(141, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(141, 155));
            _points.Add(new Microsoft.Xna.Framework.Vector2(263, 155));
            _points.Add(new Microsoft.Xna.Framework.Vector2(263, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(352, 249));
            _points.Add(new Microsoft.Xna.Framework.Vector2(352, 164));
            _points.Add(new Microsoft.Xna.Framework.Vector2(658, 164));
        }
    }
}
```
This takes the blue ghost around the map through set points. When running this code on my laptop, with the while loop included the code does not run so in my code i've left it commented out so the code can run. I don't know if this is a problem with my laptop or my code but either way I can't manage to fix it.
#### Distance
```cs
namespace Project1
{
    public class Distance : Movement
    {
        public Pacman Target { get; set; }

        public override void Move(Sprite ghost)
        {
            Walls();
            Vector2 OldPosition = ghost.Position;

            Main();

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
```
This is a steering behaviour for the pink ghost. Its similar to the follow behaviour but instead of the ghost following Pac-Man's position it takes the input of the user to determine where Pac-Man is going to go and follows that position.
#### Follow
```cs
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
```
This steering behaviour is for the red ghost and takes Pac-Man's current position and follows that location
#### Random Move
```cs
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

```
This behaviour is for the orange ghost, it follows random coordinates on the map until it is in proximity with Pac-Man then it goes to chasing Pac-Man
### Steering
Each of the ghosts have a unique AI steering behaviour. The red ghost has the most predictable behavior as it uses Pac-Mans position and follows it, the pink ghost predetermines where Pac-Man is going to be and goes to that location. I did this by taking the input of the user to see what direction the user is moving in and adjust the target position accordingly. The orange ghost takes a random position on the map and follows it, I tried to make it so when the orange close is closer to Pac-Man than the random position the orange ghost follow Pac-Man instead but this resulted in the orange ghost not spawning in so i commented that code out. The blue ghost flows a preset path around the map and stops if it comes into contact with Pac-Man.

All sprites in my game cannot pass through walls in the map, this means that the user has to navigate around them and the ghosts have to use a path finding algorithm to get to Pac-Man.

When any ghost comes in contact with Pac-Man they strop moving

### Pathfinding
I decided to use dijkstras pathfinding algorithm for my game as I thought it would be less complex than using A* algorithm although it is more efficient

My Dijkstras class does not work, I tried different approaches but I didn't leave myself enough time to fully work it out. With the way the pink ghost moves while the Pac-Man is moving the pink ghosts finds its way out of the starting position and if Pac-Man moves to the start position of the ghosts it can coax out the other ghosts.

If I had more time i would put more effort into figuring out the pathfinding algorithm and making more features in the game to make it more attractive.

### State Machine
The orange ghost is supposed randomly moves around the map but when it comes in proximity with Pac-Man it switches to following Pac-Man. To do this I used a state machine with the different states being chase and random movement. The ghost starts with random movement and switches to chase when appropriate. Sadly the random movement does not work correctly but the chase does work and when the ghost is in proximity to Pac-Man the state machine successfully switches to the correct state and when the ghost get far enough away the state machine switches back to moving randomly.

### Reusable Code
I believe my code is very reusable. Each part of my coded is seperated appropriately and most of my variables have good naming conventions making it easy to read. I reused my follow class for each of the different steering behaviours and was able to modify them easily.

### Creativity Flair and Fun
My Pac-Man games is incredibly exciting and entertaining with a map made from scratch. Ghosts are the original colours and mostly follow the original steering behaviours. Around the map there are some areas easier to manuever around and areas they ay be harder keeping the user on their toes.

The walls in the map are a nice violet which constrasts the bright neon colours of the ghosts and the yellow of Pac-Man.



### A Note
my code is very laggy to run this is because of the following while loop in the Random Move class, if you want to check how to code runs in other areas you can comment out this code.
```cs
while (pos != ghost.Position)
{

    int num = rng.Next(0, 400);
    int num2 = rng.Next(0, 800);
    pos = new Vector2(num2, num);
    var dir = pos - ghost.Position;

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
```
