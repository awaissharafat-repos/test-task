using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.Interfaces
{
    public interface ISessionManager
    {
        int GetUserDetailId();
        int GetUserId();
        string GetUserName();

        public void SetUserDetailId(int Id);
        public void SetUserId(int Id);
        public void SetUserName(string name);


    }
}
