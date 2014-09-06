using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSprites
{
    class UserControlledSprite: Sprite
    {



        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, null, 0)
        { 
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, null, 0)
        {
        }




        public override Vector2 direction 
        {
            get 
            {
                Vector2 inputDirection = Vector2.Zero;
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    inputDirection.X -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    inputDirection.X += 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    inputDirection.Y -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    inputDirection.Y += 1;

                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                if (gamePadState.ThumbSticks.Left.X != 0)
                    inputDirection.X += gamePadState.ThumbSticks.Left.X;
                if (gamePadState.ThumbSticks.Left.Y != 0)
                    inputDirection.Y -= gamePadState.ThumbSticks.Left.Y;


                return inputDirection * speed;
            }
        }

        ////Commented out MOUSE support:
        //MouseState prevMouseState;





        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

            position += direction;

            ////Commented out MOUSE support:
            //MouseState currMouseState = Mouse.GetState();
            //if (currMouseState.X != prevMouseState.X ||
            //    currMouseState.Y != prevMouseState.Y)
            //{
            //    position = new Vector2(currMouseState.X, currMouseState.Y);
            //}

            //prevMouseState = currMouseState;

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > clientBounds.Width - frameSize.X)
                position.X = clientBounds.Width - frameSize.X;
            if (position.Y > clientBounds.Height - frameSize.Y)
                position.Y = clientBounds.Height - frameSize.Y;

            base.Update(gameTime, clientBounds);

        }
    }
}
