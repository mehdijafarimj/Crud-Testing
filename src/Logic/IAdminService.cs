using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;
public interface IAdminService
{
    List<Admin> GetAll();
    void Add(string name,string lastName, string userName, int age, string password, string email, string address);
    void Update(int Id, string name,string lastName, string userName, int age, string password, string email, string address);  
    void Delete(int Id);    
}
public class AdminService : IAdminService
{
    private readonly CrudDbContext _context;
    public AdminService(CrudDbContext context)
    {
        _context = context;
    }

    public List<Admin> GetAll()
    {
        var admins = _context.Admins.ToList();
        return admins;
    }

    public void Add(string name,string lastName, string userName, int age, string password, string email, string address)
    {
        Admin admin = new Admin();
        admin.Name = name;
        admin.LastName = lastName;
        admin.UserName = userName;
        admin.Age = age;
        admin.Password = password;
        admin.Email = email;
        admin.Address = address;

        _context.Admins.Add(admin);
        _context.SaveChanges();
    }
    
    public void Update(int Id, string name,string lastName, string userName, int age, string password, string email, string address)
    {
        Admin admin = new Admin();
        admin.Id = Id;
        admin.Name=name;
        admin.LastName = lastName;
        admin.UserName = userName;
        admin.Age = age;
        admin.Password = password;
        admin.Email = email;
        admin.Address = address;

        _context.Admins.Update(admin);
        _context.SaveChanges();
    }

    public void Delete(int Id)
    {
        Admin admin = new Admin();
        admin.Id = Id;

        _context.Admins.Remove(admin);
        _context.SaveChanges();
    }

}