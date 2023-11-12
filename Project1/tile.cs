using Microsoft.Xna.Framework;

namespace Project1
{
    public class Tile
    {
        public Color TileColor { get; set; }
        public Rectangle SourceRect { get; set; }

        public bool IsWall()
        {
            if (TileColor == Color.Blue)
            {
                return false;
            }
            else
            { 
                return true;
            }
        }

        
    }
}