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
    class IronBlock : Block
    {
        public IronBlock(Game game, float xPos, float yPos, int width, int height)
            : base(game, "images/iron", xPos, yPos, width, height)
        {
            this.isDestructible = true;
            this.hardness = 1.0f;
        }
    }
}
