using MySql.Data.MySqlClient;
using Dapper;

namespace ProductApi.Repository;

public class ProductRepository 
{
    public static string con = "server=localhost;port=3306;user=root;password=Gopal@2551561;database=products";

    static MySqlConnection connection = new MySqlConnection(con);
    public List<dynamic> GetAllProducts(string? brand, int? minPrice, int? maxPrice) 
    {
        string query = "SELECT * FROM product";

        if(brand != null)
        {
            query = query + $" WHERE Brand IN (\'{brand}\')";
            if(minPrice != null && maxPrice != null)
            {
                query = query + $" AND Price between {minPrice} AND {maxPrice}";
            }
        } 
        else if(minPrice != null && maxPrice != null)
        {
            query = query + $" WHERE Price between {minPrice} AND {maxPrice}";
        }

        return connection.Query<dynamic>(query).ToList();
    }
}
