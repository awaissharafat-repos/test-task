using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Interfaces;
using TestTask.Models.DTOs;

namespace TestTask.BLL.Services
{
    public class ProductService : IProductService
    {
        private IProductRepo _productRepo;
        private ISessionManager _sessionManager;
        private IMapper _mapper;

        public ProductService(IProductRepo productRepo, ISessionManager sessionManager)
        {
            _productRepo = productRepo;
            _sessionManager = sessionManager;
        }

        public IEnumerable<AllProductsDTO> GetAllProducts(string Name)
        {
            return _productRepo.GetAllProducts(Name);
        }

        public SingleProductDTO GetProductById(int ProductId)
        {
            return _productRepo.GetProductById(ProductId);
        }

        public void AddProduct(SingleProductDTO model)
        {
            model.CreatedBy = _sessionManager.GetUserId();
            _productRepo.AddProduct(model);
        }
        public void DeleteProduct(int ProductId)
        {
            _productRepo.DeleteProduct(ProductId);
        }

        public bool ProductExistsByName(string Name, int ProductId)
        {
            return _productRepo.ProductExistsByName(Name,ProductId);
        }
    }
}
