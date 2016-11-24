using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
	public static class CollisionSystem
	{
		/// <summary>
		/// ウィンドウ範囲を表す矩形を返します.
		/// </summary>
		/// <returns></returns>
		public static Rectangle GetWindowRect()
		{
			return new Rectangle(
				0,
				0,
				(int)Constants.SCREEN_SIZE.X,
				(int)Constants.SCREEN_SIZE.Y
			);
		}

		/// <summary>
		/// 指定のオブジェクトの位置と大きさで表される範囲を矩形で返します.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Rectangle ToRectangle(GameObject a)
		{
			return new Rectangle(
				(int)a.Position.X,
				(int)a.Position.Y,
				(int)a.Size.X,
				(int)a.Size.Y
			);
		}

		/// <summary>
		/// 指定のオブジェクトの矩形の左半分を返します.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Rectangle ToLeftRectangle(GameObject a)
		{
			Rectangle aR = ToRectangle(a);
			aR.Width /= 2;
			return aR;
		}

		/// <summary>
		/// 指定のオブジェクトの矩形の右半分を返します.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Rectangle ToRightRectangle(GameObject a)
		{
			Rectangle aR = ToRectangle(a);
			aR.X += (aR.Width / 2);
			aR.Width /= 2;
			return aR;
		}

		/// <summary>
		/// ウィンドウと水平/垂直方向で衝突しているならtrue.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static bool CollisionToWindow(GameObject a)
		{
			return CollisionToWindowByHorizontal(a) || CollisionToWindowByVertical(a);
		}

		/// <summary>
		/// ウィンドウと水平方向で衝突しているならtrue.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static bool CollisionToWindowByHorizontal(GameObject a)
		{
			float x = a.Position.X;
			float y = a.Position.Y;
			float w = a.Size.X;
			float h = a.Size.Y;
			Vector2 scrSize = Constants.SCREEN_SIZE;
			//左端で衝突
			if(x < 0)
			{
				return true;
				//右端で衝突
			} else if((x + w) >= scrSize.X)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// ウィンドウと垂直方向で衝突しているならtrue.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static bool CollisionToWindowByVertical(GameObject a)
		{
			float x = a.Position.X;
			float y = a.Position.Y;
			float w = a.Size.X;
			float h = a.Size.Y;
			Vector2 scrSize = Constants.SCREEN_SIZE;
			//上端で衝突
			if(y < 0)
			{
				return true;
			//下端で衝突
			} else if((y + h) >= scrSize.Y)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// 二つのオブジェクトの矩形としての衝突を検証します.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool Intersects(GameObject a, GameObject b)
		{
			Rectangle aR = ToRectangle(a);
			Rectangle bR = ToRectangle(b);
			return aR.Intersects(bR);
		}
	}
}
