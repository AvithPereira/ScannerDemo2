using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScannerDemo2.Models
{
    public class CartItem : INotifyPropertyChanged
    {
        public static ObservableCollection<CartItem> CartItemsList { get; }

        static CartItem()
        {
            CartItemsList = new ObservableCollection<CartItem>();
        }

        private int _quantity;

        public string Barcode { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
