using Logic;
using Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Testing.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var admins = _adminService.GetAll();
        return Ok(admins);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var admin = _adminService.GetById(id);
        return Ok(admin);
    }

    [HttpGet("GetWithUsers/{id}")]
    public IActionResult GetWithUsers(int id)
    {
        var admin = _adminService.GetAdminWithUser(id);
        return Ok(admin);
    }

    [HttpGet("getWithProducts/{id}")]
    public IActionResult GetWithProducts(int id)
    {
        var admin = _adminService.GetAdminWithProduct(id);
        return Ok(admin);
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpPost]
    public IActionResult AddAdmin(CreateAdminDto dto)
    {
        _adminService.Add(dto);
        return NoContent();
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpPut]
    public IActionResult UpdateAdmin(UpdateAdminDto dto)
    {
        _adminService.Update(dto);
        return NoContent();
    }

    [Authorize(Policy = "adminPolicy")]
    [HttpDelete("{Id}")]
    public IActionResult DeleteAdmin(int Id)
    {
        _adminService.Delete(Id);
        return NoContent();
    }
}