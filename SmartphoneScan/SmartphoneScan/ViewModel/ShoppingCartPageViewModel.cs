using SmartphoneScan.Library;
using SmartphoneScan.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartphoneScan.ViewModel
{
    /// <summary>
    /// カート画面用のViewModel
    /// </summary>
    public class ShoppingCartPageViewModel : BaseViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShoppingCartPageViewModel()
        {
            // 画面表示用の商品情報を格納するコレクションの初期化
            ItemList = new ObservableCollection<ItemContainer>();
        }

        /// <summary>
        /// 内部で保持している商品情報をクリア
        /// </summary>
        public async void ItemListClear()
        {
            var ret = await ItemMethod.ItemListClearAsync();
        }

        /// <summary>
        /// スキャン処理
        /// </summary>
        public async void ScanExcute()
        {
            // PluCodeを元にDBから商品情報を取得し、内部で保持している商品情報一覧に追加
            var ret = await ItemMethod.GetItemInfoAsync("");
            
            // 内部で保持している商品情報一覧を取得
            await GetItemList();
        }

        /// <summary>
        /// 商品削除
        /// </summary>
        /// <param name="id"></param>
        public async void DeleteItem(string id)
        {
            // IDをに該当する商品を、内部で保持している商品情報から削除
            var ret = await ItemMethod.DeleteItemAsync(id);
            
            // 削除後の商品情報一覧を取得
            await GetItemList();
        }

        /// <summary>
        /// 商品情報一覧取得
        /// </summary>
        public async void GetItemLIst()
        {
            // 内部で保持している商品情報一覧を取得
            await GetItemList();
        }

        /// <summary>
        /// 商品情報一覧取得
        /// </summary>
        /// <returns></returns>
        async Task GetItemList()
        {
            // 商品情報一覧を取得
            var targetItemList = await ItemMethod.GetItemListAsync(true);

            // 初期化
            ItemList.Clear();
            ProductPoint = string.Empty;
            TotalSales = string.Empty;

            // 取得した商品を画面表示用のコレクションに追加＆合計金額を取得
            decimal totalSales = 0;
            foreach (var item in targetItemList)
            {
                totalSales += Convert.ToDecimal(item.SalePrice);
                ItemList.Add(item);
            }

            // 商品点数を設定
            ProductPoint = ItemList.Count.ToString();

            // 合計金額を設定
            TotalSales = DisplayUtil.convertNumToDisplay(totalSales.ToString());
        }
    }
}
