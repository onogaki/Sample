using SmartphoneScan.Library;
using SmartphoneScan.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneScan.ViewModel
{
    public class ShoppingBarcodeReadPageViewModel : BaseViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShoppingBarcodeReadPageViewModel()
        {

        }

        /// <summary>
        /// スキャン処理(連続用)
        /// </summary>
        public async void ScanContinuousExcute(string plucode)
        {
            // PluCodeを元にDBから商品情報を取得し、内部で保持している商品情報一覧に追加
            var ret = await ItemMethod.GetItemInfoAsync(plucode);
        }
    }
}
