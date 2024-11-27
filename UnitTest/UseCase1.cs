using Robust.Enums.Category;
using Robust.Model.Product;

using Robust.ViewModel.ProductViewModel;

namespace UnitTest;

[TestClass]
public class UseCase1
{


    [TestMethod]
    public void GET_ALL_SUNDHEDS_PRODUCTS()
    {
        // arrange
        var viewModel = new ProductViewModel(true);

        viewModel.Products.Add(new()
        {
            ProductID = 1,
            Name = "Mask",
            Description = "Make sure the virus dont spread",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/Mask.jpg",
            Category = Category.Sundhed
        });

        viewModel.Products.Add(new()
        {
            ProductID = 2,
            Name = "Bicycle",
            Description = "A sturdy mountain bike.",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/bicycle.jpg",
            Category = Category.Transport
        });

        viewModel.Products.Add(new()
        {
            ProductID = 3,
            Name = "Bicycle",
            Description = "A sturdy mountain bike.",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/bicycle.jpg",
            Category = Category.Transport
        });

        // act
        // Lav en metode i vores ViewModel vi kan teste her der skal se om vi har filteret alle produkter med sundhed.
        viewModel.SelectedCategory = Category.Sundhed;


        // asert
        // Assert at alle filtrerede produkter har kategorien Sundhed
        Assert.AreEqual(1, viewModel.SelectedProducts.Count, "Antallet af Sundhed-produkter matcher ikke det forventede antal.");
    }

    [TestMethod]
    public void GET_ALL_HYGIJENE_PRODUCTS()
    {
        var viewModel = new ProductViewModel(true);

        viewModel.Products.Add(new()
        {
            ProductID = 1,
            Name = "Soap",
            Description = "Soap to clean those dirty hands",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/soap.jpg",
            Category = Category.Hygiejne
        });

        viewModel.Products.Add(new()
        {
            ProductID = 2,
            Name = "Bicycle",
            Description = "A sturdy mountain bike.",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/bicycle.jpg",
            Category = Category.Transport
        });

        viewModel.Products.Add(new()
        {
            ProductID = 3,
            Name = "Bicycle",
            Description = "A sturdy mountain bike.",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/bicycle.jpg",
            Category = Category.Transport
        });


        // Lav en metode i vores ViewModel vi kan teste her der skal se om vi har filteret alle produkter med Hygiejne.
        viewModel.SelectedCategory = Category.Hygiejne;

        // Assert at alle filtrerede produkter har kategorien Hygiejne
        Assert.AreEqual(1, viewModel.SelectedProducts.Count, "Antallet af Hygiejne-produkter matcher ikke det forventede antal.");
    }
}