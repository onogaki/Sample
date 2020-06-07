using SmartphoneScan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartphoneScan.Services
{
    public class DataItem : IDataItem<ItemContainer>
    {
        /// <summary>
        /// スキャンした商品情報を格納するリスト
        /// </summary>
        readonly List<ItemContainer> ItemList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataItem()
        {
            if (ItemList == null)
            {
                ItemList = new List<ItemContainer>();
            }
        }

        /// <summary>
        /// スキャンした商品情報を格納するリストを初期化
        /// </summary>
        public async Task<bool> ItemListClearAsync()
        {
            ItemList.Clear();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// DBから商品情報取得し、商品情報を格納しているリストに追加
        /// </summary>
        /// <param name="PluCode"></param>
        public async Task<bool> GetItemInfoAsync(string plucode)
        {
            var item = new ItemContainer();
            item.Id = Guid.NewGuid().ToString();
            item.PluCode = "1234567890123";
            item.ItemName = "明治フルーツ（１８０ミリリットル入り）";
            item.SalePrice = @"1,200";
            //var webImage = new UriImageSource
            //{
            //    Uri = new Uri("http://172.22.250.121:8101/applications/item.jpg")
            //};

            item.ImageUrl = "item.jpg";
            ItemList.Add(item);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// 商品情報の追加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> AddItemAsync(ItemContainer item)
        {
            // 追加処理
            ItemList.Add(item);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// 商品情報の更新
        /// ※未使用
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(ItemContainer item)
        {
            return await Task.FromResult(true);
        }

        /// <summary>
        /// 商品情報の削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItemAsync(string id)
        {
            // 削除対象の商品を取得
            var targetItem = ItemList.Where((ItemContainer arg) => arg.Id == id).FirstOrDefault();
            // 削除処理
            ItemList.Remove(targetItem);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// 商品情報の取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemContainer> GetItemAsync(string id)
        {
            // 対象の商品情報を取得
            var targetItem = ItemList.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(targetItem);
        }

        /// <summary>
        /// 商品情報一覧の取得
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemContainer>> GetItemListAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(ItemList);
        }
    }
}
