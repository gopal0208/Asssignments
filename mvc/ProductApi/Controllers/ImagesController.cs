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

    [HttpGet("GetbyId/(id)")]
    public IActionResult GetbyId(int id)
    {
        var prod=this._DBContext.Images.Where(o=>o.Id==id).ToList();
        return Ok(prod);
    }

    
    [HttpDelete("RemoveById/(id)")]
    public IActionResult Remove(int id)
    {
        var prod=this._DBContext.Images.Where(o=>o.Id==id).ToList();
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
