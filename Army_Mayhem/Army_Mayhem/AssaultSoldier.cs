using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Army_Mayhem
{
    class AssaultSoldier : Character
    {
        public AssaultSoldier(Game game, RandomMap randomMap, float xPos, float yPos, int width, int height)
            : base(game, randomMap, "images/stance", xPos, yPos, width, height)
        {
            this.gun = new AssaultRifle(game, randomMap, 50f, 50f, 32, 32);
            this.inventory[0] = this.gun;
        } 
    }
}
