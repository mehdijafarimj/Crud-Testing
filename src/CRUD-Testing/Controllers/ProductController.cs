using Logic;
using Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Testing.Controllers;
[Authorize]
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
    public IActionResult AddProduct(CreateProductDtoForAdmin dto)
    {
        _productService.Add(dto);
        return NoContent();
    }

    [HttpPost("UserProduct")]
    public IActionResult AddProductForUser(CreateProductDtoForUser dto)
    {
        _productService.AddForUser(dto);
        return NoContent();
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDtoForAdmin dto)
    {
        _productService.Update(dto);
        return NoContent();
    }

    [HttpPut("UpdateUserProduct")]
    public IActionResult UpdateUserProduct(UpdateProductDtoForUser dto)
    {
        _productService.UpdateUserProduct(dto);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        _productService.Delete(Id);
        return NoContent();
    }
}
