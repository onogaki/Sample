using SmartphoneScan.Constants;
using SmartphoneScan.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartphoneScan.Library
{
    public static class NaviUtil
    {
        public static void NaviDiscard(INavigation navi, AppConst.PageType pageType)
        {
            var page = typeof(TopPage);

            switch (pageType){
                case AppConst.PageType.QRRead:
                    page = typeof(ShoppingQRReadPage);
                    break;
                case AppConst.PageType.BarcodeRead:
                    page = typeof(ShoppingBarcodeReadPage);
                    break;
                default:
                    return;
            }

            foreach (var x in navi.NavigationStack.ToList())
            {
                if ((x.GetType() == page))
                {
                    navi.RemovePage(x);
                }
            }
        }
    }
}
