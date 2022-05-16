using System;
using System.Collections.Generic;
using System.Linq;
using App05_Super_Rusty;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Super_Rusty_App05
{
    public class Block
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Velocity;

        public Block(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)(Texture.Width * 0.3), (int)(Texture.Height * 0.3));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
                Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Game1.rusty.Position.X >= 400 && !Scrolling.IsLastBackground())
            {
                Position.X -= 3;
            }
        }
    }
}
