using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;
using Robust.Service;
using Robust.ViewModel.RelayCommands;

namespace Robust.ViewModel
{
    public class ShoppingCartViewModel
    {
        private IWindowService _windowService;
        public ObservableCollection<Product> ShoppingCartList { get; set; }
        public decimal TotalPrice { get; set; }
        
        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            
            foreach (Product item in ShoppingCartList)
            {
                total = total + item.Price;
            }

            return total;
        }

        public RelayCommand ToCheckoutCmd => new RelayCommand(ShowCheckout);

        private void ShowCheckout()
        {
            _windowService.ShowDialog(ShoppingCartList);
        }

        public ShoppingCartViewModel(ObservableCollection<Product> list) 
        {
            ShoppingCartList = new ObservableCollection<Product>(list);
            _windowService = new CheckoutWindowService();

            TotalPrice = CalculateTotalPrice();
        }
    }
}
