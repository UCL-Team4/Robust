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
        var viewModel = new ProductViewModel(true);

        // arrange
        // add products to our viewModel
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
        // Here we set the selected Category to "Sundhed" which then filteres the "SelectedProducts"
        viewModel.SelectedCategory = Category.Sundhed;


        // Assert
        // Here we assert to make sure our unit test passed
        Assert.AreEqual(1, viewModel.SelectedProducts.Count, "Antallet af Sundhed-produkter matcher ikke det forventede antal.");
    }

    [TestMethod]
    public void GET_ALL_HYGIJENE_PRODUCTS()
    {
        var viewModel = new ProductViewModel(true);

        // arrange
        // add products to our viewModel
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


        // act
        // Here we set the selected Category to "Hygiejne" which then filteres the "SelectedProducts"
        viewModel.SelectedCategory = Category.Hygiejne;

        // Assert
        // Here we assert to make sure our unit test passed
        Assert.AreEqual(1, viewModel.SelectedProducts.Count, "Antallet af Hygiejne-produkter matcher ikke det forventede antal.");
    }
}