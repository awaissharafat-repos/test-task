using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using TestTask.BLL.Interfaces;

namespace TestTask.BLL.Services
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession Session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Session = _httpContextAccessor.HttpContext?.Session;
        }

        public int GetUserDetailId()
        {
            return Convert.ToInt32(Session.GetString("UserDetailId"));
        }

        public int GetUserId()
        {
            return Convert.ToInt32(Session.GetString("UserId"));
        }

        public string GetUserName()
        {
            return Convert.ToString(Session.GetString("UserName"));
        }

        public void SetUserDetailId(int Id)
        {
            Session.SetString("UserDetailId", Id.ToString());
        }

        public void SetUserId(int Id)
        {
            Session.SetString("UserId", Id.ToString());
        }

        public void SetUserName(string Name)
        {
            Session.SetString("UserName", Name);
        }
    }
}
