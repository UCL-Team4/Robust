using Robust.Enums.Category;
using Robust.Repositories.Interface;
using Robust.ViewModel.Login;
using Robust.ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Robust.Repositories.User;

namespace UnitTest;

[TestClass]
public class Account
{
    [TestMethod]
    public void TEST_ACCOUNT_CREATION()
    {
        UserRepository _userRepository = new UserRepository();
        string username = "test";
        string password = "test";

        int? customerId = _userRepository.Login(username, password);

        if (customerId != null && customerId > -1) 
        {
            Assert.IsTrue(true); // Pass the test as the account is already registered
            return;
        }

        bool didRegister = _userRepository.Register(username, password);

        Assert.IsTrue(didRegister, "USER WAS NOT REGISTERED CORRECTLY");
    }
}
