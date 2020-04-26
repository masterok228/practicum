namespace Laba2
{
    public partial class ServiceRequest
    {
        public int ServiceId { get; set; }
        public int RequestId { get; set; }

        public virtual Request Request { get; set; }
        public virtual Service Service { get; set; }
    }
}
