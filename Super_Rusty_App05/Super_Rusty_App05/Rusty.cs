using System;
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
        public Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public bool hasJumped;
        public int Score;
        public int Lives = 1;

        public Rusty(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0f,
                Vector2.Zero, 2f, SpriteEffects.None, 0f);
        }

        public void Update(SoundEffect effect, GameTime gameTime, List<Block> blocks)
        {
            Position += Velocity;

            foreach (var block in blocks)
            {
                if (this.Velocity.X > 0 && block.IsTouchingLeft(block) ||
                   (this.Velocity.X < 0 && block.IsTouchingRight(block)))
                    this.Velocity.X = 0;
                if (this.Velocity.Y > 0 && block.IsTouchingBottom(block) ||
                    (this.Velocity.Y < 0 && block.IsTouchingTop(block)))
                    this.Velocity.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Position.X == 400)
                    Position.X += 4f;
                else if (Position.X <= 400)
                    Position.X += 3f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (Position.X > 5)
                    Position.X -= 2f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                Position.Y -= 10f;
                Velocity.Y = -7f;
                hasJumped = true;
                effect.Play();

            }

            if (hasJumped == true)
            {
                Velocity.Y += 0.2f;
            }

            if (Position.Y >= Game1.Y_POSITION)
            {
                hasJumped = false;
            }

            if (hasJumped == false)
            {
                Velocity.Y = 0f;
            }
        }
    }
}
