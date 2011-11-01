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
        public Vector2 position; //position of UI_Element

        public UI_Element(Game game, string imageName)
        {
            this.game = game;
            this.imageName = imageName;
            //this.position = new Vector2(0, 0); //init to zero because position will get set with setPosition method
        }

        public virtual void loadContent(Game game)
        {
            this.image = game.Content.Load<Texture2D>(this.imageName);
        }

        public virtual void draw(SpriteBatch spriteBatch, Character player)
        {
            spriteBatch.Begin(); //Used to draw UI on top of everything
            spriteBatch.Draw(this.image, this.position, Color.White);
            spriteBatch.End();
        }

        //set position of UI_Element
        public virtual void setPosition(Vector2 position)
        {
            this.position = position;
        }
    }
}
