using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace SmartphoneScan.Droid
{
    [Activity(Label = "SmartphoneScan", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            AppCenter.Start("b2124dd1-f46b-439d-ac28-4073f68e2922",
                   typeof(Analytics), typeof(Crashes));

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // バーコード読み取り処理で必要
            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            LoadApplication(new App());
        }

        /// <summary>
        /// バーコード読み取り処理で必要
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}