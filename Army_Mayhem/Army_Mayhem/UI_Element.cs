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
    //base class for UI Elements
    class UI_Element
    {
        public Game game;
        public Texture2D image;
        protected string imageName;

        public UI_Element(Game game, string imageName)
        {
            this.game = game;
            this.imageName = imageName;
        }

        public void loadContent(Game game)
        {
            this.image = game.Content.Load<Texture2D>(this.imageName);
        }

        public void draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin(); //Used to draw UI on top of everything
            spriteBatch.Draw(this.image, position, Color.White);
            spriteBatch.End();
        }
    }
}
