using System.Collections.ObjectModel;
using Robust.Model.CartItem;
using Robust.Model.Product;

namespace Robust.Repositories.Interface;

public interface IRepository
{
    public ObservableCollection<Product> GetAll();
    public void GetByID();
    public void Add();
    public void Update();
    public void Delete();
}


public interface ICartRepository
{
    public void Add(Product product, int customerId = 1);
    public ObservableCollection<CartItem> GetAll(int customerId = 1);
    public void Update(Product product, int customerId = 1);
    public void Delete(int customerId = 1);
}