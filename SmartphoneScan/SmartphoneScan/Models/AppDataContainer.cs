using System;
using System.Collections.Generic;
using System.Text;

namespace SmartphoneScan.Models
{
    /// <summary>
    /// アプリケーション内で共有するデータ
    /// </summary>
    static class AppDataContainer
    {
        /// <summary>
        /// 企業名
        /// </summary>
        public static string CompanyName { get; set; }

        /// <summary>
        /// 店舗名
        /// </summary>
        public static string StoreName { get; set; }

        /// <summary>
        /// APIのURL
        /// </summary>
        public static string ApiUrl { get; set; }
    }
}
