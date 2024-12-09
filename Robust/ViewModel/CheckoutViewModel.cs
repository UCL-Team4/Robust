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

namespace Robust.ViewModel.CheckoutViewModel
{
    public class CheckoutViewModel : ViewModelBase
    {      
        public CheckoutViewModel()
        {
            
        }

        public RelayCommand CheckoutCmd => new RelayCommand(Checkout);

        private void Checkout()
        {
            //if (ShoppingCartList != null)
            //{
            //    //The message should include an order number.
            //    MessageBox.Show("Tak for din bestilling!");
            //}
        }        
    }
}
