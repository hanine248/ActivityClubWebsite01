using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.DTOs
{
    public class EventDTO
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

        // Foreign key for User
        public int? Userid { get; set; }
    }

}
