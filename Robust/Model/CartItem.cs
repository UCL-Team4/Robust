using Robust.Model.Product;
using System.Collections.ObjectModel;

namespace Robust.Model.CartItem;

public class CartItem
{
    public int CartID { get; set; }
    public int ProductID { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int CartItemID { get; set; }
}
