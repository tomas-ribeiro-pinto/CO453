using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App05_Super_Rusty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _texture;
        private Vector2 _position;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("deer_still");
            _position = new Vector2(20, 300);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _position.Y += 3;
                _position.Y -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _position.X += 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _position.X -= 2;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0f,
            Vector2.Zero, 2f, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
