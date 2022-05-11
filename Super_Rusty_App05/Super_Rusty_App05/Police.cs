using System;
using App05_Super_Rusty;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Super_Rusty_App05
{
    public class Police
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;

        public bool isVisible = true;

        Random random = new Random();
        float randX;

        public Police(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;

            randX = (float)(-1.5 * random.NextDouble());

            _velocity = new Vector2(randX, Game1.Y_GROUND);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f,
                Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
        }

        public void Update()
        {
            _position.X += _velocity.X;

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Game1.rusty.Position.X >= 400)
            {
                _position.X -= 3;
            }

            if (_position.X < 0 - _texture.Width)
            {
                isVisible = false;
            }

            if (Game1.CheckInterval(Game1.rusty.Position.X, _position.X - 30, _position.X + 30) &&
                Game1.CheckInterval(Game1.rusty.Position.Y, _position.Y - 50, _position.Y + 50))
            {
                Game1.rusty.Lives--;
            }
           
        }
    }
}
