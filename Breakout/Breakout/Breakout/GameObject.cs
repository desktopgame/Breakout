using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout
{
	/// <summary>
	/// ゲーム上で描画されるなんらかのオブジェクト.
	/// </summary>
	public abstract class GameObject : IGameObject
	{
		public Vector2 Position
		{
			set; get;
		}

		public Vector2 Size
		{
			private set; get;
		}

		public GameObject(Vector2 size)
		{
			this.Size = size;
		}

		public abstract void Update(GameTime gameTime);

		public abstract void Draw(GameTime gameTime, Renderer renderer);

		/// <summary>
		/// 二つのオブジェクトが衝突するならtrue.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Intersects(GameObject other)
		{
			return CollisionSystem.Intersects(this, other);
		}
		
	}
}
