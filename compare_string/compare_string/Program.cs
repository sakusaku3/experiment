using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compare_string
{
    class Program
    {
        /// <summary>
        /// 比較データ(名称比較に使用)
        /// </summary>
        private static readonly CompareInfo compareInfo = CultureInfo.CurrentCulture.CompareInfo;

        /// <summary>
        /// 名称比較(大文字小文字を区別しない)
        /// </summary>
        private static readonly Func<string, string, bool> isEqualNames =
            (x, y) => compareInfo.Compare(x, y, CompareOptions.IgnoreWidth) == 0;

        static void Main(string[] args)
        {
            Console.WriteLine(isEqualNames("アアア", "ｱｱｱ"));
            Console.Read();
        }
    }
}
