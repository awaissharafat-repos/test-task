using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.EntityModels;

namespace TestTask.Models.DTOs
{
    public class UserDetailDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public int UserDetailId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Phone { get; set; }

    }
}
