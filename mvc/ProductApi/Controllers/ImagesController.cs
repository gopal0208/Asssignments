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
}
