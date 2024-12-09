using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;
using Robust.Service.Interface;
using Robust.View;

namespace Robust.Service.Login;

public class LoginWindowService : IWindowService
{
    public void ShowDialog()
    {
        var dialog = new LoginWindow();
        dialog.ShowDialog();
    }
}
