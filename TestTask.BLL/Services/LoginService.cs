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
    public class LoginService : ILoginService
    {
        private ILoginRepo _loginrepo;
        private IMapper _mapper;

        public LoginService(ILoginRepo loginrepo)
        {
            _loginrepo = loginrepo;
        }

        public UserDetailDTO AuthenticateUser(string Email, string Password)
        {
            return _loginrepo.AuthenticateUser(Email, Password);
        }
    }
}
