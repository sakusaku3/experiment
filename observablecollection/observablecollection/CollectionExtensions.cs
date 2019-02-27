using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observablecollection
{
    static public class CollectionExtensions
    {
      		/// <summary>
		/// ソート拡張
		/// </summary>
		/// <typeparam name="T">ソート対象のオブジェクトタイプ</typeparam>
		/// <typeparam name="TKey">ソート対象オブジェクトの比較項目タイプ</typeparam>
		/// <param name="p_src">ソート対象コレクション</param>
		/// <param name="p_selector">比較項目指定デリゲート</param>
		public static void Sort<T, TKey>(
			this System.Collections.IList p_src,
			Func<T, TKey> p_selector
			) where TKey : IComparable
		{
			var l_comparer = Comparer<T>.Create((a, b) => p_selector(a).CompareTo(p_selector(b)));
			System.Collections.ArrayList.Adapter(p_src).Sort(l_comparer);
		}

    }
}
