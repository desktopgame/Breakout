using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
	/// <summary>
	/// 更新,描画可能なオブジェクトです.
	/// </summary>
	public interface IGameObject
	{
		/// <summary>
		/// このオブジェクトを更新します.
		/// </summary>
		/// <param name="gameTime"></param>
		void Update(GameTime gameTime);

		/// <summary>
		/// このオブジェクトを描画します.
		/// </summary>
		/// <param name="gameTime"></param>
		/// <param name="renderer"></param>
		void Draw(GameTime gameTime, Renderer renderer);
	}
}
