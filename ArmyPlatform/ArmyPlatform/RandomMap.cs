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

/*generates a very basic random map made of blocks*/

namespace ArmyPlatform
{
    class RandomMap
    {
        protected Game game;
        protected int mapWidth;
        protected int mapHeight;
        protected int xNumBlocks;
        protected int yNumBlocks;
        public Block[,] map;

        //creates random block map
        public RandomMap(Game game, int mapWidth, int mapHeight)
        {
            this.game = game;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.xNumBlocks = mapWidth / GameSettings.BLOCK_WIDTH;
            this.yNumBlocks = mapHeight / GameSettings.BLOCK_HEIGHT;

            this.map = new Block[xNumBlocks, yNumBlocks];

            this.initMap();
        }

        //initialize the map
        private void initMap()
        {
            Random random = new Random();

            for(int i = 0; i < this.xNumBlocks; i++)
            {
                for (int j = 0; j < this.yNumBlocks; j++)
                {
                    switch(random.Next(1,3))
                    {
                        case 1:
                            this.map[i, j] = new GrassBlock(this.game, i * GameSettings.BLOCK_WIDTH, j * GameSettings.BLOCK_HEIGHT + GameSettings.FLOOR_HEIGHT, GameSettings.BLOCK_WIDTH, GameSettings.BLOCK_HEIGHT);
                            break;
                        case 2:
                            this.map[i, j] = null;
                            break;
                        case 3:
                            this.map[i, j] = null;
                            break;
                    }
                    
                }
            }
        }

        //draws map to screen
        public void drawMap(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < this.xNumBlocks; i++)
            {
                for (int j = 0; j < this.yNumBlocks; j++)
                {
                    if (this.map[i, j] != null)
                    {
                        Block block = this.map[i, j];
                        spriteBatch.Draw(block.image, block.position, Color.White);
                    }
                }
            }
        }
        

        //return number of blocks in X direction
        public int getNumXBlocks()
        {
            return this.xNumBlocks;
        }

        //return number of blocks in Y direction
        public int getNumYBlocks()
        {
            return this.yNumBlocks;
        }
    }
}
