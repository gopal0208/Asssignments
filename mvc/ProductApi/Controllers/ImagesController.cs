using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{
    
    private readonly ProductsContext _DBContext;

    public ImagesController(ProductsContext dBContext)
    {
        this._DBContext=dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var prod=this._DBContext.Images.ToList();
        return Ok(prod);
    }

    [HttpGet("GetbyCode/(code)")]
    public IActionResult GetbyCode(int code)
    {
        var prod=this._DBContext.Images.FirstOrDefault(o=>o.Id==code);
        return Ok(prod);
    }

    
    [HttpDelete("Remove/(code)")]
    public IActionResult Remove(int code)
    {
        var prod=this._DBContext.Images.FirstOrDefault(o=>o.Id==code);
        if(prod!=null){
            this._DBContext.Remove(prod);
            this._DBContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }

    
    [HttpPost("Create")]
    public IActionResult Create([FromBody] Image _product)
    {     
            this._DBContext.Images.Add(_product);
            this._DBContext.SaveChanges();
            return Ok(true);
    }
}
