using System;
using System.Linq;
using System.Windows.Input;
using ScannerDemo2.Models;
using Xamarin.Forms;

namespace ScannerDemo2.ViewModels
{
    public class HomeTabbedPageVM: BindableObject
    {
        private bool _isScanning = true;
        private bool _isEnabled = true;
        
        public bool IsScanning
        {
            get => _isScanning;
            set
            {
                if (_isScanning != value) 
                {
                    _isScanning = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged();
                }             
            }
        }

        public ICommand OnScanCommand { get; }
        public HomeTabbedPageVM()
        {
            OnScanCommand = new Command<ZXing.Result>(OnScan);
        }

        public void OnAppearing()
        {
            IsScanning = true;
            IsEnabled = true;
        }

        public void OnDisappearing()
        {
            IsScanning = false;
            IsEnabled = false;
        }

        private void OnScan(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    //Check if the scanned item already exists in the cart
                    var existingItem = CartItem.CartItemsList.FirstOrDefault(x => x.Barcode == result.Text);
                    if (existingItem != null)
                    {
                        existingItem.Quantity++;
                        await Application.Current.MainPage.DisplayAlert("Item Updated", $"The item quantity has been updated to {existingItem.Quantity}.", "OK");
                    }
                    else
                    {
                        CartItem.CartItemsList.Add(new CartItem
                        {
                            Barcode = result.Text,
                            Quantity = 1
                        });
                        await Application.Current.MainPage.DisplayAlert("Item Added", "The item has been added to your cart.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }
            });
        }
    }
}
