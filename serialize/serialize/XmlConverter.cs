using System;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace serialize
{
    /// <summary>
    /// アプリケーション情報取得共通処理
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class XmlConverter
	{
		/// <summary>
		/// インスタンスをXML形式で保存する
		///
		/// 継承関係があってもタイプ指定必要なし
		/// </summary>
		/// <param name="p_obj">保存する先頭のオブジェクト</param>
		/// <returns>true: 成功, false: 失敗</returns>
		public static bool Save<T>(T p_obj, string p_filePath)
		{
			try
			{
				using (FileStream l_fs = new FileStream(p_filePath, FileMode.Create))
				{
					using (var l_xw =
						XmlWriter.Create(l_fs,
							new XmlWriterSettings { Indent = true, IndentChars = "\t" }))
					{
						var l_serializer = new NetDataContractSerializer();
						l_serializer.WriteObject(l_xw, p_obj);
					}
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// インスタンスをXML形式の文字列で保存する
		///
		/// 継承関係があってもタイプ指定必要なし
		/// </summary>
		/// <param name="p_obj">保存する先頭のオブジェクト</param>
		/// <param name="p_destString">XML形式の文字列</param>
		/// <returns>true: 成功, false: 失敗</returns>
		public static void SaveToMemory<T>(T p_src, out string p_destString)
		{
			p_destString = string.Empty;
			try
			{
				using (MemoryStream l_ms = new MemoryStream())
				{
					using (var l_xw =
						XmlWriter.Create(l_ms,
							new XmlWriterSettings { Indent = true, IndentChars = "\t" }))
					{
						var l_serializer = new NetDataContractSerializer();
						l_serializer.WriteObject(l_xw, p_src);
						l_xw.Flush();
						p_destString = Encoding.UTF8.GetString(l_ms.ToArray());
					}
				}
			}
			catch (Exception)
			{
				p_destString = string.Empty;
			}
		}

		/// <summary>
		/// XML形式で保存されたファイルからインスタンスを生成する
		///
		/// 継承関係があってもタイプ指定必要なし
		/// </summary>
		/// <param name="p_filePath">読み込むファイル名</param>
		/// <returns>ロードしたインスタンス。失敗時はnull</returns>
		public static T Load<T>(string p_filePath)
		{
			try
			{
				using (StreamReader l_sr = new StreamReader(p_filePath))
				{
					using (var l_xr = XmlReader.Create(l_sr, new XmlReaderSettings()))
					{
						var l_serializer = new NetDataContractSerializer();
						return (T)l_serializer.ReadObject(l_xr);
					}
				}
			}
			catch (Exception l_ex)
			{
                Console.WriteLine(l_ex);
				return default(T);
			}
		}

		/// <summary>
		/// XML形式の文字列からインスタンスを生成する
		///
		/// 継承関係があってもタイプ指定必要なし
		/// </summary>
		/// <param name="p_src">XML形式の文字列</param>
		/// <returns>ロードしたインスタンス。失敗時はnull</returns>
		public static T LoadFromMemory<T>(string p_src)
		{
			try
			{
				using (MemoryStream l_ms = new MemoryStream(Encoding.UTF8.GetBytes(p_src)))
				{
					using (var l_xr = XmlReader.Create(l_ms, new XmlReaderSettings()))
					{
						var l_serializer = new NetDataContractSerializer();
						return (T)l_serializer.ReadObject(l_xr);
					}
				}
			}
			catch (Exception)
			{
				return default(T);
			}
		}

		public static XElement ConvertCsvToXElement(
            IEnumerable<string[]> p_src, 
            string p_rootName, 
            string p_elementName
            )
        {
			var l_xRoot = new XElement(p_rootName);
			var l_elementNames = p_src.ElementAt(0);
			foreach (var s in p_src.Skip(1))
			{
				var l_xrecordElment = new XElement(p_elementName);
				foreach (var item in l_elementNames.Select((name, i) => new { name, i }))
				{
					if (string.IsNullOrEmpty(s[item.i])) continue;
					l_xrecordElment.Add(new XElement(item.name, s[item.i]));
				}
				l_xRoot.Add(l_xrecordElment);
			}
			return l_xRoot;
		}

		/// <summary>
		/// XML形式で保存されたファイルからインスタンスを生成する
		/// 
		/// 継承関係があってもタイプ指定必要なし
		/// </summary>
		/// <param name="p_filePath">読み込むファイル名</param>
		/// <returns>ロードしたインスタンス。失敗時はnull</returns>
		public static T Load<T>(XElement p_xelement)
		{
			try
			{
				var l_serializer = new DataContractSerializer(typeof(T));
				return (T)l_serializer.ReadObject(p_xelement.CreateReader());
			}
			catch (Exception)
			{
				return default(T);
			}
		}

		public static bool SaveMinimalXml<T>(T p_obj, string p_filePath)
		{
			try
			{
				using (FileStream l_fs = new FileStream(p_filePath, FileMode.Create))
				{
					using (var l_xw =
						XmlWriter.Create(l_fs,
							new XmlWriterSettings { Indent = true, IndentChars = "\t" }))
					{
						var l_serializer = new DataContractSerializer(typeof(T));
						l_serializer.WriteObject(l_xw, p_obj);
					}
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public static T LoadMinimalXml<T>(string p_filePath)
		{
			try
			{
				using (var l_sr = new StreamReader(p_filePath))
				using (var l_xr = XmlReader.Create(l_sr, new XmlReaderSettings()))
				{
					var l_serializer = new DataContractSerializer(typeof(T));
					return (T)l_serializer.ReadObject(l_xr);
				}
			}
			catch (Exception)
			{
				return default(T);
			}
		}
	}
}
