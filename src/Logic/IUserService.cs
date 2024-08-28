using Domain;
using Infrastructure;

namespace Logic;
public interface IUserService
{
    public void Add(string name, string lastName, int age, string address, string nationalCode);
    public void Update(int Id, string name, string lastName, int age, string address, string nationalCode);
    public void Delete(int Id);
}
public class UserService : IUserService
{
    private readonly CrudDbContext _context;
    public UserService(CrudDbContext context)
    {
        _context = context;
    }
    public void Add(string name, string lastName, int age, string address, string nationalCode)
    {
        User user = new User();
        user.Name = name;
        user.LastName = lastName;
        user.Age = age;
        user.Address = address;
        user.NationalCode = nationalCode;

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int Id, string name, string lastName, int age, string address, string nationalCode)
    {
        User user = new User();
        user.Id = Id;
        user.Name = name;
        user.LastName = lastName;
        user.Age = age;
        user.Address = address;
        user.NationalCode = nationalCode;

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
