using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/* 
 * Base class for the different classes in the game
 */

/*
 * Issues:
        1. Fix collision detection when player walks over empty space(isFalling needs to get set to true when nothing is under the player)
 */

namespace ArmyPlatform
{
    class Character : Sprite
    {
        protected RandomMap randomMap; //holds the level
        protected float maxJumpHeight = 64f;
        public Vector2 velocity;
        public string direction = "right";
        public Vector2 startJumpPosition; //keeps track of position of player before he jumped
        public Boolean isWalking = false;
        public Boolean isJumping = false;
        public Boolean isFalling = true;
        public Boolean isStanding = false;

        public int health = 100;
        //public Item[] items;
        public Gun gun;
        

        public Character(Game game, RandomMap randomMap, string imageName, float xPos, float yPos, int width, int height)
            : base(game, imageName, xPos, yPos, width, height)
        {
            this.randomMap = randomMap;
            this.velocity.X = 205.0f;
            this.velocity.Y = 250.0f;
            this.gun = new AssaultRifle(game, randomMap, 50f, 50f, 32, 32);
        }

        public override void Update(GameTime gameTime)
        {
            // Store the current state of the keyboard
            KeyboardState currentKeyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            //checks to see if player is colliding with blocks
            this.checkCollision(gameTime);

            //shoots gun with a delay for the bullets
            this.gun.fireTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentMouseState.LeftButton == ButtonState.Pressed && this.gun.fireTime >= this.gun.fireRate)
            {
                this.gun.fireTime = 0;
                this.gun.soundEffect.Play();
                this.gun.bullets.Add(new NormalAssaultBullet(this.Game, this.position.X, this.position.Y));
            }
            
            //if player is falling, make player fall
            if (this.isFalling)
            {
                this.velocity.Y += GameSettings.GRAVITY;
                //sets speed that character falls
                this.position.Y += this.velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //if player is not moving left or right, set isMoving to false
            if (currentKeyboardState.IsKeyUp(Keys.A) && currentKeyboardState.IsKeyUp(Keys.D))
            {
                this.isWalking = false;
            }

            //move left
            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.isWalking = true;
                this.direction = "left";
                this.position.X -= this.velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //move right
            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.isWalking = true;
                this.direction = "right";
                //this.camera.position.X += this.velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
                this.position.X += this.velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //jump
            if (currentKeyboardState.IsKeyDown(Keys.Space))
            {
                if ((!this.isFalling) && (!this.isJumping))
                {
                    this.isFalling = false;
                    this.velocity.Y = 250f;
                    this.startJumpPosition = this.position;
                    this.isJumping = true;
                }
            }

            //if player is jumping, move player up
            if (this.isJumping)
            {
                this.velocity.Y -= GameSettings.GRAVITY;
                this.position.Y -= this.velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds; 

                //if player has reached maximunm jump height, send him back down to the ground
                if (this.startJumpPosition.Y - this.position.Y > this.maxJumpHeight)
                {
                    this.isFalling = true;
                    this.isJumping = false;
                }
            }

            this.gun.Update(gameTime);

            base.Update(gameTime);
        }

        public void checkCollision(GameTime gameTime)
        {
            //collision detection
            for (int i = 0; i < this.randomMap.getNumXBlocks(); i++)
            {
                for (int j = 0; j < this.randomMap.getNumYBlocks(); j++)
                {
                    //if there is a block
                    if (this.randomMap.map[i, j] != null)
                    {
                        Block block = this.randomMap.map[i, j];
                        if (this.boundingBox.Intersects(block.boundingBox))
                        {
                            //check for left and right collisions
                            this.checkVerticalCollisions(block);

                            //check for top and bottom collision
                            this.checkHorizontalCollisions(block);                            
                        }
                        

                    }
                }
            }
        }


        protected void checkVerticalCollisions(Block block)
        {
            //if player is left of  the block and colliding, move player back to the left
            if ((!this.isFalling) && (this.boundingBox.Right > block.boundingBox.Left) && (this.boundingBox.Right < block.boundingBox.Right))
            {
                while ((this.boundingBox.Right > block.boundingBox.Left))
                {
                    this.position.X -= this.boundingBox.Right - block.boundingBox.Left;
                }
            }

            //if player is right of  the block and colliding, move player back to the right
            if ((!this.isFalling) && (this.boundingBox.Left < block.boundingBox.Right) && (this.boundingBox.Left > block.boundingBox.Left))
            {
                while ((this.boundingBox.Left < block.boundingBox.Right))
                {
                    this.position.X += block.boundingBox.Right - this.boundingBox.Left;
                }
            }
        }

        protected void checkHorizontalCollisions(Block block)
        {
            //if player is on top of block move player up (don't let player fall through a block)
            if ((this.isFalling) && (this.boundingBox.Bottom > block.boundingBox.Top))
            {
                if (!this.isJumping)
                {
                    this.isFalling = false;
                    //move player up based on how much overlap there is between player's boundingBox and the block's boundingBox
                    while ((this.boundingBox.Bottom > block.boundingBox.Top))
                    {
                        this.position.Y -= (this.boundingBox.Bottom - block.boundingBox.Top);
                    }
                    this.isStanding = true;
                }
            }
        }
    }
}
