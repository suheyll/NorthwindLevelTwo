using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.Extensions.Primitives;

namespace MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
       
    }
}
