using System;
using System.IO;
using System.Xml;

namespace ConsoleApp.Xml
{
    public class WriteXml
    {
        public static void Example1()
        {
            var stream = new StringWriter();
            using(var writer = XmlWriter.Create(
                stream, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Products");
                writer.WriteStartElement("Product");
                writer.WriteAttributeString("Id", "123");
                writer.WriteAttributeString("Name", "Samsung Galaxy S8+");
                writer.WriteStartElement("Details");
                writer.WriteElementString("Price", "$599");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }

            Console.WriteLine(stream.ToString());
        }
    }
}
