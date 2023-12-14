﻿using ImGuiNET;
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
        private readonly List<Ghost> _ghosts = new();

        public GameManager()
        {
            _player = new(Globals.content.Load<Texture2D>("R"), new(0, 0));
            var ghosttexture1 = Globals.content.Load<Texture2D>("pink");
            var ghosttexture2 = Globals.content.Load<Texture2D>("orangeghost");
            var ghosttexture3 = Globals.content.Load<Texture2D>("blue");
            var ghosttexture4 = Globals.content.Load<Texture2D>("redghost");

            //var ai = new Around();
            //ai.AddPoint(new(100, 100));
            //ai.AddPoint(new(400, 100));
            //ai.AddPoint(new(400, 400));
            //ai.AddPoint(new(100, 400));

            //_ghosts.Add(new (ghosttexture, new(50, 50))
            //{
            //    MoveAI = ai
            //});

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

            _ghosts.Add(new(ghosttexture2, new(750, 30))
            {
                MoveAI = new Follow
                {
                    Target = _player
                }
            });

            _ghosts.Add(new(ghosttexture3, new(750, 0))
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
            _player.Draw(_spritebatch );
            foreach (var ghost in _ghosts)
            {
                ghost.Draw(_spritebatch);
            }
        }
    }
}
