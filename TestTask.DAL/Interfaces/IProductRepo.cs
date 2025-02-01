using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.DTOs;

namespace TestTask.DAL.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<AllProductsDTO> GetAllProducts(string Name);
        SingleProductDTO GetProductById(int ProductId);
        void AddProduct(SingleProductDTO product);
        void DeleteProduct(int ProductId);
        bool ProductExistsByName(string Name, int ProductId);
    }
}
