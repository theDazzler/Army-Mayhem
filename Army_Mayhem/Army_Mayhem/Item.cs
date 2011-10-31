using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Army_Mayhem
{
    class Item : Sprite
    {
        protected string name;

        public Item(Game game, string imageName, float xPos, float yPos, int width, int height)
            : base(game, imageName, xPos, yPos, width, height)
        {

        }

    }
}
