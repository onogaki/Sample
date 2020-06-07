using System;
using System.Collections.Generic;
using System.Text;

namespace SmartphoneScan.Library
{
    /// <summary>
    /// 画面表示用の共通処理
    /// </summary>
    public static class DisplayUtil
    {
        /// <summary>
        /// 数字を3桁カンマ区切りにして返す
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string convertNumToDisplay(string value)
        {
            if (value == string.Empty)
            {
                return null;
            }

            decimal longValue;
            if (!decimal.TryParse(value, out longValue))
            {
                return null;
            }

            return longValue.ToString("#,0");
        }
    }
}
