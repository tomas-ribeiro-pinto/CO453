using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Rusty_App05;

namespace App05_Super_Rusty
{
    public class Rusty
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Velocity;

        //private Rectangle oldRectangle;

        public bool hasJumped;
        public bool aboveGround;
        public int Score;
        public int Lives = 2;

        public const int TEXTURE_WIDTH = 58;
        public const int TEXTURE_HEIGHT = 60;

        public Rusty(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            //oldRectangle = new Rectangle(0, 0, Game1.Y_GROUND , 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
                Vector2.Zero, 2f, SpriteEffects.None, 0f);
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width * 2, Texture.Height * 2);
            }
        }

        public void Update(SoundEffect effect, GameTime gameTime, List<Block> blocks)
        {
            Position += Velocity;

            if(Keyboard.GetState().IsKeyUp(Keys.Right) || Keyboard.GetState().IsKeyUp(Keys.Left))
                Velocity.X = 0f;

            foreach (var block in blocks)
            {
                if ((Velocity.X > 0 && IsTouchingLeft(block)) ||
                    (Velocity.X < 0 && IsTouchingRight(block)))
                {
                    Velocity.X = 0f;
                }
                if (Velocity.Y > 0 && IsTouchingTop(block))
                {
                    Velocity.Y = 0f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Position.X < 400)
                    Velocity.X += 3f;
                else if (Position.X == 400)
                    Velocity.X += 3f;

                if (Scrolling.IsLastBackground() && Position.X < 790 - Texture.Width)
                    Velocity.X += 3f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (Position.X > 5)
                    Velocity.X = -3f;
            }

            /**
            if (OnTopOfBlock())
            {
                oldRectangle = GetOldBlock();
                aboveGround = true;
            }
            **/

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                Position.Y -= 10f;
                Velocity.Y = -7f;
                hasJumped = true;
                effect.Play();
            }

            else if(!OnTopOfBlock() && Position.Y <= Game1.Y_GROUND && !hasJumped)
            {
                hasJumped = true;
            }

            /**
            if (aboveGround && Game1.CheckInterval(Position.Y, oldRectangle.Y, oldRectangle.Y + oldRectangle.Height) && Game1.CheckInterval(Position.Y, oldRectangle.X, oldRectangle.X + oldRectangle.Width))
            {
                hasJumped = false;
                aboveGround = false;
            }
            **/

            if (hasJumped == true)
            {
                Velocity.Y += 0.2f;
            }

            if (Position.Y >= Game1.Y_GROUND || OnTopOfBlock())
            {
                hasJumped = false;
            }
            if (hasJumped == false)
            {
                Velocity.Y = 0f;
            }
        }

        #region
        public bool IsTouchingLeft(Block block)
        {
            return Rectangle.Right < block.Rectangle.Left &&
                Rectangle.Bottom > block.Rectangle.Top &&
                Rectangle.Top < block.Rectangle.Bottom;
        }
        public bool IsTouchingRight(Block block)
        {
            return Rectangle.Left > block.Rectangle.Right &&
                Rectangle.Bottom > block.Rectangle.Top &&
                Rectangle.Top < block.Rectangle.Bottom;
        }
        public bool IsTouchingTop(Block block)
        {
            return Rectangle.Bottom <= block.Rectangle.Top + 1 &&
                Rectangle.Top >= block.Rectangle.Top - TEXTURE_HEIGHT - 2 &&
                Rectangle.Left < block.Rectangle.Right - 10 &&
                Rectangle.Right > block.Rectangle.Left + 10;
        }

        public bool IsTouchingBottom(Block block)
        {
            return Rectangle.Top > block.Rectangle.Bottom &&
                Rectangle.Bottom <= block.Rectangle.Top + TEXTURE_HEIGHT + 1 &&
                Rectangle.Right > block.Rectangle.Left &&
                Rectangle.Left < block.Rectangle.Right;
        }
        #endregion

        public bool OnTopOfBlock()
        {
            foreach (Block block in Game1.blocks)
                if (IsTouchingTop(block))
                    return true;

            return false;
        }
        public Rectangle GetOldBlock()
        {
            foreach (Block block in Game1.blocks)
                if (IsTouchingTop(block))
                    return block.Rectangle;

            return Rectangle.Empty;
        }
    }
}
