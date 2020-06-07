using System;
using System.Collections.Generic;
using System.Text;

namespace SmartphoneScan.ViewModel
{
    public class HeaderPageViewModel : BaseViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HeaderPageViewModel(string companyName, string storeName)
        {
            CompanyName = companyName == null ? "SmartphoneScan" : companyName;
            StoreName = storeName == null ? "" : storeName;
            HeaderStoreName = CompanyName + " " + StoreName;
        }
    }
}
