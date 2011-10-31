using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Army_Mayhem
{
    class AssaultRifle : Gun
    {
        public AssaultRifle(Game game, RandomMap randomMap, float xPos, float yPos, int width, int height)
            : base(game, randomMap, "images/assaultBasicBullet", xPos, yPos, width, height)
        {
            this.name = "Assault Rifle";
            this.fireRate = 0.1f;
            this.currentAmmo = 100;
            this.maxAmmo = 400;
            this.roundsPerMag = 30;
        }
    }
}
