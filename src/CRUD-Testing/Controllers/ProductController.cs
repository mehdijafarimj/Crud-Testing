using Logic;
using Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Policy = "adminPolicy")]
    [HttpPost]
    public IActionResult AddProduct(CreateProductDtoForAdmin dto)
    {
        _productService.Add(dto);
        return NoContent();
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpPost("UserProduct")]
    public IActionResult AddProductForUser(CreateProductDtoForUser dto)
    {
        _productService.AddForUser(dto);
        return NoContent();
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDtoForAdmin dto)
    {
        _productService.Update(dto);
        return NoContent();
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpPut("UpdateUserProduct")]
    public IActionResult UpdateUserProduct(UpdateProductDtoForUser dto)
    {
        _productService.UpdateUserProduct(dto);
        return NoContent();
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpDelete("{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        _productService.Delete(Id);
        return NoContent();
    }
}
