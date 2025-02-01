using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Interfaces;
using TestTask.Models.DTOs;
using static TestTask.DAL.Services.ProductRepo;
using TestTask.Models.ViewModels;

namespace TestTask.DAL.Services
{
    public class ProductRepo : IProductRepo
    {
        private readonly string _connectionString;

        public ProductRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<AllProductsDTO> GetAllProducts(string Name)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new { Name = Name };

                dbConnection.Open();
                var Products = dbConnection.Query<AllProductsDTO>(
                    "sproc_GetAllProducts",
                    new { Name = Name },
                    commandType: CommandType.StoredProcedure
                );
                return Products;
            }
        }

        public SingleProductDTO GetProductById(int ProductId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new { ProductId = ProductId };

                dbConnection.Open();
                var Product = dbConnection.QueryFirstOrDefault<SingleProductDTO>(
                    "sproc_GetProductById",
                    new { ProductId = ProductId },
                    commandType: CommandType.StoredProcedure
                );
                return Product;
            }
        }

        public void AddProduct(SingleProductDTO product)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var parameters = new
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CreatedBy = product.CreatedBy
                };

                dbConnection.Execute("sproc_InsertProduct", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProduct(int ProductId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var parameters = new { ProductId = ProductId };

                dbConnection.Execute("sproc_DeleteProduct", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ProductExistsByName(string Name, int ProductId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                var parameters = new { Name = Name, ProductId = ProductId};

                var exists = dbConnection.ExecuteScalar<int>(
                    "SELECT COUNT(1) FROM [dbo].[SYS_Products] WHERE [Name] = @Name AND ProductId != @ProductId AND [IsActive] = 1",
                    parameters
                );

                return exists > 0; // Return true if count is greater than 0
            }
        }
    }
}
