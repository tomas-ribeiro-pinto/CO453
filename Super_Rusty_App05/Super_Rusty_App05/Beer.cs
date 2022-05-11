using System;
using App05_Super_Rusty;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Super_Rusty_App05
{
    public class Beer
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;
        private float oldPosition;
        public bool IsVisible = true;

        public Beer(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            oldPosition = _position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f,
                Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

        public void Update()
        {
            _position.Y += _velocity.Y;

            if (IsVisible)
            {
                if (_velocity.Y == 0)
                    _velocity.Y = -0.08f;
                else if (_velocity.Y < 0 && _position.Y <= oldPosition - 4)
                    _velocity.Y = 0.08f;
                else if (_velocity.Y > 0 && _position.Y >= oldPosition + 4)
                    _velocity.Y = -0.08f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Game1.rusty.Position.X >= 400)
            {
                _position.X -= 3;
            }

            if (IsVisible && Game1.CheckInterval(Game1.rusty.Position.X, _position.X - 20, _position.X + 20) && Game1.CheckInterval(Game1.rusty.Position.Y, _position.Y - 20, _position.Y + 20))
            {
                Game1.rusty.Score++;
                IsVisible = false;
                Game1.BeerEffect.Play(volume: 0.3f, pitch: 0.0f, pan: 0.0f);
            }
        }
    }
}
