using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGui;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework.Content;
namespace Project1
{
    public class GameManager 
    {
        private readonly Pacman _player;
        private readonly List<Sprite> _ghosts = new();

        public GameManager()
        {
            _player = new(Globals.content.Load<Texture2D>("R"), new(600, 600));
            var ghosttexture = Globals.content.Load<Texture2D>("pinkghost");

            //var ai = new Around();
            //ai.AddPoint(new(100, 100));
            //ai.AddPoint(new(400, 100));
            //ai.AddPoint(new(400, 400));
            //ai.AddPoint(new(100, 400));

            //_ghosts.Add(new (ghosttexture, new(50, 50))
            //{
            //    MoveAI = ai
            //});

            _ghosts.Add(new(ghosttexture, new(50, 350))
            {
                MoveAI = new Follow
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
            foreach (var ghost in _ghosts)
            {
                ghost.Draw(_spritebatch);
            }
        }
    }
}
