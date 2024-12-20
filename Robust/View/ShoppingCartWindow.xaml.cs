﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Robust.ViewModel;
using Robust.ViewModel.ProductViewModel;
using Robust.ViewModel.ShoppingCart;

namespace Robust.View.ShoppingCart;

/// <summary>
/// Interaction logic for ShoppingCartWindow.xaml
/// </summary>
public partial class ShoppingCartWindow : Window
{
    public ShoppingCartWindow()
    {
        InitializeComponent();
        DataContext = new ShoppingCartViewModel();
    }
}
