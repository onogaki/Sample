using SmartphoneScan.Constants;
using SmartphoneScan.Library;
using SmartphoneScan.Models;
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
	public partial class ShoppingBarcodeReadPage : ContentPage
	{
        private readonly ShoppingBarcodeReadPageViewModel viewModel;

        private Action<string> action;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="callback"></param>
        public ShoppingBarcodeReadPage (Action<string> callback)
		{
			InitializeComponent ();

            viewModel = new ShoppingBarcodeReadPageViewModel();

            // スキャナーの設定
            BarCodeScanner.IsScanning = true;
            BarCodeScanner.IsAnalyzing = true;
            BarCodeScanner.Options = new ZXing.Mobile.MobileBarcodeScanningOptions()
            {
                DelayBetweenContinuousScans = 2000
            };

            // スキャン時のイベント設定
            BarCodeScanner.OnScanResult += BarCodeScanner_OnScanResult;

            // カート画面のイベントを設定
            action = callback;
        }

        private void BarCodeScanner_OnScanResult(ZXing.Result result)
        {
            try
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
                    {
                        await DisplayAlert("お知らせ", "バーコードをスキャンして下さい。", "OK");
                    }
                    else
                    {
                        await DisplayAlert("お知らせ", "スキャンしました。", "OK");

                        viewModel.ScanContinuousExcute(result.Text);
                    }
                });



                //// バーコード以外をスキャンした場合
                //if (result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
                //{
                //    // メッセージ表示
                //    Device.BeginInvokeOnMainThread(async () =>
                //    {
                //        await DisplayAlert("お知らせ", "バーコードをスキャンして下さい。", "OK");
                //    });

                //    return;
                //}

                //viewModel.ScanContinuousExcute(result.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // カート画面のイベントを実行
                action("ScanFinish");

                // カート画面に遷移
                await Navigation.PopAsync();
            });
        }
    }
}