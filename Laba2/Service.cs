using System.Collections.Generic;

namespace Laba2
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Service() => ServiceRequest = new HashSet<ServiceRequest>();

        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
