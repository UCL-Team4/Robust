using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;
using Robust.View;
using Robust.ViewModel.CheckoutViewModel;
using Robust.Service.Interface;

namespace Robust.Service.CheckOutWindow;

internal class CheckoutWindowService : IWindowService
{
    public void ShowDialog(ObservableCollection<Product> list)
    {
        var dialog = new CheckoutWindow();
        dialog.DataContext = new CheckoutViewModel(list);
        dialog.ShowDialog();
    }
}
