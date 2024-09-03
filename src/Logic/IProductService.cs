using Domain;
using Infrastructure;
using Logic.Dtos;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;
public interface IProductService
{
    List<Product> GetAll();
    Product GetById(int Id);
    void Add(CreateProductDto dto);
    void Update(UpdateProductDto dto);
    void Delete(int Id);
}
public class ProductService : IProductService
{
    private readonly CrudDbContext _context;
    public ProductService(CrudDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        var products = _context.Products.ToList();
        return products;    
    }

    public Product GetById(int id)
    {
        var product = _context.Products.Where(i => i.Id == id)
            .Select(i => new Product
        {
            Id = i.Id,
            Name = i.Name,
            Price = i.Price,
            Description = i.Description
        }).FirstOrDefault();

        return product;
    }

    public void Add(CreateProductDto dto)
    {
        Product product = new Product();
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Description = dto.Description;

        _context.Products.Add(product);
        _context.SaveChanges();
    }
    
    public void Update(UpdateProductDto dto)
    {
        Product product = new Product();
        product.Id = dto.Id;
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Description = dto.Description;

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
