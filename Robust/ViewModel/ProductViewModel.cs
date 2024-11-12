



using Robust.Model.Product;
using Robust.MVVM.ViewModelBase;
using Robust.Repositories.Product;
using System.Collections.ObjectModel;

namespace Robust.ViewModel.ProductViewModel;

internal class ProductViewModel : ViewModelBase
{
    private ProductRepository _repository = new();
    private ObservableCollection<Product> _products = [];

    private void LoadProducts()
    {
        throw new NotImplementedException();
    }

    private void CreateProduct()
    {
        throw new NotImplementedException();
    }

    private void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    private void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    private void SaveProduct()
    {
        throw new NotImplementedException();
    }

    public ProductViewModel() { }
}
