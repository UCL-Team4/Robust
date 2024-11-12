using Robust.Enums.Category;
using Robust.Model.Product;

namespace UnitTest;

[TestClass]
public class UseCase1
{


    [TestMethod]
    public void GET_ALL_SUNDHEDS_PRODUCTS()
    {
        // arrange
        List<Product> _products = [];

        _products.Add(new()
        {
            ProductID = 1,
            Name = "Mask",
            Description = "Make sure the virus dont spread",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/Mask.jpg",
            Category = Category.Sundhed
        });

        _products.Add(new()
        {
            ProductID = 2,
            Name = "Bicycle",
            Description = "A sturdy mountain bike.",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/bicycle.jpg",
            Category = Category.Transport
        });

        _products.Add(new()
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
        List<Product> sundhedProducts = [];


        // asert
        // Assert at alle filtrerede produkter har kategorien Sundhed
        Assert.AreEqual(1, sundhedProducts.Count, "Antallet af Sundhed-produkter matcher ikke det forventede antal.");
    }

    [TestMethod]
    public void GET_ALL_HYGIJENE_PRODUCTS()
    {
        List<Product> _products = [];

        _products.Add(new()
        {
            ProductID = 1,
            Name = "Soap",
            Description = "Soap to clean those dirty hands",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/soap.jpg",
            Category = Category.Hygiejne
        });

        _products.Add(new()
        {
            ProductID = 2,
            Name = "Bicycle",
            Description = "A sturdy mountain bike.",
            Price = 2499,
            StockQuantity = 10,
            ImagePath = "/images/bicycle.jpg",
            Category = Category.Transport
        });

        _products.Add(new()
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
        List<Product> hygiejneProducts = [];

        // Assert at alle filtrerede produkter har kategorien Hygiejne
        Assert.AreEqual(1, hygiejneProducts.Count, "Antallet af Hygiejne-produkter matcher ikke det forventede antal.");
    }
}