using System;
using System.Collections.Generic;

namespace ActivityClub.Core.Models;

public partial class EventMember
{
    public int Eventmemberid { get; set; }

    public int? Eventid { get; set; }

    public int? Memberid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Member? Member { get; set; }
}
