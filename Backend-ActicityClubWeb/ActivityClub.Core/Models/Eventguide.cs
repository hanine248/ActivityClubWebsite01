using System;
using System.Collections.Generic;

namespace ActivityClub.Core.Models;

public partial class EventGuide
{
    public int Eventguideid { get; set; }

    public int? Eventid { get; set; }

    public int? Guideid { get; set; }

    public virtual Event? Event { get; set; }
    public virtual Guide? Guide { get; set; }
}
