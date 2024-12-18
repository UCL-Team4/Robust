﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Robust.Model.Product;
using Robust.View.ShoppingCart;
using Robust.ViewModel.ShoppingCart;
using Robust.ViewModel.ProductViewModel;
using Robust.Service.Interface;

namespace Robust.Service.ShoppingCart;

public class WindowService : IWindowService
{
    public void ShowDialog()
    {
        var dialog = new ShoppingCartWindow();
        dialog.ShowDialog();
    }
}
