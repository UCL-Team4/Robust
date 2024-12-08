using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Robust.Repositories.Interface;
using Robust.Model.Product;
using Robust.Enums.Category;
using System.Collections.ObjectModel;

namespace Robust.Repositories.ProductRepository;

public class ProductRepository : IRepository
{
    private readonly string? ConnectionString;

    public void Add()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<Product> GetAll()
    {
        string query = "SELECT * FROM Product";
        ObservableCollection<Product> products = [];

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int CategoryID = (int)reader["CategoryID"];

                    Product product = new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        ImagePath = (string)reader["ImagePath"],
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

    public ProductRepository()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        ConnectionString = config.GetConnectionString("DefaultConnection");
    }
}
