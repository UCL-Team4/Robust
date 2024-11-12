using System.CodeDom;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Robust.Enums.Category;
using Robust.Model.Product;

namespace UnitTest;

[TestClass]
public class UseCase1
{
    private List<Product> _products;

    [TestInitialize]
    public void Initialize()
    {
        // Initialiser listen med nogle produkter
        _products =
            [
                new Product
                {
                    ProductID = 1,
                    Name = "Bicycle",
                    Description = "A sturdy mountain bike.",
                    Price = 2499,
                    StockQuantity = 10,
                    ImagePath = "/images/bicycle.jpg",
                    Category = Category.Transport
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Shampoo",
                    Description = "Gentle cleansing shampoo.",
                    Price = 49,
                    StockQuantity = 50,
                    ImagePath = "/images/shampoo.jpg",
                    Category = Category.Hygiejne
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Grocery Bag",
                    Description = "Reusable shopping bag.",
                    Price = 5,
                    StockQuantity = 200,
                    ImagePath = "/images/grocery_bag.jpg",
                    Category = Category.IndkobOgShopping
                },
                new Product
                {
                    ProductID = 4,
                    Name = "Vitamins",
                    Description = "Daily multivitamin supplement.",
                    Price = 99,
                    StockQuantity = 30,
                    ImagePath = "/images/vitamins.jpg",
                    Category = Category.Sundhed
                },
                new Product
                {
                    ProductID = 5,
                    Name = "Painkillers",
                    Description = "Over-the-counter pain relief.",
                    Price = 79,
                    StockQuantity = 40,
                    ImagePath = "/images/painkillers.jpg",
                    Category = Category.Sundhed
                }
            ];
    }

    [TestMethod]
    public void TestPopulation()
    {
        // Test at alle produkter bliver oprettet
        Assert.AreEqual(5, _products.Count);
    }


    [TestMethod]
    public void TestSundhedSort()
    {
        // Lav en metode i vores ViewModel vi kan teste her der skal se om vi har filteret alle produkter med sundhed.
        List<Product> sundhedProducts = [];

        // Assert at alle filtrerede produkter har kategorien Sundhed
        Assert.IsTrue(sundhedProducts.All(p => p.Category == Category.Sundhed), "Ikke alle produkter har kategorien Sundhed.");

        // Assert at antallet af Sundhed-produkter er som forventet (i dette tilfælde 2)
        Assert.AreEqual(2, sundhedProducts.Count, "Antallet af Sundhed-produkter matcher ikke det forventede antal.");
    }

    [TestMethod]
    public void TestHygiejneSort()
    {
        // Lav en metode i vores ViewModel vi kan teste her der skal se om vi har filteret alle produkter med sundhed.
        List<Product> sundhedProducts = [];

        // Assert at alle filtrerede produkter har kategorien Sundhed
        Assert.IsTrue(sundhedProducts.All(p => p.Category == Category.Hygiejne), "Ikke alle produkter har kategorien Sundhed.");

        // Assert at antallet af Sundhed-produkter er som forventet (i dette tilfælde 1)
        Assert.AreEqual(1, sundhedProducts.Count, "Antallet af Sundhed-produkter matcher ikke det forventede antal.");
    }
}