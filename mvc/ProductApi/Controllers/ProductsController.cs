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

    
    [HttpDelete("Remove/(id)")]
    public IActionResult Remove(int id)
    {
        var prod=this._DBContext.Products.FirstOrDefault(o=>o.Id==id);
        if(prod!=null){
            this._DBContext.Remove(prod);
            this._DBContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }

    
    [HttpPost("Create")]
    public IActionResult Create([FromBody] Product _product)
    {
        var prod=this._DBContext.Products.FirstOrDefault(o=>o.Id==_product.Id);
        if(prod!=null){
            prod.Brand=_product.Brand;
            prod.CategoryId=_product.CategoryId;
            prod.Descrip=_product.Descrip;
            prod.DiscountPercentage=_product.DiscountPercentage;
            prod.Price=_product.Price;
            prod.Rating=_product.Rating;
            prod.Thumbnail=_product.Thumbnail;
            prod.Stock=_product.Stock;
            prod.Title=_product.Title;
            this._DBContext.SaveChanges();
        }
        else{
            this._DBContext.Products.Add(_product);
            this._DBContext.SaveChanges();
        }
        return Ok(true);
    }

    [HttpGet("GetByPrice/(minimumPrice,maximumPrice)")]
    public IActionResult getByPrice(int mininmumPrice,int maximumPrice){
        var prod = this._DBContext.Products.Where(o=>(o.Price>=mininmumPrice && o.Price<=maximumPrice));
        return Ok(prod);
    }

    [HttpGet("GetBybrand/(brandName)")]
    public IActionResult getByBrand(string brandName){
        var prod= this._DBContext.Products.Where(o=>o.Brand==brandName);
        return Ok(prod);
    }

}
