using System;
using System.Collections.Generic;

#nullable disable

namespace Learn.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
    }
}
