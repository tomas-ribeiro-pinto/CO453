using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App05_Super_Rusty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch playerBatch;
        private SpriteBatch backgroundBatch;

        public static Rusty rusty;
        private Scrolling scrolling1;
        private Scrolling scrolling2;
        private Scrolling scrolling3;

        public SoundEffect effect;

        public const int Y_POSITION = 360;
        public const int SCREEN_WIDTH = 800;

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
            playerBatch = new SpriteBatch(GraphicsDevice);
            backgroundBatch = new SpriteBatch(GraphicsDevice);

            effect = Content.Load<SoundEffect>("jump");

            rusty = new Rusty(Content.Load<Texture2D>("deer_still"), new Vector2(20, Y_POSITION));

            scrolling1 = new Scrolling(Content.Load<Texture2D>("background0"), new Rectangle(0, 0, 800, 500));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("background1"), new Rectangle(SCREEN_WIDTH * 1, 0, 800, 500));
            scrolling3 = new Scrolling(Content.Load<Texture2D>("background2"), new Rectangle(SCREEN_WIDTH * 2, 0, 800, 500));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            rusty.Update(effect);

            scrolling1.Update();
            scrolling2.Update();
            scrolling3.Update();

            /**
            if (scrolling1.rectangle.X + scrolling1.texture.Width <= 0)
            {
                scrolling1.rectangle.X = scrolling2.rectangle.X + scrolling2.texture.Width;
            }
            if (scrolling2.rectangle.X + scrolling2.texture.Width <= 0)
            {
                scrolling2.rectangle.X = scrolling1.rectangle.X + scrolling1.texture.Width;
            }
            **/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            backgroundBatch.Begin();
            scrolling1.Draw(backgroundBatch);
            scrolling2.Draw(backgroundBatch);
            scrolling3.Draw(backgroundBatch);
            backgroundBatch.End();

            playerBatch.Begin();
            rusty.Draw(playerBatch);
            playerBatch.End();

            base.Draw(gameTime);
        }
    }
}
