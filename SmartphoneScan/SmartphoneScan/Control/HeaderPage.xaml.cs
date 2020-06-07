using SmartphoneScan.Models;
using SmartphoneScan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartphoneScan.Control
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderPage : ContentView
	{
        private readonly HeaderPageViewModel viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HeaderPage ()
		{
            try
            {
                InitializeComponent();

                // ヘダーに企業名、店舗名を表示
                BindingContext = viewModel = new HeaderPageViewModel(AppDataContainer.CompanyName, AppDataContainer.StoreName);
            }
            catch(Exception ex)
            {

            }

        }
	}
}