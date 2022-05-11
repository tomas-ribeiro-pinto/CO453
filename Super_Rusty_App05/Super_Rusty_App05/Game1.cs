using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Rusty_App05;

namespace App05_Super_Rusty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch playerBatch;
        private SpriteBatch backgroundBatch;

        public static Rusty rusty;
        public bool GameOver = false;

        private Scrolling scrolling1;
        private Scrolling scrolling2;
        private Scrolling scrolling3;
        private Block block1;
        private Block block2;
        private Block block3;

        public SpriteFont Arial;

        private Beer beer1;
        private Beer beer2;

        private List<Block> blocks;
        private List<Beer> beers;

        // Police Enemies
        List<Police> enemies = new List<Police>();
        Random random = new Random();

        public static SoundEffect JumpEffect;
        public static SoundEffect BeerEffect;
        public static SoundEffect GameOverEffect;

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

            JumpEffect = Content.Load<SoundEffect>("jump");
            BeerEffect = Content.Load<SoundEffect>("beer_sound");
            GameOverEffect = Content.Load<SoundEffect>("game-over");

            Arial = Content.Load<SpriteFont>("Ubuntu");

            rusty = new Rusty(Content.Load<Texture2D>("deer_still"), new Vector2(20, Y_POSITION));

            scrolling1 = new Scrolling(Content.Load<Texture2D>("background0"), new Rectangle(0, 0, 800, 500));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("background1"), new Rectangle(SCREEN_WIDTH * 1, 0, 800, 500));
            scrolling3 = new Scrolling(Content.Load<Texture2D>("background2"), new Rectangle(SCREEN_WIDTH * 2, 0, 800, 500));

            block1 = new Block(Content.Load<Texture2D>("3_block"), new Vector2(230, Y_POSITION -50));
            block2 = new Block(Content.Load<Texture2D>("1_block"), new Vector2(380, Y_POSITION - 120));
            block3 = new Block(Content.Load<Texture2D>("5_block"), new Vector2(440, Y_POSITION - 120));

            blocks = new List<Block>
            {
                block1,
                block2,
                block3
            };

            beer1 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(340, Y_POSITION));
            beer2 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(900, Y_POSITION - 60));

            beers = new List<Beer>
            {
                beer1,
                beer2
            };

            //police1 = new Police(Content.Load<Texture2D>("police1"), new Vector2(300, Y_POSITION));

            // TODO: use this.Content to load your game content here
        }


        float spawn = 0;

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            rusty.Update(JumpEffect, gameTime, blocks);
            if (rusty.Lives <= 0)
            {
                GameOver = true;
                GameOverEffect.Play();
                backgroundBatch.Begin();
                backgroundBatch.DrawString(Arial, "GAME OVER :(", new Vector2(400, 400), Color.Red);
                backgroundBatch.End();
                System.Threading.Thread.Sleep(1500);
                Exit();
            }

            scrolling1.Update();
            scrolling2.Update();
            scrolling3.Update();

            block1.Update();
            block2.Update();
            block3.Update();

            foreach (Beer beer in beers)
            {
                beer.Update();
            }

            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Police enemy in enemies)
            {
                enemy.Update();
            }

            LoadEnemies();

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

        public void LoadEnemies()
        {
            int randX = random.Next(810, 900);

            if (spawn >= 2)
            {
                spawn = 0;
                if (enemies.Count() < 2)
                {
                    enemies.Add(new Police(Content.Load<Texture2D>("police_man"), new Vector2(randX, Y_POSITION)));
                }
            }

            for (int i = 0; i < enemies.Count(); i++)
            {
                if (!enemies[i].isVisible)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            backgroundBatch.Begin();
            scrolling1.Draw(backgroundBatch);
            scrolling2.Draw(backgroundBatch);
            scrolling3.Draw(backgroundBatch);
            backgroundBatch.DrawString(Arial, $"Score: {rusty.Score}", new Vector2(10, 10), Color.Black);
            backgroundBatch.End();

            playerBatch.Begin();
            rusty.Draw(playerBatch);
            foreach (Beer beer in beers)
                if (beer.IsVisible)
                    beer.Draw(playerBatch);
            foreach (Police enemy in enemies)
                enemy.Draw(playerBatch);
            foreach (Block block in blocks)
                block.Draw(playerBatch);
            playerBatch.End();

            base.Draw(gameTime);
        }

        public static bool CheckInterval(float value, float lowBound, float highBound)
        {
            if (value >= lowBound && value <= highBound)
                return true;
            return false;
        }
    }
}
