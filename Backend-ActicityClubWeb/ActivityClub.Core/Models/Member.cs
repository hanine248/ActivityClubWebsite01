using System;
using System.Collections.Generic;

namespace ActivityClub.Core.Models;

public partial class Member
{
    public int Memberid { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    //public byte[]? Photo { get; set; }

    public string? Nationality { get; set; }

    public string? Profession { get; set; }

    public int? Phonenumber { get; set; }

    public int? Roleid { get; set; }

    public DateOnly? Datejoining { get; set; }

    public int? EmergencyNumber { get; set; }

    public virtual ICollection<EventMember> EventMembers { get; set; } = new List<EventMember>();

    public virtual User MemberNavigation { get; set; } = null!;

    public virtual Role? Role { get; set; }
}
