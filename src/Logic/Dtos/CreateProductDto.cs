using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Dtos;
public class CreateProductDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}
public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}
