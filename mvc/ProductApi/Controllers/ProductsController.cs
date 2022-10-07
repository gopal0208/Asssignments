using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    
    private readonly ProductsContext _DBContext;

    public ProductsController(ProductsContext dBContext)
    {
        this._DBContext=dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var prod=this._DBContext.Products.ToList();
        return Ok(prod);
    }

    [HttpGet("GetbyId/(id)")]
    public IActionResult GetbyId(int id)
    {
        var prod=this._DBContext.Products.FirstOrDefault(o=>o.Id==id);
        return Ok(prod);
    }

    [HttpGet("GetByPrice/(minimumPrice,maximumPrice,brandName)")]
    public IActionResult getByPrice(int mininmumPrice,int maximumPrice,string brandName){
        var prod = this._DBContext.Products.Where(o=>(o.Price>=mininmumPrice && o.Price<=maximumPrice && o.Brand==brandName));
        return Ok(prod);
    }

}
