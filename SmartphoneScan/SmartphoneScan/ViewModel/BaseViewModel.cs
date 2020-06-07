using SmartphoneScan.Models;
using SmartphoneScan.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SmartphoneScan.ViewModel
{
    /// <summary>
    /// 画面共通のViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataItem<ItemContainer> ItemMethod => DependencyService.Get<IDataItem<ItemContainer>>();

        // 画面表示用の商品情報を格納するコレクション(全画面で共有)
        public ObservableCollection<ItemContainer> ItemList { get; set; }

        /// <summary>
        /// 企業名の取得＆設定
        /// </summary>
        string companyName = string.Empty;
        public string CompanyName
        {
            get { return companyName; }
            set { SetProperty(ref companyName, value); }
        }

        /// <summary>
        /// 店舗名の取得＆設定
        /// </summary>
        string storeName = string.Empty;
        public string StoreName
        {
            get { return storeName; }
            set { SetProperty(ref storeName, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        string headerStoreName = string.Empty;
        public string HeaderStoreName
        {
            get { return headerStoreName; }
            set { SetProperty(ref headerStoreName, value); }
        }

        /// <summary>
        /// 商品点数
        /// </summary>
        string productPoint = string.Empty;
        public string ProductPoint
        {
            get { return productPoint; }
            set { SetProperty(ref productPoint, value); }
        }

        /// <summary>
        /// 売上合計
        /// </summary>
        string totalSales = string.Empty;
        public string TotalSales
        {
            get { return totalSales; }
            set { SetProperty(ref totalSales, value); }
        }

        /// <summary>
        /// プロパティ設定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// プロパティ設定処理
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
