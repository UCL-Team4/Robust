using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;
using Robust.Service.Interface;
using Robust.View;
using Robust.View.ShoppingCart;
using Robust.ViewModel.ShoppingCart;

namespace Robust.Service.PictogramSheet
{
    internal class PictogramSheetService : IWindowService
    {
        public void ShowDialog(ObservableCollection<Product> list)
        {
            var dialog = new PictogramSheetWindow();
            //dialog.DataContext = new ShoppingCartViewModel(list);
            dialog.ShowDialog();
        }
    }
}
