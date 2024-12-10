using System.Collections.ObjectModel;
using Robust.Model.CartItem;
using Robust.Model.Product;

namespace Robust.Repositories.Interface;

public interface IRepository
{
    public ObservableCollection<Product> GetAll(bool isPictogram = false);
    public void GetByID();
    public void Add();
    public void Update();
    public void Delete();
}


public interface ICartRepository
{
    public bool Add(Product product, int customerId = 1);
    public ObservableCollection<CartItem> GetAll(int customerId = 1);
    public void Update(Product product, int customerId = 1);
    public bool Delete(int cartItemId = 1);
}