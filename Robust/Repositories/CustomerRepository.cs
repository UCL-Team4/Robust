using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Controls;
using Robust.Model.Customer;
using Robust.Model.Product;
using Robust.Repositories.Interface;
using Robust.Repositories.Database;
using Robust.Repositories.api;

namespace Robust.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public Customer GetByID(string username, string password)
        {
            int customerId = Api.GetCustomerIDFromLogin(username, password);

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (var command = new SqlCommand("uspGetCustomerByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    //This was added to the code from the learning object.
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerID = (int)reader["CustomerID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"]
                            };
                        }
                    }
                }
            }
            
            return null;
        }
    }
}
