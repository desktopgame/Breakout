using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Breakout
{
	/// <summary>
	/// ステージを構成するブロック.
	/// </summary>
	public class Block : GameObject
	{
		private static readonly Vector2 BLOCK_SIZE = new Vector2(64, 64);

		/// <summary>
		/// このブロックが破壊されているならtrue.
		/// </summary>
		public bool IsDestroy {
			set; get;
		}

		public Block() : base(BLOCK_SIZE)
		{
			this.IsDestroy = false;
		}

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(GameTime gameTime, Renderer renderer)
		{
			if(IsDestroy)
			{
				return;
			}
			renderer.Draw("Block", Position, Color.White);
		}
	}
}
