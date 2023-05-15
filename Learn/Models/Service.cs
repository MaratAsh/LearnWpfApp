using System;
using System.Collections.Generic;

#nullable disable

namespace Learn.Models
{
    public partial class Service
    {
        public Service()
        {
            Appointments = new HashSet<Appointment>();
            ServicePhotos = new HashSet<ServicePhoto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Discount { get; set; }
        public int Duration { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<ServicePhoto> ServicePhotos { get; set; }
    }
}
