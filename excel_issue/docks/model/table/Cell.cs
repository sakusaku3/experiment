using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace docks.model.table
{
	/// <summary>
	/// テーブルのセルクラス
	/// </summary>
	public class Cell
	{
		/// <summary>
		/// 値
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// 行番号
		/// </summary>
		public int Row { get; set; }

		/// <summary>
		/// 列番号
		/// </summary>
		public int Column { get; set; }

		/// <summary>
		/// 高さ
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// 背景色
		/// </summary>
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="p_value">値</param>
		/// <param name="p_row">行番号</param>
		/// <param name="p_column">列番号</param>
		public Cell(string p_value, int p_row, int p_column) 
			: this(p_value, p_row, p_column, 1) { }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="p_value">値</param>
		/// <param name="p_row">行番号</param>
		/// <param name="p_column">列番号</param>
		/// <param name="p_height">高さ</param>
		public Cell(string p_value, int p_row, int p_column, int p_height)
		{
			this.Value = p_value;
			this.Row = p_row;
			this.Column = p_column;
			this.Height = p_height;
		}

		/// <summary>
		/// セルの最大行番号を返す
		/// </summary>
		/// <returns>セルの最大行番号</returns>
		public int GetLastRow()
		{
			return this.Row + this.Height - 1;
		}

		/// <summary>
		/// 指定されたインデックスの行番号を含んでいる
		/// </summary>
		/// <param name="p_rowIndex"></param>
		/// <returns>
		/// 指定されたインデックスの行番号を含んでいる:true, 
		/// 含んでいない:false
		/// </returns>
		public bool ContainsIndex(int p_rowIndex)
		{
			return this.Row <= p_rowIndex && 
				p_rowIndex <= this.GetLastRow();
		}

		/// <summary>
		/// セルのクローンを返す
		/// </summary>
		/// <param name="p_rowIndex">行インデックス</param>
		/// <returns>セルのクローン</returns>
		public Cell GetCellClone(int p_rowIndex)
		{
			return new Cell(this.Value, p_rowIndex, this.Column, 1);
		}
	}
}
