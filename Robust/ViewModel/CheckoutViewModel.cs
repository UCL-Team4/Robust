using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;

namespace Robust.ViewModel
{
    internal class CheckoutViewModel
    {
        public ObservableCollection<Product> ShoppingCartList { get; set; }
        
        public CheckoutViewModel(ObservableCollection<Product> list)
        {
            ShoppingCartList = new ObservableCollection<Product>(list);
        }
    }
}
