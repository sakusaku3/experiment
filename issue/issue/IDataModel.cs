using System;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reactive.Disposables;

namespace issue
{
    /// <summary>
    /// DataModel用のインターフェース
    /// PropertyChangedと入力検証の機能を提供する
    /// </summary>
    public interface IDataModel : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChangedの再定義
        /// (INotifyPropertyChangedのPropertyChangedを隠蔽する)
        /// </summary>
        new event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedEventHandler の取得
        /// </summary>
        PropertyChangedEventHandler PropertyChangedHandler { get; }
    }

    /// <summary>
    /// IDataModelインターフェイスについてPropertyChagedの拡張メソッド提供
    /// </summary>
    public static class IExtendedNotifyPropertyChangedFunctions
    {
        /// <summary>
        /// プロパティの変更の通知
        /// </summary>
        /// <param name="p_self">対象</param>
        /// <param name="targets">プロパティ変更通知対象の名称群</param>
		public static void OnPropertyChanged<TObject>(
            this TObject p_self
            , [CallerMemberName] string p_propertyName = null
            )
            where TObject : IDataModel
        {
            if (p_self == null) return;
            if (p_self.PropertyChangedHandler == null) return;
            p_self.PropertyChangedHandler(p_self, new PropertyChangedEventArgs(p_propertyName));
        }
    }

    /// <summary>
    /// INotifyPropertyChangedインターフェイスについて拡張メソッドを提供
    /// </summary>
    public static class INotifyPropertyChangedFunction
    {
		/// <summary>
		/// senderオブジェクトへ観察対象のプロパティを指定してlistenerオブジェクトのメソッドを登録する
		/// </summary>
		/// <param name="p_propertyName">観察対象のプロパティ</param>
		/// <param name="p_handler">通知時の実行メソッド</param>
		static public IDisposable RegistPropertyChangedObserver<TObject>(
            this TObject p_self,
			string p_propertyName,
			Action<TObject> p_handler)
			where TObject : INotifyPropertyChanged
		{
			//
			// 追加/解除対象のイベントハンドラーを用意しておく
			// このオブジェクトを追加/解除時で、同じものを利用しないと
			// senderオブジェクトから解除できずにイベントハンドラーが残ってしまう
			//
			PropertyChangedEventHandler l_handler =
				(sender, e) =>
				{ if (e.PropertyName == p_propertyName) { p_handler(p_self); } };

			// イベントハンドラーをsenderへ追加する
			p_self.PropertyChanged += l_handler;

			//
			// listenerが破棄される際に、PropertyChangedのチェーンを確実に解除するために
			// イベントハンドラーをsenderから解除するメソッドを隠蔽化した破棄対象オブジェクトを生成して返す
			// Disposeはlistenerに任せる
			//
			return Disposable.Create(() => p_self.PropertyChanged -= l_handler);
		}
    }
}

