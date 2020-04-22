using System.Collections.Generic;

namespace Laba2
{
    public partial class Request
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public Request() => ServiceRequest = new HashSet<ServiceRequest>();

        public virtual Сlient Сlient { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
