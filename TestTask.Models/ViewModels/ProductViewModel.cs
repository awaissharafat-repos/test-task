using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.DTOs;

namespace TestTask.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<AllProductsDTO> AllProducts { get; set; }
        public SingleProductDTO SingleProduct { get; set; }
    }
}
