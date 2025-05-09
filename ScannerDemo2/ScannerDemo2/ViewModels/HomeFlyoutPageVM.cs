using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ScannerDemo2.Models;
using Xamarin.Forms;

namespace ScannerDemo2.ViewModels
{
    public class HomeFlyoutPageVM: BindableObject
    {
        private FlyoutMenuItem _selectedMenuItem;
        public ObservableCollection<FlyoutMenuItem> MenuItems { get; set; }

        public FlyoutMenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                if (_selectedMenuItem != value)
                {
                    _selectedMenuItem = value;
                    OnPropertyChanged();
                    OnMenuItemSelected();
                } 
            }
        }

        public HomeFlyoutPageVM()
        {
            MenuItems = InitializeMenuItems();
        }

        private ObservableCollection<FlyoutMenuItem> InitializeMenuItems()
        {
            return new ObservableCollection<FlyoutMenuItem>
            {
                new FlyoutMenuItem { Id = 0, MenuName = "Logout", TargetPage = typeof(LoginPage) }
            };
        }

        private async void OnMenuItemSelected()
        {
            if (SelectedMenuItem == null)
                return;

            var page = (Page)Activator.CreateInstance(SelectedMenuItem.TargetPage);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

    }
}
