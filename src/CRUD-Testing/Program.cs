using Infrastructure;
using Logic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//Jwt Configurations start form herer.
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = jwtIssuer,
               ValidAudience = jwtIssuer,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
           };
       });


//Jwt Configurations just finished after this need to use Authentication and 
//Authorization down here after HttpRedirection and before MapControllers .


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<CrudDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("test")));

builder.Services.AddTransient<IAdminService, AdminService>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Jwt Using Authentication and Authorization . need to add after HttpRedirection and 
// before MapControllers .
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
