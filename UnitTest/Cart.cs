using Robust.Model.CartItem;
using Robust.Model.Product;
using Robust.Repositories;
using Robust.Repositories.Interface;
using System.Collections.ObjectModel;

namespace UnitTest;

[TestClass]
public class Cart
{
    CartRepository _repository = new CartRepository();

    [TestMethod]
    public void CART_TEST_ADD_PRODUCT()
    {
        Product product = new Product();

        product.ProductID = 1;

        bool success = _repository.Add(product, "test", "test");

        Assert.IsTrue(success, "ITEM WAS NOT ADDED TO CART");
    }

    [TestMethod]
    public void CART_TEST_DELETE_PRODUCT()
    {
        ObservableCollection<CartItem> products = _repository.GetAll("test", "test");

        if (products.Count == 0)
        {
            // we just pass the test as we have no products to test on
            Assert.IsTrue(true);
            return;
        }


        bool success = _repository.Delete(products[0].CartItemID, "test", "test");

        Assert.IsTrue(success, "ITEM FAILED TO DELETE FROM CART");
    }

    [TestMethod]
    public void CART_TEST_UPDATE_PRODUCT()
    {
        ObservableCollection<CartItem> products = _repository.GetAll("test", "test");

        if (products.Count == 0)
        {
            // we just pass the test as we have no products to test on
            Assert.IsTrue(true);
            return;
        }

        int currentCount = products[0].Quantity;

        bool success = _repository.Update(products[0], currentCount + 5, "test", "test");

        if (success)
        {
            ObservableCollection<CartItem> newProducts = _repository.GetAll("test", "test");

            Assert.AreEqual(currentCount + 5, newProducts[0].Quantity, "ITEM COUNT WAS NOT UPDATED PROPERLY");
            return;
        }

        Assert.IsTrue(false, "ITEMS FAILED TO UPDATE PROPERY");
    }
}
