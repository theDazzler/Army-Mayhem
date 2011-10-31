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

namespace Army_Mayhem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RandomMap randomMap;
        Character player;
        Camera camera;
        SoundEffect bgMusic;

        UI_Element bottomItemBar;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            //this.graphics.IsFullScreen = true;
            this.IsMouseVisible = true;      
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            randomMap = new RandomMap(this, 3200, 300);
            player = new AssaultSoldier(this, randomMap, (this.GraphicsDevice.Viewport.Width / 2) - 32, 0f, 64, 128);
            camera = new Camera(this);
            Components.Add(player);

            bottomItemBar = new UI_Element(this, "images/bottom_equipment_toolbar"); //bottom inventory bar

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //background music
            bgMusic = this.Content.Load<SoundEffect>("sounds/bg_music_1");
            bgMusic.Play();
            
            bottomItemBar.loadContent(this);

            Services.AddService(typeof(SpriteBatch), spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            camera.position = new Vector2(player.position.X, player.position.Y);

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //toggle fullscreen
            if (currentKeyboardState.IsKeyDown(Keys.F))
            {
                graphics.ToggleFullScreen();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //scroll level
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.getTransformation(GraphicsDevice));

            //draw map
            randomMap.drawMap(spriteBatch);

            //draw bullets
            foreach (Bullet bullet in player.gun.bullets)
            {
                spriteBatch.Draw(bullet.image, bullet.position, Color.White);
                spriteBatch.Draw(bullet.hitBox, bullet.boundingBox, Color.White);
            }

            base.Draw(gameTime);
            spriteBatch.End();

            //Draw all UI here/////////////////
            this.bottomItemBar.draw(spriteBatch, new Vector2((this.GraphicsDevice.Viewport.Width / 2) - (this.bottomItemBar.image.Width / 2), this.GraphicsDevice.Viewport.Height - this.bottomItemBar.image.Height));
        }
    }
}
