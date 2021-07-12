using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationCore.DbContext
{
    public class MovieShopDbContext
    {
        public IDbConnection GetConnection()
        {
            var configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string conn = configurationRoot.GetConnectionString("MovieShop");
            return new SqlConnection(conn);
        }
    }
}
