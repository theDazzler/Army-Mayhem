using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ArmyPlatform
{
    class Bullet : Sprite
    {
        protected float damage {get; set;} //how much damage each bullet does to enemy
        public float maxDistance {get; set;} //how far bullet can travel before it disappears
        protected Vector2 velocity; //how fast bullet travels
        public Vector2 startPosition;
        public Boolean dead = false;

        public Bullet(Game game, string imageName, float xPos, float yPos, int width, int height)
            : base(game, imageName, xPos, yPos, width, height)
        {

        }

        public override void Update(GameTime gameTime)
        {
            this.position.X += this.velocity.X;

            base.Update(gameTime);
        }

        //bullet collision detection goes here
        public Boolean isCollided(RandomMap randomMap)
        {
            for (int i = 0; i < randomMap.getNumXBlocks(); i++)
            {
                for (int j = 0; j < randomMap.getNumYBlocks(); j++)
                {
                    //if there is a block
                    if (randomMap.map[i, j] != null)
                    {
                        Block block = randomMap.map[i, j];

                        //if bullet collides with block
                        if (this.boundingBox.Intersects(block.boundingBox))
                        {
                            //decrease block's health
                            randomMap.map[i, j].hardness -= this.damage;
                            if (randomMap.map[i, j].hardness < 0)
                            {
                                randomMap.map[i, j] = null;
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
