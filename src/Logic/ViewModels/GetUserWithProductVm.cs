using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModels;
public class GetUserWithProductVm
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public List<GetProductVm> ProductVm { get; set; }
}
public class GetProductVm
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}

