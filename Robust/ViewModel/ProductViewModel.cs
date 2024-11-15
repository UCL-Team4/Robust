



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
            CheckDisplayAll();
            CheckAvailability();            
        }
    }

    //This method displays products from SelectedProducts which have the SelectedCategory.
    private void DisplayProducts()
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
    private void CheckDisplayAll()
    {
        if (SelectedCategory == Category.AlleKategorier)
        {
            foreach (Product product in Products)
            {
                SelectedProducts.Add(product);
            }
        }
    }

    //This method shows a messagebox if there are no products in the chosen category.
    private void CheckAvailability()
    {
        if (SelectedProducts.Count == 0)
        {
            MessageBox.Show("Vi kunne desværre ikke finde nogen produkter, som matcher din søgning. Prøv en anden kategori.");
        }
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
        
        Products = new ObservableCollection<Product>
        {
            new Product { Name = "Bustur", Category = Category.Transport, Description = "Et piktogram, der forestiller en bus", ImagePath = "C:/temp/Robust/Bus.jpg", Price = 38.00M },
            new Product { Name = "Håndvask", Category = Category.Hygiejne, Description = "Et piktogram, som viser håndvask", ImagePath = "C:/temp/Robust/Handwashing.jpeg", Price = 38.00M },
            new Product { Name = "Indkøbsvogn", Category = Category.IndkobOgShopping, Description = "Et piktogram, som viser en indkøbsvogn med varer", ImagePath = "C:/temp/Robust/ShoppingCart.jpg", Price = 38.00M }
        };

        FillSelectedProducts();
    }
}
