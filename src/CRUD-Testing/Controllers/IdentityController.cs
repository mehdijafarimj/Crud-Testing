using Azure.Core;
using CRUD_Testing.Identity;
using Domain;
using Logic;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CRUD_Testing.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private IConfiguration _config;
    public LoginController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost]
    public IActionResult GenerateToken([FromBody] LoginRequest loginRequest)
    {
        var token = JwtHelper.GetJwtToken("javid",
            _config["Jwt:Key"],
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            TimeSpan.FromHours(1),
            [ new(ClaimTypes.Role, "admin") ]);

        return Ok(token);
    }
}