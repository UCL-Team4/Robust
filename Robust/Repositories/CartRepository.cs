using Microsoft.Data.SqlClient;
using Robust.Enums.Category;
using Robust.Model.CartItem;
using Robust.Model.Product;
using Robust.Repositories.Database;
using Robust.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robust.Repositories
{
    internal class CartRepository : ICartRepository
    {
        public void Add(Product product, int customerId = 1)
        {
            //IMPLEMENT LATER int cartId = GetCartIdByCustomerId(customerId);

            int cartId = 1;

            if (cartId == -1)
            {
                Console.WriteLine("Cart not found for the customer.");
            }

            using SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString);
            SqlCommand command = new SqlCommand("AddOrUpdateCartItem", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CartID", cartId);
            command.Parameters.AddWithValue("@ProductID", product.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int customerId = 1)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CartItem> GetAll(int customerId = 1)
        {
            //IMPLEMENT LATER int cartId = GetCartIdByCustomerId(customerId);

            int cartId = 1;

            var cartItems = new ObservableCollection<CartItem>();

            using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetCartItems", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameter for CartID
                command.Parameters.AddWithValue("@CartID", cartId);

                connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cartItems.Add(new CartItem
                    {
                        ProductID = (int)reader["ProductID"],
                        CartID = cartId,
                        Name = (string)reader["Name"],
                        ImagePath = (string)reader["ImagePath"],
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    });
                }
            }

            return cartItems;
        }

        public void Update(Product product, int customerId = 1)
        {
            throw new NotImplementedException();
        }
    }
}
