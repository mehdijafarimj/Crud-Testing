using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;
public interface IProductService
{
    public void Add(string name,double price,string description);
    public void Update(int Id,string name, double price, string description);
    public void Delete(int Id);
}
public class ProductService : IProductService
{
    private readonly CrudDbContext _context;
    public ProductService(CrudDbContext context)
    {
        _context = context;
    }
    public void Add(string name, double price, string description)
    {
        Product product = new Product();
        product.Name = name;
        product.Price = price;
        product.Description = description;
        _context.Products.Add(product);
        _context.SaveChanges();
    }
    
    public void Update(int Id,string name, double price, string description)
    {
        Product product = new Product();
        product.Id = Id;
        product.Name = name;
        product.Price = price;
        product.Description = description;

        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(int Id)
    {
        Product product = new Product();
        product.Id = Id;

        _context.Products.Remove(product);
        _context.SaveChanges();
    }

}
