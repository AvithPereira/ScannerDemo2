using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ScannerDemo2.Models;
using Xamarin.Forms;

namespace ScannerDemo2.ViewModels
{
    public class ViewCartPageVM : BindableObject
    {
        private ObservableCollection<CartItem> _cartItems;

        public ObservableCollection<CartItem> CartItems
        { 
            get => _cartItems;
            set
            {
                if (_cartItems != value)
                {
                    _cartItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand OnRemoveItemCommand { get; }
        public ICommand OnUpdateItemCommand { get; }
        public ViewCartPageVM()
        {
            CartItems = CartItem.CartItemsList;
            OnRemoveItemCommand = new Command<CartItem>(async (item) => await OnRemoveItem(item));
            OnUpdateItemCommand = new Command<CartItem>(OnUpdateItem);
        }

        private void OnUpdateItem(CartItem item)
        {
            if (item != null)
            {
                item.Quantity++;
            }
        }

        private async Task OnRemoveItem(CartItem item)
        {
            if (item == null)
                return;

            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                bool confirm = await Application.Current.MainPage.DisplayAlert(
                    "Remove Item",
                    "Do you want to remove the item from the cart?",
                    "Yes",
                    "No"
                );

                if (confirm)
                {
                    CartItems.Remove(item);
                }
            }
        }
    }
}
