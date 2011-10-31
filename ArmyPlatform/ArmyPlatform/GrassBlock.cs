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

namespace ArmyPlatform
{
    class GrassBlock : Block
    {
        public GrassBlock(Game game, float xPos, float yPos, int width, int height)
            : base(game, "grass", xPos, yPos, width, height)
        {
            this.isDestructible = true;
            this.hardness = .5f;
        }

        //get block's hardness
        public float getHardness()
        {
            return this.hardness;
        }
    }
}
