using SmartphoneScan.Constants;
using SmartphoneScan.Library;
using SmartphoneScan.Models;
using SmartphoneScan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SmartphoneScan.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingCartPage : ContentPage
	{
        private readonly ShoppingCartPageViewModel viewModel;
        private int tapCount = 0;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShoppingCartPage()
		{
			InitializeComponent();

            // ナビゲーションバーを非表示
            NavigationPage.SetHasNavigationBar(this, false);

            // 
            BindingContext = viewModel = new ShoppingCartPageViewModel();

        }

        /// <summary>
        /// 中止ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                // 中止メッセージ
                ShoppingStopMessage();

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 削除ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            var item = (TapGestureRecognizer)img.GestureRecognizers[0];
            var id = item.CommandParameter;

            // IDを指定し、内部で保持している商品情報から商品を削除
            viewModel.DeleteItem((string)id);
        }

        /// <summary>
        /// 削除ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        //{
        //    // 商品情報の一意のIDを取得
        //    PancakeView pancakeView = (PancakeView)sender;
        //    var item = (TapGestureRecognizer)pancakeView.GestureRecognizers[0];
        //    var id = item.CommandParameter;

        //    // IDを指定し、内部で保持している商品情報から商品を削除
        //    viewModel.DeleteItem((string)id);
        //}

        /// <summary>
        /// スキャンボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                // バーコードスキャン処理
                //NaviUtil.NaviDiscard(Navigation, AppConst.PageType.QRRead);
                //ScanBarcode(sender, e);

                //viewModel.ScanExcute();

                // スキャナページを破棄
                // ※破棄しないと、2度目の起動でエラーになる為
                NaviUtil.NaviDiscard(Navigation, AppConst.PageType.QRRead);
                NaviUtil.NaviDiscard(Navigation, AppConst.PageType.BarcodeRead);

                // スキャン画面から呼び出すイベントの生成
                Action<string> callback = CallBack;
                // スキャン画面に遷移
                Navigation.PushAsync(new ShoppingBarcodeReadPage(callback));
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// スキャン画面から呼び出すイベント
        /// </summary>
        /// <param name="task"></param>
        private void CallBack(string task)
        {
            // スキャンした商品情報を取得(画面に表示)
            viewModel.GetItemLIst();
        }

        /// <summary>
        /// 中止メッセージ
        /// </summary>
        async void ShoppingStopMessage()
        {
            var result = await DisplayAlert("お買い物中止", "お買い物を中止します。よろしいですか?", "はい", "いいえ");

            if (result)
            {
                // 内部で保持している商品情報をクリア
                viewModel.ItemListClear();

                // TOPページに戻る
                await Navigation.PushAsync(new TopPage());
            }
        }

        /// <summary>
        /// バーコードスキャン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="s"></param>
        async void ScanBarcode(object sender, EventArgs s)
        {
            var Options = new MobileBarcodeScanningOptions();
            Options.AutoRotate = true;

            var ScanPage = new ZXingScannerPage();
            ScanPage.DefaultOverlayTopText = "バーコードを読み取ります。";

            // スキャンページ表示
            await Navigation.PushAsync(ScanPage);

            // ナビゲーションを非表示
            NavigationPage.SetHasNavigationBar(this, false);

            // バーコードが読み取られると実施
            ScanPage.OnScanResult += (result) =>
            {
                // スキャンを停止
                ScanPage.IsScanning = false;

                // カート画面に戻る
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    viewModel.ScanExcute();
                });
            };
        }
    }
}