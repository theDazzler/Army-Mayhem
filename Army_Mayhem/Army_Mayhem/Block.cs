using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Army_Mayhem
{
    class Block : Sprite
    {
        public Boolean isDestructible;
        public float hardness;

        public Block(Game game, string imageName, float xPos, float yPos, int width, int height)
            : base(game, imageName, xPos, yPos, width, height)
        {
        }
    }
}
