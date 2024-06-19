using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Xml;

namespace ScadaCore
{
    public class XmlSerializationHelper
    {
        public static void SerializeTagsToXml(Dictionary<string, Tag> tags, string filePath)
        {
            // Create a wrapper object
            var tagCollection = new TagCollection(tags);

            // Use DataContractSerializer to serialize the wrapper object
            var serializer = new DataContractSerializer(typeof(TagCollection));

            // Write to XML file
            using (var writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 }))
            {
                serializer.WriteObject(writer, tagCollection);
            }
        }

        public static Dictionary<string, Tag> DeserializeTagsFromXml(string filePath)
        {
            Dictionary<string, Tag> tags = new Dictionary<string, Tag>();

            // Use DataContractSerializer to deserialize the XML file
            var serializer = new DataContractSerializer(typeof(TagCollection));

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var tagCollection = (TagCollection)serializer.ReadObject(stream);

                    // Convert List<Tag> to Dictionary<string, Tag>
                    foreach (var tag in tagCollection.TagsList)
                    {
                        tags[tag.Name] = tag;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during deserialization: {ex.Message}");
            }

            return tags;
        }
    }
}