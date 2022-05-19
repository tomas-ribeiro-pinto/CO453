using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Rusty_App05.States;

namespace App05_Super_Rusty
{
    public class Backgrounds
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    public class Scrolling : Backgrounds
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
                if (Game1.rusty.Position.X >= 400 && !IsLastBackground())
                {
                    rectangle.X -= 3;
                }                    
            }
        }

        public static bool IsLastBackground()
        {
            var lastItem = Game1.Scrollings.Last();

            if (lastItem.rectangle.X <= 2)
                return true;

            return false;
        }
    }
}
