using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ScadaCore
{
    [DataContract]
    public class TagCollection
    {
        [DataMember]
        public List<Tag> TagsList { get; set; }

        public TagCollection(Dictionary<string, Tag> tags)
        {
            TagsList = new List<Tag>(tags.Values);
        }

        // Default constructor required for serialization
        public TagCollection()
        {
            TagsList = new List<Tag>();
        }
    }
}