﻿using Infrastructure;
using Logic;
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

    [HttpPost]
    public IActionResult AddAdmin(string name, string userName, int age, string password, string email, string address)
    {
        _adminService.Add(name, userName, age, password, email, address);
        return NoContent();
    }

    [HttpPut]
    public IActionResult UpdateAdmin(int Id, string name, string userName, int age, string password, string email, string address)
    {
        _adminService.Update(Id, name, userName, age, password, email, address);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteAdmin(int Id)
    {
        _adminService.Delete(Id);
        return NoContent();
    }
}
    

      
    

