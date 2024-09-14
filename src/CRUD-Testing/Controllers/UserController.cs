using Logic;
using Logic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CRUD_Testing.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]

public class UserController:ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {        
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(int Id)
    {
        var user = _userService.GetById(Id);
        return Ok(user);
    }

    [HttpGet("GetWithProducts/{id}")]
    public IActionResult GetUserWtihProduct(int id)
    {
        var user = _userService.GetUserWithProduct(id);
        return Ok(user);
    }
  
    [HttpPost]
    public IActionResult AddUser(CreateUserDto dto)    
    {
        _userService.Add(dto);
        return NoContent(); 
    }
    
    [HttpPut]
    public IActionResult UpdateUser(UpdateUserDto dto)
    {
        _userService.Update(dto);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteUser(int Id)
    {
        _userService.Delete(Id);
        return NoContent();
    }
}
