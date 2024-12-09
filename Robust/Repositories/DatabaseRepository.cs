using Microsoft.Extensions.Configuration;

namespace Robust.Repositories.Database;

internal static class DatabaseConfig
{
    private static readonly string? _connectionString;

    static DatabaseConfig()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public static string? ConnectionString => _connectionString;
}
