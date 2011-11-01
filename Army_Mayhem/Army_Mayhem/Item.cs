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
    class Item : Sprite
    {
        protected string name;
        public Texture2D icon;  //image that shows up in the inventory
        public string iconName; //filename of icon image

        public Item(Game game, string imageName, string iconName, float xPos, float yPos, int width, int height)
            : base(game, imageName, xPos, yPos, width, height)
        {
            this.iconName = iconName;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            this.icon = Game.Content.Load<Texture2D>(this.iconName); //load icon image
        }

    }
}
