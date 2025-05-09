using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScannerDemo2.ViewModels
{
    public class LoginPageVM : BindableObject
    {
        private string _cashierId;
        private string _password;

        public string CashierId
        {
            get => _cashierId;
            set 
            {
                if ( _cashierId != value)
                {
                    _cashierId = value;
                    OnPropertyChanged();
                } 
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ValidateUserCommand { get; }

        public LoginPageVM()
        {
            ValidateUserCommand = new Command(async () => await ValidateUser()); 
        }

        private async Task ValidateUser()
        {
            if (string.IsNullOrWhiteSpace(CashierId) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            if (CashierId == "admin" && Password == "admin")
            {
                Application.Current.MainPage = new NavigationPage (new HomeFlyoutPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }

        


    }
}
