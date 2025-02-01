using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.DTOs;

namespace TestTask.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<AllProductsDTO> GetAllProducts(string Name);
        SingleProductDTO GetProductById(int ProductId);
        void AddProduct(SingleProductDTO model);
        void DeleteProduct(int ProductId);
        bool ProductExistsByName(string Name, int ProductId);
    }
}
