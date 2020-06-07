using SmartphoneScan.Constants;
using SmartphoneScan.Library;
using SmartphoneScan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartphoneScan.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingQRReadPage : ContentPage
    {
        private readonly ShoppingQRReadPageViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShoppingQRReadPage()
        {
            InitializeComponent();

            viewModel = new ShoppingQRReadPageViewModel();

            // スキャナーの設定
            QRScanner.IsScanning = true;
            QRScanner.IsAnalyzing = true;
            QRScanner.Options = new ZXing.Mobile.MobileBarcodeScanningOptions()
            {
                DelayBetweenContinuousScans = 2000
            };

            // スキャン時のイベント設定
            QRScanner.OnScanResult += QRScanner_OnScanResult;
        }

        /// <summary>
        /// スキャンイベント
        /// </summary>
        /// <param name="result"></param>
        private void QRScanner_OnScanResult(ZXing.Result result)
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    QRScanner.IsScanning = false;
                    QRScanner.IsAnalyzing = false;

                    // QRコード以外をスキャンした場合
                    if (result.BarcodeFormat != ZXing.BarcodeFormat.QR_CODE)
                    {
                        // メッセージ表示
                        await DisplayAlert("お知らせ", "QRコードをスキャンして下さい。", "OK");
                    }
                    else
                    {
                        // 読み込んだQRの情報をアプリケーション設定値に設定
                        viewModel.AppSetting(result.Text);

                        // カード画面に遷移
                        await Navigation.PushAsync(new ShoppingCartPage());

                        //foreach (var x in Navigation.NavigationStack.ToList())
                        //{
                        //    if ((x.GetType() == typeof(ShoppingQRReadPage)))
                        //    {
                        //        Navigation.RemovePage(x);
                        //    }
                        //}

                        //NaviUtil.NaviDiscard(Navigation, AppConst.PageType.QRRead);
                    }
                });
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        { 
            base.OnAppearing();
        }
    }
}