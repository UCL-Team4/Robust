using Microsoft.Data.SqlClient;
using Robust.Enums.Category;
using Robust.Model.Product;
using Robust.Repositories.Database;
using Robust.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robust.Repositories.User;

class UserRepository : IUserRepository
{
    public int? Login(string email, string password)
    {
        int? customerId = null;

        string query = @"
            SELECT CustomerID 
            FROM Login
            WHERE Email = @email
            AND PasswordHash = @Password";

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@email", email.Trim());
            command.Parameters.AddWithValue("@Password", password.Trim());

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    customerId = reader.GetInt32(0);
                }
            }
        }

        return customerId;
    }
}
