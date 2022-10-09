namespace Api.DataLogic;

public class Logic
{
    public static string GetProductLogic(string brand, int minPrice, int maxPrice)
    {
        string filteredQuery = "";
        string query = "Select * from product WHERE ";
        filteredQuery = filterTheQuery(query, brand, minPrice, maxPrice);
        if (filteredQuery == "")
        {
            filteredQuery = "select *from product";
        }
        return filteredQuery;
    }

    public static string GetImagesLogic(int id)
    {
        string filteredQuery = "";
        string query = "select image_link from image ";
        filteredQuery = filterImageQuery(query,id);
        return filteredQuery;
    }

    public static string filterTheQuery(string query, string brand, int minPrice, int maxPrice)
    {
        if (brand != "")
        {
            query = query + $"brand IN ({brand})";
            if (minPrice != 0 && maxPrice != 0)
                {
                    query = query + $" AND price between {minPrice} AND {maxPrice}";
                }
        }
        else if (minPrice != 0 && maxPrice != 0) 
        {
            query = query + $" AND price between {minPrice} AND {maxPrice}";
        }
        else
        {
            query = "";
        }
        return query;
    }

    public static string filterImageQuery(string query,int id){
        query=query+ $" WHERE id={id}";
        return query;
    }
}
