using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Robust.Model.Product;
using Robust.View;
using Robust.ViewModel;

namespace Robust.Service
{
    internal interface IWindowService
    {
        void ShowDialog(ObservableCollection<Product> list);
    }
}
