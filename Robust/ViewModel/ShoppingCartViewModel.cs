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
using Robust.Model.CartItem;
using Robust.Repositories;
using Robust.Repositories.Interface;

namespace Robust.ViewModel.ShoppingCart
{
    public class ShoppingCartViewModel : ViewModelBase
    {

        private CartRepository _cartRepository;
        private IWindowService _windowService;
        //This list is used to store the products currently in the shopping cart.
        public ObservableCollection<CartItem> ShoppingCartList { get; set; }
        
        //The UI doesn't update the total price properly - this needs to be fixed.
        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set 
            { 
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        private CartItem _selectedProduct;

        public CartItem SelectedProduct
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
            for (int i = 0; i < ShoppingCartList.Count; i++)
            {
                CartItem item = ShoppingCartList[i];
                TotalPrice += item.Price * item.Quantity;
            }
        }

        public RelayCommand ToCheckoutCmd => new RelayCommand(ShowCheckout, CanShowCheckout);

        private void ShowCheckout()
        {
            _windowService.ShowDialog();
        }

        private bool CanShowCheckout()
        {
            return ShoppingCartList != null && ShoppingCartList.Count > 0;
        }

        public RelayCommand DeleteSelectedProductCmd => new RelayCommand(DeleteSelectedProduct, CanDeleteSelectedProduct);

        private void DeleteSelectedProduct()
        {

            bool didDelete = _cartRepository.Delete(SelectedProduct.CartItemID);


            if (didDelete)
            {
                TotalPrice -= SelectedProduct.Price * SelectedProduct.Quantity;

                ShoppingCartList.Remove(SelectedProduct);
            }
        }

        private bool CanDeleteSelectedProduct() => SelectedProduct != null;

        public ShoppingCartViewModel() 
        {
            _cartRepository = new();
            ShoppingCartList = _cartRepository.GetAll();
            _windowService = new CheckoutWindowService();

            TotalPrice = 0;
            CalculateTotalPrice();
        }
    }
}
