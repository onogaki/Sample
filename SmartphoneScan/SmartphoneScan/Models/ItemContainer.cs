using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartphoneScan.Models
{
    public class ItemContainer
    {
        /// <summary>
        /// 内部で採番される商品情報の一意のID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// PLUコード
        /// </summary>
        public string PluCode { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 売価価格
        /// </summary>
        public string SalePrice { get; set; }

        /// <summary>
        /// 商品画像URL
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
