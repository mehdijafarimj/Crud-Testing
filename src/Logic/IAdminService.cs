using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;
public interface IAdminService
{
    public void Add(string name, string userName, int age, string password, string email, string address);
    public void Update(int Id, string name, string userName, int age, string password, string email, string address);  
    public void Delete(int Id);
}
public class AdminService : IAdminService
{
    private readonly CrudDbContext _context;
    public AdminService(CrudDbContext context)
    {
        _context = context;
    }
    public void Add(string name, string userName, int age, string password, string email, string address)
    {
        Admin admin = new Admin();
        admin.Name = name;
        admin.UserName = userName;
        admin.Age = age;
        admin.Password = password;
        admin.Email = email;
        admin.Address = address;

        _context.Admins.Add(admin);
        _context.SaveChanges();
    }
    
    public void Update(int Id, string name, string userName, int age, string password, string email, string address)
    {
        Admin admin = new Admin();
        admin.Id = Id;
        admin.Name=name;
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