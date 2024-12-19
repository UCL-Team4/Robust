using Microsoft.Data.SqlClient;
using Robust.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robust.Repositories.api;




/// <summary>
///  This static class aims to provide basic funtionality and methods that can be used cross-repositories for methods that are common/shared between one and another
/// </summary>
public static class Api
{



    public static int GetCustomerIDFromLogin(string username, string password)
    {
        int customerId = -1; 

        string query = @"
        SELECT CustomerID 
        FROM Login 
        WHERE UserName = @username AND PasswordHash = @password";

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    customerId = id;
                }
            }
        }

        return customerId;
    }

    public static int GetCartIDFromCustomerID(int customerID)
    {
        int cartId = -1;

        string query = @"
        SELECT CartID 
        FROM Cart 
        WHERE CustomerID = @customerID";

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@customerID", customerID);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    cartId = id;
                }
            }
        }

        return cartId;
    }







}
