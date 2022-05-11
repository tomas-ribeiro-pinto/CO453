using System;
using System.Collections.Generic;
using App05_Super_Rusty;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Super_Rusty_App05
{
    public class Block
    {
        private Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;

        public Block(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            Position = position;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0f,
                Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Game1.rusty.Position.X >= 400)
            {
                Position.X -= 3;
            }
        }

        #region
        public bool IsTouchingLeft(Block block)
        {
            return this.Rectangle.Right + this.Velocity.X > block.Rectangle.Left &&
                this.Rectangle.Left < block.Rectangle.Left &&
                this.Rectangle.Bottom > block.Rectangle.Top &&
                this.Rectangle.Top < block.Rectangle.Bottom;
        }
        public bool IsTouchingRight(Block block)
        {
            return this.Rectangle.Left + this.Velocity.X < block.Rectangle.Right &&
                this.Rectangle.Right > block.Rectangle.Right &&
                this.Rectangle.Bottom > block.Rectangle.Top &&
                this.Rectangle.Top < block.Rectangle.Bottom;
        }
        public bool IsTouchingTop(Block block)
        {
            return this.Rectangle.Bottom + this.Velocity.X > block.Rectangle.Top &&
                this.Rectangle.Top < block.Rectangle.Top &&
                this.Rectangle.Left < block.Rectangle.Right &&
                this.Rectangle.Right > block.Rectangle.Left;
        }
        public bool IsTouchingBottom(Block block)
        {
            return this.Rectangle.Top + this.Velocity.X > block.Rectangle.Bottom &&
                this.Rectangle.Bottom > block.Rectangle.Bottom &&
                this.Rectangle.Right > block.Rectangle.Left &&
                this.Rectangle.Left < block.Rectangle.Right;
        }
        public bool IsNotTouching(Block block)
        {
            if (IsTouchingBottom(block) && IsTouchingLeft(block) && IsTouchingRight(block) && IsTouchingTop(block))
                return false;

            return true;
        }
        #endregion
    }
}
