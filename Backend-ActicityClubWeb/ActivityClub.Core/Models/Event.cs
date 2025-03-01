using System;
using System.Collections.Generic;

namespace ActivityClub.Core.Models;

public partial class Event
{
    public int Eventid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Destination { get; set; }

    public DateOnly? Datefrom { get; set; }

    public DateOnly? Dateto { get; set; }

    public decimal? Cost { get; set; }

    public string? Status { get; set; }

    public int? Userid { get; set; }

    public virtual ICollection<EventGuide> EventGuides { get; set; } = new List<EventGuide>();

    public virtual ICollection<EventMember> EventMembers { get; set; } = new List<EventMember>();
}
