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


namespace ArmyPlatform
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {
        protected float zoom;      // Camera Zoom
        public Matrix transform;   // Matrix Transform
        public Vector2 position;        // Camera Position
        protected float rotation;  // Camera Rotation

        public Camera(Game game)
            : base(game)
        {
            this.zoom = 1.0f;
            this.rotation = 0.0f;
            this.position = Vector2.Zero;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
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

        // Sets and gets zoom
        public float Zoom
        {
            get { return this.zoom; }
            set { this.zoom = value; if (this.zoom < 0.1f) this.zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return this.rotation; }
            set { this.rotation = value; }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            this.position += amount;
        }

        // Get set position
        public Vector2 Pos
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Matrix getTransformation(GraphicsDevice graphicsDevice)
        {
            this.transform = Matrix.CreateTranslation(new Vector3(-this.position.X, -this.position.Y, 0)) * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * Matrix.CreateTranslation(new Vector3(Game.GraphicsDevice.Viewport.Width * 0.5f, Game.GraphicsDevice.Viewport.Height * 0.5f, 0));
            return this.transform;
        }
    }
}
