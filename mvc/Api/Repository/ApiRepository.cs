using MySql.Data.MySqlClient;
using Dapper;
using Api.DataLogic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api.Repository;

public class ApiRepository 
{
    public static string con = "server=localhost;port=3306;user=root;password=Gopal@2551561;database=products";
    
    public static List<Product> Prods;
    static MySqlConnection connection = new MySqlConnection(con);
    public static void GetProducts(string brand,int minPrice,int maxPrice){
        string filterQuery= Logic.GetProductLogic(brand,minPrice,maxPrice);
        var products=connection.Query<Product>(filterQuery);
        Prods=products.ToList();
    }

    public static void GetImages(){
        foreach(Product prod in Prods){
            string filterQuery=Logic.GetImagesLogic(prod.Id);
            var images=connection.Query<string>(filterQuery);
            prod.image_link=images.ToList();
        }
    }

    public List<Product> MergedResultantData(string brand, int minPrice, int maxPrice)
    {
        GetProducts(brand,minPrice,maxPrice);
        GetImages();
        return Prods;
    }
    
}
