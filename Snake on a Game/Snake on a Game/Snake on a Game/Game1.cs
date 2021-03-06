using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Snake_on_a_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Vector2>snake=new List<Vector2>();
        Texture2D snakeTexture, foodTexture;
        Vector2 Direction = new Vector2(0, 1);
        Vector2 Food = new Vector2(10, 10);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            snakeTexture = Content.Load<Texture2D>(@"square");
            foodTexture = Content.Load<Texture2D>("becin");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            snake.Add(new Vector2(3, 3));
            snake.Add(new Vector2(3, 4));
            snake.Add(new Vector2(3, 5));
            snake.Add(new Vector2(3, 6));
            snake.Add(new Vector2(3, 7));

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            
            

            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Left))
            {
                Direction = new Vector2 (-1, 0);
            }

            if (kb.IsKeyDown(Keys.Right))
            {
                Direction = new Vector2 (1, 0);
            }

            if (kb.IsKeyDown(Keys.Up))
            {
                Direction = new Vector2 (0, -1);
            }

            if (kb.IsKeyDown(Keys.Down))
            {
                Direction = new Vector2(0, 1);
            }



            for (int i = snake.Count-1; i > 0; i--)
            {
                snake[i] = snake[i - 1];
            }
    
            snake[0] += Direction;



            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();

            for (int i = 0; i < snake.Count; i++)
            {
                spriteBatch.Draw(snakeTexture, new Rectangle((int)snake[i].X * 20,
                                                             (int)snake[i].Y * 20, 20, 20),
                                               new Rectangle(0, 0, snakeTexture.Width,
                                                                 snakeTexture.Height),
                                                                 Color.Orange);
            }

            spriteBatch.Draw(foodTexture, new Rectangle((int)Food.X * 20, (int)Food.Y * 20, 20, 20), new Rectangle(4,256,22,15), Color.White);

            spriteBatch.End();
        }
    }
}
