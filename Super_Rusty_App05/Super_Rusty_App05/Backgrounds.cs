using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App05_Super_Rusty
{
    class Backgrounds
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Game1.rusty.Position.X >= 400)
                {
                    rectangle.X -= 3;
                }
            }
        }
    }
}
