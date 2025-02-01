using System;
using System.Collections.Generic;

namespace TestTask.Models.EntityModels;

public partial class SYS_UserDetail
{
    public int UserDetailId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DOB { get; set; }

    public string Phone { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual SYS_User User { get; set; } = null!;
}
