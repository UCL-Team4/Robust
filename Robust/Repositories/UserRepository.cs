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

public class UserRepository : IUserRepository
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

    public bool Register(string email, string password)
    {
        if (DoesEmailExist(email))
        {
            return false;
        }

        // We insert blank firstName and blank lastName since we dont ask for that information at registration
        int customerId = InsertCustomer("", "", email);
        if (customerId > 0)
        {
            return InsertNewUser(email, password, customerId);
        }

        return false; 
    }

    private int InsertCustomer(string firstName, string lastName, string Email)
    {
        string query = @"
        INSERT INTO Customer (FirstName, LastName, Email) 
        OUTPUT INSERTED.CustomerID
        VALUES (@FirstName, @LastName, @Email)";

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", Email); 

                // Get the generated CustomerID and return it to use with Foreign keys
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }

    private bool InsertNewUser(string email, string password, int customerId)
    {
        string query = @"
        INSERT INTO Login (Email, PasswordHash, UserName, CustomerID) 
        VALUES (@Email, @PasswordHash, @UserName, @CustomerID)";

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email.Trim());
                command.Parameters.AddWithValue("@PasswordHash", password.Trim());
                command.Parameters.AddWithValue("@UserName", email.Trim());
                command.Parameters.AddWithValue("@CustomerID", customerId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    private bool DoesEmailExist(string email)
    {
        string query = @"
        SELECT 1 
        FROM Login 
        WHERE Email = @Email";

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email.Trim());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }


}
