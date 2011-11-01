using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Army_Mayhem
{
    class Weapon : Item
    {
        public Weapon(Game game, string imageName, string iconName, float xPos, float yPos, int width, int height)
            : base(game, imageName, iconName, xPos, yPos, width, height)
        {

        }
    }
}
