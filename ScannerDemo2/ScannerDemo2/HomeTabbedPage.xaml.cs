using ScannerDemo2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScannerDemo2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : TabbedPage
    {
        private HomeTabbedPageVM ViewModel => BindingContext as HomeTabbedPageVM;
        public HomeTabbedPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ViewModel?.OnDisappearing();
            base.OnDisappearing();
        }
    }
}