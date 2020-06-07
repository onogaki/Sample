using SmartphoneScan.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartphoneScan.ViewModel
{
    public class ShoppingQRReadPageViewModel : BaseViewModel
    {
        public ShoppingQRReadPageViewModel()
        {

        }

        /// <summary>
        /// アプリケーション設定値の設定
        /// </summary>
        /// <param name="QRInfo"></param>
        public void AppSetting(string QRInfo)
        {
            // QRで読み込んだ情報を格納
            string[] info = QRInfo.Split(',');

            // 企業名
            AppDataContainer.CompanyName = info[0];
            // 店舗名
            AppDataContainer.StoreName = info[1];
            // APIのURL
            AppDataContainer.ApiUrl = info[2];
        }
    }
}
