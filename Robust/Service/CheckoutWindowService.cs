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

public class CheckoutWindowService : IWindowService
{
    public void ShowDialog()
    {
        var dialog = new CheckoutWindow();
        dialog.ShowDialog();
    }
}
