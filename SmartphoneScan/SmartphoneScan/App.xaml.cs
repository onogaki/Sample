using SmartphoneScan.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartphoneScan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataItem>();

            var page = new NavigationPage(new View.TopPage());
            MainPage = page;
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=b2124dd1-f46b-439d-ac28-4073f68e2922;",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
