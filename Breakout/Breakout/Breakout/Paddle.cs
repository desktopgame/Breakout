using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
	/// <summary>
	/// ユーザが操作可能なパドルです.
	/// </summary>
	public class Paddle : GameObject
	{
		private static readonly Vector2 PADDLE_SIZE = new Vector2(256, 32);
		private static readonly float SPEED = 10f;

		public Paddle() : base(PADDLE_SIZE)
		{
			this.Position = new Vector2(
				(Constants.SCREEN_SIZE.X - PADDLE_SIZE.X) / 2,
				(Constants.SCREEN_SIZE.Y - PADDLE_SIZE.Y)
			);
		}

		public override void Update(GameTime gameTime)
		{
			KeyboardState key = Keyboard.GetState();
			Vector2 vector = new Vector2(SPEED, 0);
			if(key.IsKeyDown(Keys.Left))
			{
				this.Position = Position - vector;
			}
			if(key.IsKeyDown(Keys.Right))
			{
				this.Position = Position + vector;
			}
			this.Position = Constants.Clamp(Position, Size);
		}

		public override void Draw(GameTime gameTime, Renderer renderer)
		{
			renderer.Draw("Paddle", Position, Color.White);
		}
	}
}
