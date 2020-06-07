using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneScan.Services
{
    public interface IDataItem<T>
    {
        /// <summary>
        /// スキャンした商品情報を格納するリストを初期化
        /// </summary>
        /// <returns></returns>
        Task<bool> ItemListClearAsync();

        /// <summary>
        /// DBからの商品情報の取得
        /// </summary>
        /// <param name="plucode"></param>
        /// <returns></returns>
        Task<bool> GetItemInfoAsync(string plucode);

        /// <summary>
        /// 商品情報の追加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> AddItemAsync(T item);

        /// <summary>
        /// 商品情報の更新
        /// ※未使用
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(T item);

        /// <summary>
        /// 商品情報の削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(string id);

        /// <summary>
        /// 商品情報の取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetItemAsync(string id);

        /// <summary>
        /// 商品情報一覧の取得
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemListAsync(bool forceRefresh = false);
    }
}
