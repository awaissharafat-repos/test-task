using System;
using System.Collections.Generic;

namespace TestTask.Models.EntityModels;

public partial class SYS_User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<SYS_UserDetail> SYS_UserDetails { get; set; } = new List<SYS_UserDetail>();
}
