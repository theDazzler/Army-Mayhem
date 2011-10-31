using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

/*Possible Bug: Look at sprite's draw method. It should have a begin and end. 
 * But it wont render properly because of camera's getTransformation method. 
 * It would transform the world to create a scrolling effect, but the object's positions internally would not change. 
 * I need to check this out in the future */


namespace ArmyPlatform
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Sprite : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D image;
        protected string imageName;
        public Vector2 position;
        public Texture2D hitBox;
        //creates a new boundingBox around the sprite whenever the boundingBox is returned
        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle((int)this.position.X, (int)this.position.Y, this.image.Width, this.image.Height);
            }
        }

        public Sprite(Game game, string imageName, float xPos, float yPos, int width, int height): base(game)
        {
            this.imageName = imageName;
            this.image = Game.Content.Load<Texture2D>(imageName);
            this.position = new Vector2(xPos, yPos);
            this.hitBox = Game.Content.Load<Texture2D>("images/hitBox");
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.image = Game.Content.Load<Texture2D>(this.imageName);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            //spriteBatch.Begin(); I took these lines out to get sprites to render properly, they werent being transformed properly with the camera's getTransformation method. Look at Game1 draw method, I changed order of base.draw and spriteBatch.End()
            spriteBatch.Draw(this.image, this.position, Color.White);
            spriteBatch.Draw(this.hitBox, this.boundingBox, Color.White);
            //spriteBatch.End(); ######################################################################################################################################
            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        //return width of sprite
        public float getWidth()
        {
            return this.image.Width;
        }

        //return height of sprite
        public float getHeight()
        {
            return this.image.Height;
        }
    }
}
