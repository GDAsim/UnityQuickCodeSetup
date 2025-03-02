using System.IO;
using System.Xml.Serialization;

public static class XMLExtension
{
    public static string XMLSerialize<T>(this T toSerialize)
    {
        var xml = new XmlSerializer(typeof(T));
        var writer = new StringWriter();
        xml.Serialize(writer, toSerialize);

        return writer.ToString();
    }
    public static T XMLDeserialize<T>(this string toDeserialize)
    {
        var xml = new XmlSerializer(typeof(T));
        var reader = new StringReader(toDeserialize);

        return (T)xml.Deserialize(reader);
    }
}