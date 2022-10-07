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

    [HttpGet("GetbyId/(Id)")]
    public IActionResult GetbyCode(int Id)
    {
        var prod=this._DBContext.Categories.FirstOrDefault(o=>o.CategoryId==Id);
        return Ok(prod);
    }
}
