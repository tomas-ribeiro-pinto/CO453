using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Rusty_App05;
using Super_Rusty_App05.States;

namespace App05_Super_Rusty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch playerBatch;
        private SpriteBatch backgroundBatch;

        public static Rusty rusty;
        public bool GameOver = true;
        public static bool lostGame = false;
        public static bool wonGame = false;

        private OtherSprite heart1;
        private OtherSprite heart2;

        public static int Timer = 1000;

        private Scrolling background;
        public Scrolling GameLostBackground;
        public Scrolling GameWonBackground;
        private Scrolling scrolling1;
        private Scrolling scrolling2;
        private Scrolling scrolling3;

        private Block block1;
        private Block block2;
        private Block block3;
        private Block block4;
        private Block block5;

        public SpriteFont Arial;

        private Beer beer1;
        private Beer beer2;
        private Beer beer3;
        private Beer beer4;
        private Beer beer5;

        public static List<Block> blocks;
        public static List<Scrolling> Scrollings;

        private List<Beer> beers;

        // Police Enemies
        List<Police> enemies = new List<Police>();
        Random random = new Random();

        // States
        private State _currentState;
        private State _nextState;

        public static bool gameStarted = false;

        public static SoundEffect JumpEffect;
        public static SoundEffect BeerEffect;
        public static SoundEffect WinEffect;
        public static SoundEffect LostLifeEffect;
        public static SoundEffect BgMusic;
        public static SoundEffectInstance music;

        public const int Y_GROUND = 360;
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

        public void ChangeState(State state)
        {
            _nextState = state;
            music = BgMusic.CreateInstance();
            music.Play();
        }

        protected override void LoadContent()
        {
            playerBatch = new SpriteBatch(GraphicsDevice);
            backgroundBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);

            JumpEffect = Content.Load<SoundEffect>("jump");
            BeerEffect = Content.Load<SoundEffect>("beer_sound");
            LostLifeEffect = Content.Load<SoundEffect>("lost-life");
            WinEffect = Content.Load<SoundEffect>("Retro-games-style-winning-trumpet-sound-effect-wav");
            BgMusic = Content.Load<SoundEffect>("Mario-theme-song-wav");

            Arial = Content.Load<SpriteFont>("Ubuntu");

            background = new Scrolling(Content.Load<Texture2D>("main_menu"), new Rectangle(0, 0, 800, 480));
            GameLostBackground = new Scrolling(Content.Load<Texture2D>("gameOver"), new Rectangle(0, 0, 800, 480));
            GameWonBackground = new Scrolling(Content.Load<Texture2D>("congrats"), new Rectangle(0, 0, 800, 480));
        }


        float spawn = 0;

        protected override void Update(GameTime gameTime)
        {

            if (gameStarted && !GameOver)
            {
                rusty.Update(JumpEffect, gameTime, blocks);
                IsGameOver();

                foreach (Scrolling scrolling in Scrollings)
                    scrolling.Update();

                foreach (Block block in blocks)
                    block.Update();

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
            }

            else
            {
                _currentState.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randX = random.Next(810, 900);

            if (spawn >= 2)
            {
                spawn = 0;
                if (enemies.Count() < 2 && !Scrolling.IsLastBackground())
                {
                    enemies.Add(new Police(Content.Load<Texture2D>("police_man"), new Vector2(randX, Y_GROUND)));
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
            _currentState.Draw(gameTime, playerBatch, background);

            if (gameStarted && GameOver)
            {
                GameOver = false;
                ReloadGame();
            }

            if (gameStarted && !GameOver)
            {
                backgroundBatch.Begin();
                foreach (Scrolling scrolling in Scrollings)
                    scrolling.Draw(backgroundBatch);
                backgroundBatch.DrawString(Arial, $"Beers: {rusty.Score}", new Vector2(10, 10), Color.Black);
                backgroundBatch.End();

                playerBatch.Begin();
                rusty.Draw(playerBatch);

                // Heart Lives for the player on right top of the screen
                if (rusty.Lives == 2)
                {
                    heart1.Draw(playerBatch);
                    heart2.Draw(playerBatch);
                }
                if (rusty.Lives == 1)
                {
                    heart2.Draw(playerBatch);
                }
                
                foreach (Beer beer in beers)
                    if (beer.IsVisible)
                        beer.Draw(playerBatch);
                foreach (Police enemy in enemies)
                    enemy.Draw(playerBatch);
                foreach (Block block in blocks)
                    block.Draw(playerBatch);
                playerBatch.End();
            }

            playerBatch.Begin();


            if (lostGame)
            {
                if (Timer <= 0)
                {
                    System.Threading.Thread.Sleep(2500);
                    lostGame = false;
                    gameStarted = false;
                    GameOver = true;
                    Timer = 1000;
                }
                else
                {
                    GameLostBackground.Draw(playerBatch);
                    playerBatch.DrawString(Arial, $"Drunkness: {rusty.Score * 100 / beers.Count()}%", new Vector2(300, 420), Color.Blue);
                    startTimer();
                }
            }

            if (wonGame)
            {

                if (Timer <= 0)
                {
                    System.Threading.Thread.Sleep(5000);
                    wonGame = false;
                    gameStarted = false;
                    GameOver = true;
                    Timer = 1000;
                }
                else
                {
                    GameWonBackground.Draw(playerBatch);
                    playerBatch.DrawString(Arial, $"Drunkness: {rusty.Score * 100 / beers.Count()}%", new Vector2(310, 420), Color.Blue);
                    startTimer();
                }
            }

            playerBatch.End();

            base.Draw(gameTime);
        }

        public void IsGameOver()
        {
            if (Scrolling.IsLastBackground() && rusty.Position.X >= 650)
            {
                music.Stop();
                WinEffect.Play();
                wonGame = true;
            }
            if (rusty.Lives <= 0)
            {
                music.Stop();
                lostGame = true;
            }
        }

        public void LoadBeers()
        {
            beer1 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(460, Y_GROUND));
            beer2 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(430, Y_GROUND - 190));
            beer3 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(560, Y_GROUND - 190));
            beer4 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(1380, Y_GROUND - 190));
            beer5 = new Beer(Content.Load<Texture2D>("beer_outline"), new Vector2(1360, Y_GROUND));

            beers = new List<Beer>
            {
                beer1,
                beer2,
                beer3,
                beer4,
                beer5
            };
        }

        public void LoadBlocks()
        {
            block1 = new Block(Content.Load<Texture2D>("3_block"), new Vector2(230, Y_GROUND - 50));
            block2 = new Block(Content.Load<Texture2D>("5_block"), new Vector2(420, Y_GROUND - 150));
            block3 = new Block(Content.Load<Texture2D>("5_block"), new Vector2(950, Y_GROUND - 50));
            block4 = new Block(Content.Load<Texture2D>("3_block"), new Vector2(1300, Y_GROUND - 150));
            block5 = new Block(Content.Load<Texture2D>("3_block"), new Vector2(1900, Y_GROUND - 50));

            blocks = new List<Block>
            {
                block1,
                block2,
                block3,
                block4,
                block5
            };
        }

        public void LoadBackgrounds()
        {
            rusty = new Rusty(Content.Load<Texture2D>("deer_still"), new Vector2(20, Y_GROUND));

            heart1 = new OtherSprite(Content.Load<Texture2D>("final_heart"), new Vector2(700, 20));
            heart2 = new OtherSprite(Content.Load<Texture2D>("final_heart"), new Vector2(740, 20));

            scrolling1 = new Scrolling(Content.Load<Texture2D>("background0"), new Rectangle(0, 0, 800, 500));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("background1"), new Rectangle(SCREEN_WIDTH * 1, 0, 800, 500));
            scrolling3 = new Scrolling(Content.Load<Texture2D>("background2"), new Rectangle(SCREEN_WIDTH * 2, 0, 800, 500));

            Scrollings = new List<Scrolling>
            {
                scrolling1,
                scrolling2,
                scrolling3
            };
        }

        public void ReloadGame()
        {
            for (int i = 0; i < enemies.Count(); i++)
                enemies.RemoveAt(i);
            LoadBeers();
            LoadBlocks();
            LoadBackgrounds();
        }

        public static bool CheckInterval(float value, float lowBound, float highBound)
        {
            if (value >= lowBound && value <= highBound)
                return true;
            return false;
        }

        private void startTimer()
        {
            for (int i = 1; i <= 1000; i++)
                Timer -= i;
        }
    }
}