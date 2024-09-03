using Domain;
using Infrastructure;
using Logic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;
public interface IAdminService
{
    List<Admin> GetAll();
    Admin GetById(int Id);
    void Add(CreateAdminDto dto);
    void Update(UpdateAdminDto dto);  
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

    public Admin GetById(int id)
    {
        var admin = _context.Admins.Where(i => i.Id == id)            
            .Select(i => new Admin
            {
               Id = i.Id,
               Name = i.Name,
               LastName = i.LastName,
               UserName = i.UserName,
               Age = i.Age,
               Password = i.Password,
               Email = i.Email,
               Address = i.Address
            }).FirstOrDefault();        
 
        return admin;
    }

    public void Add(CreateAdminDto dto)
    {
        Admin admin = new Admin();
        admin.Name = dto.Name;
        admin.LastName = dto.LastName;
        admin.UserName = dto.UserName;
        admin.Age = dto.Age;
        admin.Password = dto.Password;
        admin.Email = dto.Email;
        admin.Address = dto.Address;

        _context.Admins.Add(admin);
        _context.SaveChanges();
    }
    
    public void Update(UpdateAdminDto dto)
    {
        Admin admin = new Admin();
        admin.Id = dto.Id;
        admin.Name=dto.Name;
        admin.LastName = dto.LastName;
        admin.UserName = dto.UserName;
        admin.Age = dto.Age;
        admin.Password = dto.Password;
        admin.Email = dto.Email;
        admin.Address = dto.Address;

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