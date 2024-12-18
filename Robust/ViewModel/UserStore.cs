using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robust.ViewModel.User;


// The usecase for UserStore is to store our username and password, then with every backend call we can verify users access to basket etc. based off this.
public static class UserStore
{
    public static string password { get; set; }
    public static string username { get; set; }
}
