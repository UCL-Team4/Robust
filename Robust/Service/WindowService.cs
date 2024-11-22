using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Robust.View;

namespace Robust.Service
{
    internal class WindowService : IWindowService
    {
        public void ShowDialog()
        {
            var dialog = new ShoppingCartWindow();

            dialog.ShowDialog();
        }
    }
}
