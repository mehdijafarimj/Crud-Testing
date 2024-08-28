using Logic;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Testing.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService product)
    {
        _productService = product;
    }
    [HttpPost]
    public IActionResult AddProduct(string name,double price,string description)
    {
        _productService.Add(name, price, description);
        return NoContent();
    }
    [HttpPut]
    public IActionResult UpdateProduct(int Id,string name,double price,string description)
    {
        _productService.Update(Id, name, price, description);
        return NoContent();
    }
    [HttpDelete("{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        _productService.Delete(Id);
        return NoContent();
    }
}
