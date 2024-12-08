using System.Collections.ObjectModel;
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
