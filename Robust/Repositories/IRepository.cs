using System.Collections.ObjectModel;
using Robust.Model.CartItem;
using Robust.Model.Product;
using Robust.Model.Customer;
using Robust.Model.Order;

namespace Robust.Repositories.Interface;

public interface IRepository
{
    public ObservableCollection<Product> GetAll(bool isPictogram = false);
    public void GetByID();
    public int Add(string filePath);
    public void Update();
    public void Delete();
}


public interface ICartRepository
{
    public bool Add(Product product, int customerId = 1);
    public ObservableCollection<CartItem> GetAll(int customerId = 1);
    public bool Update(CartItem cartItem, int quantity, int customerId = 1);
    public bool Delete(int cartItemId = 1);
}

public interface ICustomerRepository
{
    public Customer GetByID(int id);
}

public interface IUserRepository
{
    public int? Login(string email, string password);
}