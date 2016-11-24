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

namespace Breakout
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Renderer renderer;

		private BlockTable table;
		private Paddle paddle;
		private Ball ball;
		private bool enterPressed;

		public Game1()
		{
			this.graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			Startup();
		}
		/// <summary>
		/// ステージの状態を初期化します.
		/// </summary>
		private void Startup()
		{
			this.paddle = new Paddle();
			this.table = new BlockTable(3, 10);
			this.ball = new Ball(table, paddle);
			this.enterPressed = false;
			ball.OnGameOver += ((src, e) => Startup());
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
			graphics.PreferredBackBufferWidth = 640;
			graphics.PreferredBackBufferHeight = 480;
			graphics.ApplyChanges();
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			this.spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			this.renderer = new Renderer(Content, spriteBatch);
			renderer.LoadTexture("Ball");
			renderer.LoadTexture("Block");
			renderer.LoadTexture("Paddle");
			renderer.LoadTexture("Start");
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
			// Allows the game to exit
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();
			KeyboardState keyState = Keyboard.GetState();
			if(keyState.IsKeyDown(Keys.Space) && !enterPressed)
			{
				ball.Vector = new Vector2(-5, -5);
				this.enterPressed = true;
			}
			// TODO: Add your update logic here
			table.Update(gameTime);
			paddle.Update(gameTime);
			ball.Update(gameTime);
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
			renderer.Begin();
			if(!enterPressed)
			{
				Vector2 size = new Vector2(346, 60);
				Vector2 position = (Constants.SCREEN_SIZE - size) / 2;
				renderer.Draw("Start", position, Color.White);
			}
			table.Draw(gameTime, renderer);
			paddle.Draw(gameTime, renderer);
			ball.Draw(gameTime, renderer);
			renderer.End();
			base.Draw(gameTime);
		}
	}
}
