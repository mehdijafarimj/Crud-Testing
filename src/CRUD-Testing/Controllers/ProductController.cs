using Logic;
using Logic.Dtos;
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

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(int Id)
    {
        var product = _productService.GetById(Id);
        return Ok(product);
    }
    
    [HttpPost]
    public IActionResult AddProduct(CreateProductDto dto)
    {
        _productService.Add(dto);
        return NoContent();
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto dto)
    {
        _productService.Update(dto);
        return NoContent();
    }
    [HttpDelete("{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        _productService.Delete(Id);
        return NoContent();
    }
}
