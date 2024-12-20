using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Robust.Repositories.Interface;
using Robust.Model.Product;
using Robust.Enums.Category;
using System.Collections.ObjectModel;
using Robust.Repositories.Database;
using Robust.Model.CartItem;
using System.Data;

namespace Robust.Repositories.ProductRepository;

public class ProductRepository : IRepository
{
    public int Add(string filepath)
    {
        int newProductId = 0;

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("AddProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", "Eget Piktogram");
                command.Parameters.AddWithValue("@Description", "Dit helt eget piktogram!");
                command.Parameters.AddWithValue("@ImagePath", filepath);
                command.Parameters.AddWithValue("@Price", 20.75);
                command.Parameters.AddWithValue("@CategoryID", 5);
                command.Parameters.AddWithValue("@IsPictogram", 1);

                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int productId))
                {
                    newProductId = productId;
                }
            }
        }

        return newProductId;
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }


    public ObservableCollection<Product> GetAll(bool isPictogram = false)
    {
        string query = "SELECT * FROM Product WHERE isPictogram = @IsPictogram";
        ObservableCollection<Product> products = [];

        using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IsPictogram", isPictogram);

            connection.Open();

            string partialImagePath = $"{AppDomain.CurrentDomain.BaseDirectory}/images";

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int CategoryID = (int)reader["CategoryID"];

                    string imagePath = (string)reader["ImagePath"];

                    Product product = new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        ImagePath = $"{partialImagePath}/{imagePath}",
                        Price = (decimal)reader["Price"],
                        Category = (Category)CategoryID
                    };

                    products.Add(product);
                }
            };
        }

        return products;
    }

    public void GetByID()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}
