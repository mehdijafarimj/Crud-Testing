using Domain;
using Infrastructure;
using Logic;
using Logic.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

    [HttpGet("GetById")]
    public IActionResult GetById(int Id)
    {
        var admin = _adminService.GetById(Id);
        return Ok(admin);
    }
 
    [HttpPost]
    public IActionResult AddAdmin(CreateAdminDto dto)
    {
        _adminService.Add(dto);
        return NoContent();
    }

    [HttpPut]
    public IActionResult UpdateAdmin(UpdateAdminDto dto)
    {
        _adminService.Update(dto);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteAdmin(int Id)
    {
        _adminService.Delete(Id);
        return NoContent();
    }
}
    

      
    

