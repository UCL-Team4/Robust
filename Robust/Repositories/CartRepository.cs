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
        public bool Add(Product product, int customerId = 1)
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
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Delete(int cartItemId = 1)
        {
            using SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString);

            string query = "DELETE FROM CartItems WHERE CartItemID = @CartItemID";

            using SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue("@CartItemID", cartItemId);

            connection.Open();

            // Check if more than 0 rows were affected
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
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
                        Quantity = (int)reader["Quantity"],
                        CartItemID = (int)reader["CartItemID"],
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
