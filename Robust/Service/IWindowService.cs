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

namespace Robust.Service.Interface;

public interface IWindowService
{
    //The parameter should probably be removed when we implement the database.
    void ShowDialog();
}
