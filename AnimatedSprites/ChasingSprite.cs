﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace AnimatedSprites
{
    class ChasingSprite: Sprite
    {
        // Save a reference to the sprite manager to 
        // use to get the player position:
        SpriteManager spriteManager;


        public ChasingSprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, string collisionCueName, SpriteManager spriteManager, int scoreValue)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, collisionCueName, scoreValue)
        {
            this.spriteManager = spriteManager;
        }

        public ChasingSprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, string collisionCueName, SpriteManager spriteManager, int scoreValue)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName, scoreValue)
        {
            this.spriteManager = spriteManager;
        }

        public override Vector2 direction
        {
            get { return speed; }
        }




        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += speed;

            // User the player position to move the sprite closer in 
            // the X and/or Y directions
            Vector2 player = spriteManager.GetPlayerPosition();

            // Because sprite may be moving in the x or y direction
            // but not both, get the largest of the two numbers
            // and use it as the speed of the object
            //////////////float speedVal = Math.Max(
            //////////////    Math.Abs(speed.X), Math.Abs(speed.Y));


            if (speed.X == 0)
            {
                if (player.X < position.X - 10)
                    position.X -= Math.Abs(speed.Y);
                else if (player.X > position.X + 10)
                    position.X += Math.Abs(speed.Y);

            }

            if (speed.Y == 0)
            {
                if (player.Y < position.Y +-10)
                    position.Y -= Math.Abs(speed.X);
                else if (player.Y > position.Y + 10)
                    position.Y += Math.Abs(speed.X);
            }

            base.Update(gameTime, clientBounds);
        }






    }
}
