using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Model.Product;
using Robust.MVVM.ViewModelBase;
using Robust.Service.Interface;
using Robust.ViewModel.RelayCommands;
using Robust.Service.PictogramSheet;
using Robust.Enums.Category;
using System.Windows;
using Robust.Service.ShoppingCart;

namespace Robust.ViewModel.PictogramSheetViewModel;

public class PictogramSheetViewModel : ViewModelBase
{
    private IWindowService _windowService;
    //This Collection is bound to the combobox which displays all the different categories.
    public ObservableCollection<Category> Categories { get; set; }
    //This Collection contains the products that are to be displayed in the MainWindow.
    public ObservableCollection<Product> SelectedProducts { get; set; }
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product> PictogramSheetItems { get; set; }

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
    
    private Product _pictogramSheetItem;

    public Product PictogramSheetItem
    {
        get { return _pictogramSheetItem; }
        set 
        {
            _pictogramSheetItem = value;
            OnPropertyChanged();
        }
    }

    public PictogramSheetViewModel()
    {
        Categories = new ObservableCollection<Category>(Category.GetValues(typeof(Category)).Cast<Category>());
        Products = [];
        PictogramSheetItems = [];
        SelectedProducts = [];
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
        _windowService.ShowDialog(Products);
    }


    public RelayCommand AddProductToPictogramSheetCmd => new RelayCommand(AddProductToPictogramSheet, CanAddProductToPictogramSheet);

    private void AddProductToPictogramSheet()
    {
        PictogramSheetItems.Add(SelectedProduct);
    }

    private bool CanAddProductToPictogramSheet() => SelectedProduct != null && PictogramSheetItems.Count < 24;

    public RelayCommand RemoveProductFromPictogramSheetCmd => new RelayCommand(RemoveProductFromPictogramSheet, CanRemoveProductFromPictogramSheet);

    private void RemoveProductFromPictogramSheet()
    {
        PictogramSheetItems.Remove(PictogramSheetItem);
    }

    private bool CanRemoveProductFromPictogramSheet() => PictogramSheetItem != null;

    public RelayCommand AddProductToCartCmd => new RelayCommand(AddProductToCart, CanAddProductToCart);

    private void AddProductToCart()
    {
        //Needs implementation with database integration.
    }

    private bool CanAddProductToCart() => PictogramSheetItems.Count == 24;
}
