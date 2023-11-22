using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGui;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
namespace Project1
{
    public class GameManager : Game1
    {
        private readonly List<Ghost> _ghosts = new();
        public GameManager()
        { 

            var ghosttexture = Content.Load<Texture2D>("pinkghost");

            var ai = new Around();
            ai.AddPoint(new(100, 100));
            ai.AddPoint(new(400, 100));
            ai.AddPoint(new(400, 400));
            ai.AddPoint(new(100, 400));

            _ghosts.Add(new (ghosttexture, new(50, 50))
            {
                MoveAI = ai
            });
        }
        public void Update()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.Update();
            }
        }
        //public void Draw()
        //{
        //    foreach (var ghost in _ghosts)
        //    {
        //        ghost.Draw();
        //    }
        //}
    }
}
