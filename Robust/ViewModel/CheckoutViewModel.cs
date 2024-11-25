using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Robust.Model.Product;
using Robust.MVVM.ViewModelBase;
using Robust.ViewModel.RelayCommands;

namespace Robust.ViewModel
{
    internal class CheckoutViewModel : ViewModelBase
    {
        //This list is used to store the products currently in the shopping cart.
        public ObservableCollection<Product> ShoppingCartList { get; set; }
        
        public CheckoutViewModel(ObservableCollection<Product> list)
        {
            ShoppingCartList = new ObservableCollection<Product>(list);
        }

        public RelayCommand CheckoutCmd => new RelayCommand(Checkout);

        private void Checkout()
        {
            if (ShoppingCartList != null)
            {
                //The message should include an order number.
                MessageBox.Show("Tak for din bestilling!");
            }
        }        
    }
}
