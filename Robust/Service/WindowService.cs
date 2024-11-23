﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Robust.Model.Product;
using Robust.View;
using Robust.ViewModel;
using Robust.ViewModel.ProductViewModel;

namespace Robust.Service
{
    internal class WindowService : IWindowService
    {
        public void ShowDialog(ObservableCollection<Product> list)
        {
            var dialog = new ShoppingCartWindow();
            dialog.DataContext = new ShoppingCartViewModel(list);
            dialog.ShowDialog();
        }
    }
}
