﻿using Microsoft.Xna.Framework.Graphics;
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
    public class Ghost : Sprite
    {
        public Movement moveAI { get; set; }

        public Ghost(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 250;
        }

        public void Update()
        {
            moveAI.Move(this);
        }
    }
}
