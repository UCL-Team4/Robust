using Microsoft.Data.SqlClient;
using Robust.Enums.Category;
using Robust.Model.CartItem;
using Robust.Model.Product;
using Robust.Repositories.api;
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
    public class CartRepository : ICartRepository
    {
        private int CreateCart(int customerId)
        {
            int newCartId = -1;

            string query = @"
            INSERT INTO Cart (CustomerID) 
            OUTPUT INSERTED.CartID
            VALUES (@customerID)";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerID", customerId);

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        newCartId = id;
                    }
                }
            }

            return newCartId;
        }

        public bool Add(Product product, string username, string password)
        {
            int customerId = Api.GetCustomerIDFromLogin(username, password);

            if (customerId == -1)
            {
                return false;
            }

            int cartId = Api.GetCartIDFromCustomerID(customerId);
            // Check if the cart dosn't exsist
            if (cartId == -1)
            {
                // Create the missing Cart to the customerID
                cartId = CreateCart(customerId);

                // make sure the cart has been created
                if (cartId == -1)
                    return false;
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

        public bool Delete(int cartItemId, string username, string password)
        {
            int customerID = Api.GetCustomerIDFromLogin(username, password);
            int cartID = Api.GetCartIDFromCustomerID(customerID);

            using SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString);

            string query = "DELETE FROM CartItems WHERE CartItemID = @CartItemID AND CartID = @CartID";

            using SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue("@CartItemID", cartItemId);
            command.Parameters.AddWithValue("@CartID", cartID);

            connection.Open();

            // Check if more than 0 rows were affected
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }


        public ObservableCollection<CartItem> GetAll(string username, string password)
        {
            int customerId = Api.GetCustomerIDFromLogin(username, password);
            int cartId = Api.GetCartIDFromCustomerID(customerId);

            // If cart dosn't exsist (user havent added to his cart before just return empty array)
            if (cartId == -1)
            {
                return [];
            }

            var cartItems = new ObservableCollection<CartItem>();

            using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetCartItems", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameter for CartID
                command.Parameters.AddWithValue("@CartID", cartId);

                connection.Open();

                string partialImagePath = $"{AppDomain.CurrentDomain.BaseDirectory}/images";
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string imagePath = (string)reader["ImagePath"];
                    int CategoryID = (int)reader["CategoryID"];

                    cartItems.Add(new CartItem
                    {
                        ProductID = (int)reader["ProductID"],
                        CartID = cartId,
                        Name = (string)reader["Name"],
                        ImagePath = CategoryID == 5 ? imagePath : $"{partialImagePath}/{imagePath}",
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"],
                        CartItemID = (int)reader["CartItemID"],
                    });
                }
            }

            return cartItems;
        }
        
        public bool Update(CartItem cartItem, int quantity, string username, string password)
        {
            int customerID = Api.GetCustomerIDFromLogin(username, password);
            int cartID = Api.GetCartIDFromCustomerID(customerID);

            using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("uspUpdateQuantity", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;              

                command.Parameters.AddWithValue("@CartItemID", cartItem.CartItemID);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@CartID", cartID);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
