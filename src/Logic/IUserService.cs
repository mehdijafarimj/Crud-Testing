using Domain;
using Infrastructure;
using Logic.Dtos;
using Logic.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Logic;
public interface IUserService
{
    List<GetAllUserVm> GetAll();
    GetUserWithProductVm GetUserWithProduct(int userProductId);
    User GetById(int id);
    void Add(CreateUserDto dto);
    void Update(UpdateUserDto dto);
    void Delete(int Id);
    User GetByNationalCode(string nationalCode);
}
public class UserService : IUserService
{
    private readonly CrudDbContext _context;
    public UserService(CrudDbContext context)
    {
        _context = context;
    }

    public List<GetAllUserVm> GetAll()
    {
        var users = _context.Users
            .Select(i => new GetAllUserVm()
            {
                Name = i.Name,
                LastName = i.LastName,
                Age = i.Age
            }).ToList();

        return users;
    }

    public GetUserWithProductVm GetUserWithProduct(int userProductId)
    {
        var user = _context.Users
            .Include(i => i.Products)
            .Where(i => i.Id == userProductId)
            .Select(i => new GetUserWithProductVm()
            {
                Name = i.Name,
                LastName = i.LastName,
                ProductVm = i.Products.Select(i => new GetProductVm()
                {
                    Name = i.Name,
                    Price = i.Price,
                    Description = i.Description
                }).ToList()
            }).FirstOrDefault();

        return user;
    }

    public User GetById(int id)
    {
        var user = _context.Users.Where(i => i.Id == id)
            .Select(i => new User
            {
                Id = i.Id,
                Name = i.Name,
                LastName = i.LastName,
                Address = i.Address,
                NationalCode = i.NationalCode
            }).FirstOrDefault();

        return user;
    }

    public void Add(CreateUserDto dto)
    {
        User user = new User();
        user.Name = dto.Name;
        user.LastName = dto.LastName;
        user.Password = dto.Password;
        user.Age = dto.Age;
        user.Address = dto.Address;
        user.NationalCode = dto.NationalCode;
        user.AdminId = dto.AdminId;

        _context.Users.Add(user);
        _context.SaveChanges();
    }
     
    public void Update(UpdateUserDto dto)
    {
        User user = new User();
        user.Id = dto.Id;
        user.Name = dto.Name;
        user.LastName = dto.LastName;
        user.Password = dto.Password;
        user.Age = dto.Age;
        user.Address = dto.Address;
        user.NationalCode = dto.NationalCode;
        user.AdminId = dto.AdminId;

        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int Id)
    {
        User user = new User();
        user.Id = Id;

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User GetByNationalCode(string nationalCode)
    {
        var user = _context.Users.FirstOrDefault(i => i.NationalCode == nationalCode);
        return user!;
    }
}
