



using Robust.Model.Product;
using Robust.MVVM.ViewModelBase;
using Robust.Repositories.Product;
using System.Collections.ObjectModel;
using Robust.Enums.Category;
using System.Windows;

namespace Robust.ViewModel.ProductViewModel;

internal class ProductViewModel : ViewModelBase
{
    private ProductRepository _repository = new();
    private ObservableCollection<Product> _products = [];

    //This Collection is bound to the combobox which displays all the different categories.
    public ObservableCollection<Category> Categories { get; set; }
    //This Collection is used for adding products to the MainWindow
    public ObservableCollection<Product> Products { get; set; }
    //This Collection contains the products that are to be displayed in the MainWindow.
    public ObservableCollection<Product> SelectedProducts { get; set; }

    //This property is used to select images based on their category.
    private Category _selectedCategory;

    public Category SelectedCategory
    {
        get { return _selectedCategory; }
        set 
        { 
            _selectedCategory = value;
            OnPropertyChanged();
            DisplayProducts();
        }
    }

    //This is the main method of filtering products
    private void DisplayProducts()
    {
        if (SelectedProducts.Count > 0)
        {
            SelectedProducts.Clear();
        }

        if (SelectedCategory == Category.AlleKategorier)
        {
            DisplayAllProducts();
        }
        else
        {
            DisplayCategoryProducts();
        }

        if (SelectedProducts.Count == 0)
        {
            DisplayAvailabilityError();
        }
    }

    //This method displays products from SelectedProducts which have the SelectedCategory.
    private void DisplayCategoryProducts()
    {
        SelectedProducts.Clear();
        
        foreach (Product product in Products)
        {
            if (product.Category == SelectedCategory)
            {
                SelectedProducts.Add(product);
            }
        }
    }

    //This method checks if the category 'AlleKategorier' is selected.
    private void DisplayAllProducts()
    {
        foreach (Product product in Products)
        {
            SelectedProducts.Add(product);
        }
    }

    //This method shows a messagebox if there are no products in the chosen category.
    private void DisplayAvailabilityError()
    {
        MessageBox.Show("Vi kunne desværre ikke finde nogen produkter, som matcher din søgning. Prøv en anden kategori.");
    }

    //This method fills the collection SelectedProducts with all products from the collection Products.
    private void FillSelectedProducts()
    {
        foreach (Product product in Products)
        {
            SelectedProducts.Add(product);
        }
    }   

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

    //The content of this constructor is mostly used for testing purposes at this moment.
    public ProductViewModel()
    { 
        Categories = new ObservableCollection<Category>(Enum.GetValues(typeof(Category)).Cast<Category>());
        SelectedProducts = new ObservableCollection<Product>();
        
        FillSelectedProducts();
    }
}
