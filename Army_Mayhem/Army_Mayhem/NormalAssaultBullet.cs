using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Army_Mayhem
{
    class NormalAssaultBullet : Bullet
    {
        public NormalAssaultBullet(Game game, float xPos, float yPos) : base (game, "images/assaultBasicBullet", xPos, yPos, 16, 16)
        {
            this.velocity.X = 15f;
            this.velocity.Y = 15f;
            this.maxDistance = 700f;
            this.startPosition.X = xPos;
            this.startPosition.Y = yPos;
            this.damage = 0.1f;
        }
    }
}
