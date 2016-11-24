using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
	/// <summary>
	/// 定数クラスです.
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// 画面サイズ.
		/// </summary>
		public static readonly Vector2 SCREEN_SIZE = new Vector2(640, 480);

		/// <summary>
		/// 指定の位置,大きさを持つオブジェクトの位置をはみださないようにします.
		/// </summary>
		/// <param name="position"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		public static Vector2 Clamp(Vector2 position, Vector2 size)
		{
			return Vector2.Clamp(position, Vector2.Zero, new Vector2(SCREEN_SIZE.X - size.X, SCREEN_SIZE.Y - size.Y));
		}
	}
}
