using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Breakout
{
	/// <summary>
	/// ブロックを行と列で管理するクラスです.
	/// </summary>
	public class BlockTable : IGameObject
	{
		/// <summary>
		/// 行数.
		/// </summary>
		public int RowCount
		{
			private set; get;
		}

		/// <summary>
		/// 列数.
		/// </summary>
		public int ColumnCount
		{
			private set; get;
		}

		/// <summary>
		/// 指定位置のブロックを返します.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public Block this[int row, int column]
		{
			get { return table[row, column]; }
		}

		private Block[,] table;

		public BlockTable(int rowCount, int columnCount)
		{
			this.RowCount = rowCount;
			this.ColumnCount = columnCount;
			this.table = new Block[rowCount, columnCount];
			for(int i=0; i<rowCount; i++)
			{
				for(int j=0; j<columnCount; j++)
				{
					Block block = new Block();
					block.Position = new Vector2(j * 64, i * 64);
					table[i, j] = block;
				}
			}
		}

		public void Update(GameTime gameTime)
		{
			ForEach((a) =>
			{
				a.Update(gameTime);
			});
		}

		public void Draw(GameTime gameTime, Renderer renderer)
		{
			ForEach((a) =>
			{
				a.Draw(gameTime, renderer);
			});
		}

		public void ForEach(Action<Block> a)
		{
			for(int i = 0; i < RowCount; i++)
			{
				for(int j = 0; j < ColumnCount; j++)
				{
					a(table[i, j]);
				}
			}
		}
	}
}
