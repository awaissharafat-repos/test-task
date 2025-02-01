using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.DTOs;
using TestTask.Models.EntityModels;

namespace TestTask.DAL.Interfaces
{
    public interface ILoginRepo
    {
        UserDetailDTO AuthenticateUser(string Email, string Password);
    }
}
