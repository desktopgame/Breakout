using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Breakout
{
	/// <summary>
	/// 画面上で跳ね回るボールです.
	/// </summary>
	public class Ball : GameObject
	{
		private static readonly Vector2 BALL_SIZE = new Vector2(32, 32);
		private static readonly Vector2 GRAVITY = new Vector2(0, 2f);
		/// <summary>
		/// ボールが下方向にはみでたとき通知します.
		/// </summary>
		public event EventHandler OnGameOver;

		/// <summary>
		/// ボールの進行方向です.
		/// </summary>
		public Vector2 Vector
		{
			set; get;
		}

		private BlockTable table;
		private Paddle paddle;

		public Ball(BlockTable table, Paddle paddle) : base(BALL_SIZE)
		{
			this.table = table;
			this.paddle = paddle;
			this.Vector = Vector2.Zero;
			this.Position = paddle.Position + new Vector2(paddle.Size.X / 2, -paddle.Size.Y);
		}

		public override void Update(GameTime gameTime)
		{
			//ウィンドウ下端をはみ出ているか検査
			if((Position.Y + Size.Y) >= Constants.SCREEN_SIZE.Y)
			{
				OnGameOver?.Invoke(this, EventArgs.Empty);
				return;
			}
			//ウィンドウ端との衝突
			ReflectFromWindow();
			//ブロックとの衝突
			ReflectFromBlocks();
			//パドルとの衝突
			if(paddle.Intersects(this))
			{
				ReflectFromPaddle();
			}
			this.Position += Vector;
		//	this.Position = Constants.Clamp(Position, Size);
		}

		private void ReflectFromWindow()
		{
			if(!CollisionSystem.CollisionToWindow(this))
			{
				return;
			}
			Vector2 v = CollisionSystem.CollisionToWindowByHorizontal(this) ? new Vector2(-1, 1) : new Vector2(-1, -1);
			this.Vector = Vector * v;
		}

		private void ReflectFromBlocks()
		{
			//ブロックテーブルの最下層に到達していなければ以降の判定をスキップ
			float baseLine = table.RowCount * 64;
			if(Position.Y > baseLine)
			{
				return;
			}
			//全てのブロックとのあたり判定を検証
			for(int i=0; i<table.RowCount; i++)
			{
				//この行に敷き詰められるブロック矩形
				//Rectangle lineRect = new Rectangle(0, (i * 64), 64, 64);
				////それと衝突しなければ以降の判定をスキップ
				//if(!lineRect.Intersects(CollisionSystem.ToRectangle(this)))
				//{
				//	continue;
				//}
				for(int j=0; j<table.ColumnCount; j++)
				{
					Block block = table[i, j];
					if(block.IsDestroy || !block.Intersects(this))
					{
						//衝突していない
						continue;
					}
					ReflectFromBlock(i, j, table[i, j]);
					goto END;
				}
			}
			END:;
		}

		private void ReflectFromBlock(int row, int column, Block block)
		{
			ReflectFrom(block);
			block.IsDestroy = true;
		}

		private void ReflectFromPaddle()
		{
			ReflectFrom(paddle);
		}
		
		private void ReflectFrom(GameObject a)
		{
			Rectangle left = CollisionSystem.ToLeftRectangle(a);
			Vector2 reflect = new Vector2(1, -1);
			//左側で衝突
			if(left.Intersects(CollisionSystem.ToRectangle(this)))
			{
				//常に左
				if(Vector.X > 0)
				{
					reflect.X = -1f;
				}
				//右側で衝突
			} else
			{
				//常に右
				if(Vector.X < 0)
				{
					reflect.X = -1f;
				}
			}
			this.Vector = Vector * reflect;
		}

		public override void Draw(GameTime gameTime, Renderer renderer)
		{
			renderer.Draw("Ball", Position, Color.White);
		}
	}
}
