using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dtos;
public class CreateProductDtoForAdmin
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int AdminId { get; set; }
}
public class CreateProductDtoForUser
{
    public string Name { set; get; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int UserProductId { get; set; }
}
public class UpdateProductDtoForAdmin
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int? AdminId { get; set; }
}
public class UpdateProductDtoForUser
{
    public int Id { get; set; }
    public string Name { set; get; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int? UserProductId { get; set; }
}

