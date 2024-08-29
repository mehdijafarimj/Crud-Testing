using Logic;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CRUD_Testing.Controllers;
[ApiController]
[Route("api/[controller]")]

public class UserController:ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {        
        var users = _userService.GetAll();
        return Ok(users);
    }
  
    [HttpPost]
    public IActionResult AddUser(string name, string lastName,int age,string address,string nationalCode)    
    {
        _userService.Add(name, lastName, age,address,nationalCode);
        return NoContent(); 
    }
    
    [HttpPut]
    public IActionResult UpdateUser(int Id, string name, string lastName, int age, string address, string nationalCode)
    {
        _userService.Update(Id, name, lastName, age, address, nationalCode);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteUser(int Id)
    {
        _userService.Delete(Id);
        return NoContent();
    }
}
