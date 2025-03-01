using System;
using System.Collections.Generic;

namespace ActivityClub.Core.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
