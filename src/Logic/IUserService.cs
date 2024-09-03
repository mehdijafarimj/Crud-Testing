using Domain;
using Infrastructure;
using Logic.Dtos;
using Logic.ViewModels;

namespace Logic;
public interface IUserService
{
    List<GetAllUserViewModel> GetAll();
    User GetById(int id);
    void Add(CreateUserDto dto);
    void Update(UpdateUserDto dto);
    void Delete(int Id);
}
public class UserService : IUserService
{
    private readonly CrudDbContext _context;
    public UserService(CrudDbContext context)
    {
        _context = context;
    }

    public List<GetAllUserViewModel> GetAll()
    {
        var users = _context.Users
            .Select(i => new GetAllUserViewModel()
            {
                Name = i.Name,
                Family = i.LastName,
                Age = i.Age
            }).ToList();

        return users;
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
        user.Age = dto.Age;
        user.Address = dto.Address;
        user.NationalCode = dto.NationalCode;

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(UpdateUserDto dto)
    {
        User user = new User();
        user.Id = dto.Id;
        user.Name = dto.Name;
        user.LastName = dto.LastName;
        user.Age = dto.Age;
        user.Address = dto.Address;
        user.NationalCode = dto.NationalCode;

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
}
