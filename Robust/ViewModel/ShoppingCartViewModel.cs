using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;
using Robust.Service.Interface;
using Robust.Service.CheckOutWindow;
using Robust.ViewModel.RelayCommands;
using Robust.MVVM.ViewModelBase;

namespace Robust.ViewModel.ShoppingCart
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        private IWindowService _windowService;
        //This list is used to store the products currently in the shopping cart.
        public ObservableCollection<Product> ShoppingCartList { get; set; }
        
        //The UI doesn't update the total price properly - this needs to be fixed.
        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set 
            { 
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        //We should maybe include a property connected to Product called Quantity. Here we use StockQuantity as a measure of how many items of each Product there are.
        public void CalculateTotalPrice()
        {
            TotalPrice = 0;

            foreach (Product item in ShoppingCartList)
            {
                TotalPrice = TotalPrice + item.Price * item.StockQuantity;
            }
        }

        public RelayCommand ToCheckoutCmd => new RelayCommand(ShowCheckout, CanShowCheckout);

        private void ShowCheckout()
        {
            _windowService.ShowDialog(ShoppingCartList);
        }

        private bool CanShowCheckout()
        {
            return ShoppingCartList != null && ShoppingCartList.Count > 0;
        }

        public RelayCommand DeleteSelectedProductCmd => new RelayCommand(DeleteSelectedProduct, CanDeleteSelectedProduct);

        private void DeleteSelectedProduct()
        {
            ShoppingCartList.Remove(SelectedProduct);

            TotalPrice = 0;
        }

        private bool CanDeleteSelectedProduct() => SelectedProduct != null;

        public ShoppingCartViewModel(ObservableCollection<Product> list) 
        {
            ShoppingCartList = new ObservableCollection<Product>(list);
            _windowService = new CheckoutWindowService();

            CalculateTotalPrice();
        }
    }
}
