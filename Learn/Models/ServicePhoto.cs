using System;
using System.Collections.Generic;

#nullable disable

namespace Learn.Models
{
    public partial class ServicePhoto
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
