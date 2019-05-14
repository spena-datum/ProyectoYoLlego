using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace YoLlegoApp.ViewModel
{
    class PrincipalViewModel: INotifyPropertyChanged
    {
        //public Command ScanQR { get; set; }

        //public PrincipalViewModel()
        //{
        //    Scanner();
        //}

        //private async void Scanner()
        //{

        //    var scannerPage = new ZXingScannerPage();

        //    scannerPage.Title = "Lector de QR";
        //    scannerPage.OnScanResult += (result) =>
        //    {
        //        scannerPage.IsScanning = false;

        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            Application.Current.MainPage.Navigation.PopAsync();
        //            //DisplayAlert("Valor Obtenido", result.Text, "OK");
        //            Application.Current.MainPage.DisplayAlert("Su asistencia ha sido registrada", result.Text, "OK");
        //        });
        //    };

        //    await Application.Current.MainPage.Navigation.PushAsync(scannerPage);
        //}

        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand ButtonCommand { get; private set; }

        public PrincipalViewModel()
        {
            ButtonCommand = new Command(OnButtomCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnButtomCommand()
        {
            var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_128,
                BarcodeFormat.EAN_13
            };
            var page = new ZXingScannerPage(options) { Title = "Scanner" };
            var closeItem = new ToolbarItem { Text = "Close" };
            closeItem.Clicked += (object sender, EventArgs e) =>
            {
                page.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                });
            };
            page.ToolbarItems.Add(closeItem);

            page.OnScanResult += (result) =>
            {
                page.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                    if (string.IsNullOrEmpty(result.Text))
                    {
                        Result = "No valid code has been scanned";
                    }
                    else
                    {
                        Result = $"Result: {result.Text}";
                    }
                });
            };
            Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page) { BarTextColor = Color.White, BarBackgroundColor = Color.CadetBlue }, true);
        }
    }
}
