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
    class Gun : Weapon
    {
        public SoundEffect soundEffect;
        public float fireRate; //how fast gun shoots, the lower the rate, the faster it shoots
        public float fireTime = 0f;
        protected int maxAmmo; //how much ammo gun can hold
        public int currentAmmo; //how much ammo gun currently has
        protected int roundsPerMag; //how much ammo per magazine
        public List<Bullet> bullets = new List<Bullet>();
        public RandomMap randomMap;

        public Gun(Game game, RandomMap randomMap, string imageName, float xPos, float yPos, int width, int height)
            : base(game, imageName, xPos, yPos, width, height)
        {
            this.LoadContent();
            this.randomMap = randomMap;
        }

        public override void Update(GameTime gameTime)
        { 
            if (this.bullets.Count() != 0)
            {
                for (int i = 0; i < this.bullets.Count; i++)
                {
                    Bullet bullet = this.bullets[i];
                    bullet.Update(gameTime);

                    //if bullet travels farther than its maxDistance, remove bullet from screen
                    if (MathHelper.Distance(bullet.boundingBox.X, bullet.startPosition.X) > bullet.maxDistance)
                    {
                        this.bullets.RemoveAt(i);
                        i--;
                    }
                    //if bullet hits a block from randomMap
                    if (bullet.isCollided(this.randomMap))
                    {
                        this.bullets.RemoveAt(i);

                    }
                }
            }
            

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            this.soundEffect = Game.Content.Load<SoundEffect>("sounds/normalAssaultBullet");
            base.LoadContent();
        }

        public float getFireRate()
        {
            return this.fireRate;
        }

        public void setFireRate(float rate)
        {
            this.fireRate = rate;
        }

        public int getMaxAmmo()
        {
            return this.maxAmmo;
        }

        public void setMaxAmmo(int amount)
        {
            this.maxAmmo = amount;
        }

        public int getRoundsPerMag()
        {
            return this.roundsPerMag;
        }

        public void setRoundsPerMag(int amount)
        {
            this.roundsPerMag = amount;
        }
    }
}
