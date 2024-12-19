using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Robust.Repositories.Database;
using System.Windows;
using Robust.Model.CartItem;
using Robust.Repositories.Interface;
using System.Collections.ObjectModel;
using System.Data;

namespace Robust.Repositories.CheckoutRepository;

public class CheckoutRepository
{
    private CartRepository _cartRepository = new CartRepository();
    
    public bool Checkout()
    {
        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            SqlTransaction transaction;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                int test_customerID = 1;
                int id = CreateOrder(connection, transaction, test_customerID);
                if (id == -1)
                {
                    transaction.Rollback();
                    return false;
                }

                if (!ConvertCartItems(connection, transaction, id))
                {
                    transaction.Rollback();
                    return false;
                }

                int test_cartID = 1;
                if (!DeleteCartItems(connection, transaction, test_cartID))
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
            }
            catch (SqlException sqlError)
            {
                transaction.Rollback();
                return false;
            }
        }

        return true;
    }

    private int CreateOrder(SqlConnection connection, SqlTransaction transaction, int customerID)
    {
        string query = @"
            INSERT INTO WebShopOrder (TotalPrice, CustomerID) 
            OUTPUT INSERTED.OrderID
            VALUES (@TotalPrice, @CustomerID)";

        using (SqlCommand command = new SqlCommand(query, connection, transaction))
        {
            command.Parameters.AddWithValue("@TotalPrice", CalculateCartPrice(customerID));
            command.Parameters.AddWithValue("@CustomerID", customerID);

            object result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }
    }

    private decimal CalculateCartPrice (int customerId = 1)
    {
        //IMPLEMENT LATER int cartId = GetCartIdByCustomerId(customerId);

        int cartId = 1;
        decimal totalPrice = 0;

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
                totalPrice += (int)reader["Quantity"] * (decimal)reader["Price"];
            }
        }

        return totalPrice;
    }

    private bool ConvertCartItems(SqlConnection connection, SqlTransaction transaction, int orderID)
    {
        ObservableCollection<CartItem> cartItems = _cartRepository.GetAll("test", "test");

        foreach (var cartItem in cartItems)
        {
            var convertCommand = new SqlCommand("uspConvertCartItems", connection, transaction);
            convertCommand.CommandType = CommandType.StoredProcedure;
            convertCommand.Parameters.AddWithValue("@CartItemID", cartItem.CartItemID);
            convertCommand.Parameters.AddWithValue("@OrderID", orderID);

            if (convertCommand.ExecuteNonQuery() == 0)
                return false;
        }
        return true;
    }

    private bool DeleteCartItems(SqlConnection connection, SqlTransaction transaction, int cartID)
    {
        string query = @"
            SET NOCOUNT OFF;
            DELETE FROM CartItems 
            WHERE CartID = @CartID";

        using (SqlCommand deleteCommand = new SqlCommand(query, connection, transaction))
        {
            deleteCommand.Parameters.AddWithValue("@CartID", cartID);
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            return SelectCartItemRows(connection, transaction, cartID) == 0;
        }
    }    

    private int SelectCartItemRows(SqlConnection connection, SqlTransaction transaction, int cartID)
    {
        string query = @"
            SELECT COUNT(*)
            FROM CartItems
            WHERE CartID = @CartID";

        using (SqlCommand command = new SqlCommand(query, connection, transaction))
        {
            command.Parameters.AddWithValue("@CartID", cartID);

            return (int)command.ExecuteScalar();
        }
    }
}
