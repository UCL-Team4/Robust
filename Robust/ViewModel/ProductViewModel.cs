



using Robust.Model.Product;
using Robust.MVVM.ViewModelBase;
using Robust.Repositories.Product;
using System.Collections.ObjectModel;
using Robust.Enums.Category;
using System.Windows;
using Robust.ViewModel.RelayCommands;
using Robust.Service;
using Robust.View;
using System.Reflection.Metadata;

namespace Robust.ViewModel.ProductViewModel;

internal class ProductViewModel : ViewModelBase
{
    private ProductRepository _repository = new();
    private ObservableCollection<Product> _products = [];
    private IWindowService _windowService;

    //This Collection is bound to the combobox which displays all the different categories.
    public ObservableCollection<Category> Categories { get; set; }
    //This Collection is used for adding products to the MainWindow
    public ObservableCollection<Product> Products { get; set; }
    //This Collection contains the products that are to be displayed in the MainWindow.
    public ObservableCollection<Product> SelectedProducts { get; set; }
    //This Collection contains products that are added to the Shopping Cart.
    public ObservableCollection<Product> ShoppingCartList { get; set; }

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

    private Product _selectedProduct;

    public Product SelectedProduct
    {
        get { return _selectedProduct; }
        set 
        { 
            _selectedProduct = value;
            OnPropertyChanged();
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

    public ProductViewModel()
    {
        Categories = new ObservableCollection<Category>(Category.GetValues(typeof(Category)).Cast<Category>());
        SelectedProducts = new ObservableCollection<Product>();
        _windowService = new WindowService();

        //Added only for debugging purposes
        Products = new ObservableCollection<Product>
        {
            new Product {Name = "Bus", Category = Category.Transport, Description = "Et piktogram, som forestiller en bus", ImagePath = "C:/temp/Robust/Bus.jpg", Price = 38.00M},
            new Product {Name = "Håndvask", Category = Category.Hygiejne, Description = "Et piktogram, som forestiller håndvask", ImagePath = "C:/temp/Robust/Handwashing.jpeg", Price = 38.00M},
            new Product {Name = "Indkøbsvogn", Category = Category.IndkobOgShopping, Description = "Et piktogram, som forestiller en indkøbsvogn", ImagePath = "C:/temp/Robust/ShoppingCart.jpg", Price = 38.00M},
            new Product {Name = "Taxa", Category = Category.Transport, Description = "Et piktogram, som forestiller en taxa", ImagePath = "C:/temp/Robust/Taxi.jpg", Price = 38.00M}
        };
        
        FillSelectedProducts();
    }

    public RelayCommand ShowShoppingCartCmd => new RelayCommand(ShowShoppingCart);

    private void ShowShoppingCart()
    {
        _windowService.ShowDialog();
    }

    //public RelayCommand AddProductToCartCmd => new RelayCommand(AddProductToCart);
    

    private void AddProductToCart(object item)
    {
        var product = item as Product;
        int index = SelectedProducts.IndexOf(product);
        MessageBox.Show($"Du har trykket på box nr. {index}");
        //ShoppingCartList.Add(SelectedProduct);
    }
}
