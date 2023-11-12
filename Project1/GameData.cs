using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

namespace Project1
{
    static class GameData
    {
        public static Point TileCount { get; set; }
        public static Point TileSize { get; set; }
        public static Point LevelOffset { get; internal set; }

        public static bool OutOfBounds(Point p)
        {
            if (p.X < 0 || p.Y < 0 || p.X >= TileCount.X || p.Y >= TileCount.Y)
                return true;
            return false;
        }
    }
}