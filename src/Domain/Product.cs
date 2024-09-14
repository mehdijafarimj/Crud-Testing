using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public virtual Admin Admin { get; set; }
    public int? AdminId { get; set; }
    public virtual User User { get; set; }
    public int? UserProductId { get; set; }
}
