using System.IO;
using System.Xml.Serialization;

namespace Xml
{
    public static class SerializerService
    {
        public static T DeserializeToObject<T>(string filepath) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using var sr = new StreamReader(filepath);
            return (T) ser.Deserialize(sr);
        }

        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            var xmlSerializer = new XmlSerializer(anyobject.GetType());

            using var writer = new StreamWriter(xmlFilePath);
            xmlSerializer.Serialize(writer, anyobject);
        }
    }
}