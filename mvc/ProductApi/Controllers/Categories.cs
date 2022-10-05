using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    
    private readonly ProductsContext _DBContext;

    public CategoriesController(ProductsContext dBContext)
    {
        this._DBContext=dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var prod=this._DBContext.Categories.ToList();
        return Ok(prod);
    }

    [HttpGet("GetbyCode/(code)")]
    public IActionResult GetbyCode(int code)
    {
        var prod=this._DBContext.Categories.FirstOrDefault(o=>o.CategoryId==code);
        return Ok(prod);
    }

    
    [HttpDelete("Remove/(code)")]
    public IActionResult Remove(int code)
    {
        var prod=this._DBContext.Categories.FirstOrDefault(o=>o.CategoryId==code);
        if(prod!=null){
            this._DBContext.Remove(prod);
            this._DBContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }

}
