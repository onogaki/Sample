using SmartphoneScan.Constants;
using SmartphoneScan.Library;
using SmartphoneScan.Models;
using SmartphoneScan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartphoneScan.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopPage : ContentPage
	{
		public TopPage ()
		{
			InitializeComponent ();

            // ナビゲーションバーを非表示
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnQRScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                // スキャナページを破棄
                // ※破棄しないと、2度目の起動でエラーになる為
                NaviUtil.NaviDiscard(Navigation, AppConst.PageType.QRRead);
                NaviUtil.NaviDiscard(Navigation, AppConst.PageType.BarcodeRead);

                //AppDataContainer.CompanyName = "Beisia 新座店";
                //Navigation.PushAsync(new ShoppingCartPage());
                Navigation.PushAsync(new ShoppingQRReadPage());
                //Navigation.PushAsync(new ShoppingBarcodeReadPage());
            }
            catch (Exception ex)
            {

            }
        }
    }
}