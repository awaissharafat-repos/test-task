using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.DTOs;

namespace TestTask.BLL.Interfaces
{
    public interface ILoginService
    {
        UserDetailDTO AuthenticateUser(string Email, string Password);
    }
}
