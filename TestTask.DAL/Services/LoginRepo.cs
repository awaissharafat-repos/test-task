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
using TestTask.Models.EntityModels;
using TestTask.Utilities;

namespace TestTask.DAL.Services
{
    public class LoginRepo : ILoginRepo
    {
        private readonly string _connectionString;

        public LoginRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public UserDetailDTO AuthenticateUser(string Email, string Password)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new { Email = Email, Password = Password };

                var UserDetail = dbConnection.QuerySingleOrDefault<UserDetailDTO>(
                    "dbo.[sproc_UserLogin]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return UserDetail;
            }
        }
    }
}
