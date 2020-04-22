using System.Collections.Generic;

namespace Laba2
{
    public partial class Сlient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Сlient() => Requests = new HashSet<Request>();

        public virtual ICollection<Request> Requests { get; set; }
    }
}
