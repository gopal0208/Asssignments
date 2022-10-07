using Microsoft.AspNetCore.Mvc;
using ProductApi.Repository;
using PagedList;

namespace ProductApi.Controllers;

public class ProductController : Controller
{
    private readonly ProductRepository _productRepository;
    private static int LIMIT = 6;
    public ProductController() 
    {
        _productRepository = new ProductRepository();
    }
    public IPagedList<dynamic> Index(string? brand, int? minPrice, int? maxPrice, int page = 1)
    {
        
        var data = _productRepository.GetAllProducts(brand, minPrice, maxPrice);
        return data.ToPagedList(page, LIMIT);
    }
}