using System.Runtime.Serialization;

namespace Laba2
{
    [DataContract]
    public class Model
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
