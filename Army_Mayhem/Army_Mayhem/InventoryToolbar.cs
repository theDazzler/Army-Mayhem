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
    class InventoryToolbar : UI_Element
    {
        public SpriteFont spriteFont;    //hold spriteFont to display ammo and other info
        public Vector2 ammoTextPosition; //position of ammo text
        public Texture2D iconSlot; //picture drawn for each slot in inventory
        const int SLOT_GAP = 2; //spacing between inventory slots

        public InventoryToolbar(Game1 game)
            : base(game, "images/bottom_equipment_toolbar")
        {
            
        }

        public override void loadContent(Game game)
        {
            this.image = game.Content.Load<Texture2D>(this.imageName);
            this.spriteFont = game.Content.Load<SpriteFont>("fonts/Arial");
            this.iconSlot = game.Content.Load<Texture2D>("images/empty_icon");
        }

        public override void draw(SpriteBatch spriteBatch, Character player)
        {
            spriteBatch.Begin(); //Used to draw UI on top of everything
            //spriteBatch.Draw(this.image, this.position, null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0); //draw toolbar
            string text = string.Format("Ammo : {0}", player.gun.currentAmmo);
            spriteBatch.DrawString(this.spriteFont, text, this.ammoTextPosition, Color.White); //draw ammo text

            //draw item icons in player's inventory
            for (int i = 0; i < player.inventory.Length; i++)
            {
                //draw 9 inventory slots
                spriteBatch.Draw(this.iconSlot, new Vector2(this.position.X + (i * this.iconSlot.Width / 2) + i * SLOT_GAP, this.position.Y), null, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }

            spriteBatch.End();
        }

        //set position of toolbar and ammo text
        public override void setPosition(Vector2 position)
        {
            base.setPosition(position); //sets position of toolbar
            this.ammoTextPosition = new Vector2(this.position.X + 3, this.position.Y - 25); //sets position of ammo text
        }
    }
}
