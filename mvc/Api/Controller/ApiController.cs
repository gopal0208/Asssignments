using Microsoft.AspNetCore.Mvc;
using Api.Repository;
using PagedList;
using Newtonsoft.Json;
using Api.Models;
using Api.DataLogic;

namespace Api.Controllers;

public class ApiController : Controller
{
    private readonly ApiRepository _productRepository;
    private static int LIMIT = 6;
    public ApiController() 
    {
        _productRepository = new ApiRepository();
    }
    public string Index(string? brand="", int minPrice=0, int maxPrice=0, int page = 1)
    {
        
        var data = _productRepository.MergedResultantData(brand, minPrice, maxPrice);
        IPagedList<Product> list=data.ToPagedList(page, LIMIT);
        var json = JsonConvert.SerializeObject(list);
        return json;
    }
}