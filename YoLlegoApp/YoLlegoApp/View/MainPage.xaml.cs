using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//using ZXing.Net.Mobile.Forms;

namespace YoLlegoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //private async void Scan_Clicked(object sender, EventArgs e)
        //{
        //    var scan = new ZXingScannerPage();
        //    await Navigation.PushAsync(scan);
        //    scan.OnScanResult += (result) =>
        //    {
        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            await Navigation.PopAsync();
        //            myCode.Text = result.Text;
        //        });
        //    };
        //}

    }
}
