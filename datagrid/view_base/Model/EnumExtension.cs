using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace view_base.Model
{
	[AttributeUsage(
		AttributeTargets.Field,
		Inherited = false,
		AllowMultiple = false)]
	public sealed class EnumNameAttribute : Attribute
	{
		public string Name { get; }

		public EnumNameAttribute(string name)
		{
			this.Name = name;
		}

		public EnumNameAttribute() { }
	}

	public static class EnumExtension
    {
        /// <summary>
        /// 特定の属性を取得する
        /// </summary>
        /// <typeparam name="TAttribute">属性型</typeparam>
        private static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            //リフレクションを用いて列挙体の型から情報を取得
            var fieldInfo = value.GetType().GetField(value.ToString());
            //指定した属性のリスト
            var attributes
                = fieldInfo.GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();
            //属性がなかった場合、空を返す
            if ((attributes?.Count() ?? 0) <= 0)
                return null;
            //同じ属性が複数含まれていても、最初のみ返す
            return attributes.First();
        }

        public static Dictionary<TObject, string> EnumNameDict<TObject>(this TObject p_enum) where TObject : struct, IComparable, IConvertible, IFormattable
        {
            var dict = new Dictionary<TObject, string>();
            foreach(var e in typeof(TObject).GetFields())
            {
                dict.Add((TObject)e.GetValue(p_enum), e.DisplayName());
            }
            return dict;
        }

        private static string DisplayName(this FieldInfo fi)
        {
            //指定した属性のリスト
            var attributes
                = fi.GetCustomAttributes(typeof(EnumNameAttribute), false)
                .Cast<EnumNameAttribute>();
            //属性がなかった場合、空を返す
            if ((attributes?.Count() ?? 0) <= 0)
                return null;
            //同じ属性が複数含まれていても、最初のみ返す
            return attributes.First().Name;
        }


        public static Dictionary<string, T> GetDict<T>() 
        {
			return Enum.
				GetValues(typeof(T)).
				Cast<T>().
				ToDictionary(x => x.DisplayName(), y => y);
		}

		public static string DisplayName(this object value)
        {
            return value.GetAttribute<EnumNameAttribute>()?.Name ?? "";
        }

        /// <summary>
        /// 特定の属性を取得する
        /// </summary>
        /// <typeparam name="TAttribute">属性型</typeparam>
        private static TAttribute GetAttribute<TAttribute>(this object value) where TAttribute : Attribute
        {
            //リフレクションを用いて列挙体の型から情報を取得
            var fieldInfo = value.GetType().GetField(value.ToString());
            //指定した属性のリスト
            var attributes
                = fieldInfo.GetCustomAttributes(typeof(TAttribute), false)
                .Cast<TAttribute>();
            //属性がなかった場合、空を返す
            if ((attributes?.Count() ?? 0) <= 0)
                return null;
            //同じ属性が複数含まれていても、最初のみ返す
            return attributes.First();
        }
    }
}
