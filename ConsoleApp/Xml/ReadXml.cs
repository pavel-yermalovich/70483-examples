using System;
using System.IO;
using System.Xml;

namespace ConsoleApp.Xml
{
    public class ReadXml
    {
        public static string xml = @"<?xml version =""1.0"" encoding =""utf - 8""?>
                         <people>
                            <person firstname =""pavel"" lastname =""yermalovich"">
                                <contactdetails>
                                    <emailaddress>pavel.yermalovich@dotmailer.com</emailaddress>
                               </contactdetails>
                            </person>
                            <person firstname =""jane"" lastname =""doe"">
                                <contactdetails>
                                    <emailaddress>jane@unknown.com</emailaddress>
                                    <phonenumber>001122334455</phonenumber>
                                </contactdetails>
                            </person>
                        </people>";

        public static void Example1()
        {
            using(var stringReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(stringReader,
                    new XmlReaderSettings { IgnoreWhitespace = true }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("people");

                    var firstName = xmlReader.GetAttribute("firstname");
                    var lastName = xmlReader.GetAttribute("lastname");

                    Console.WriteLine($"First name: {firstName}, last name: {lastName}");

                    xmlReader.ReadStartElement("person");
                    xmlReader.ReadStartElement("contactdetails");
                    var email = xmlReader.ReadString();

                    Console.WriteLine($"Email: {email}");
                }
            }
        }

        public static void Example2()
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            XmlNodeList nodes = document.GetElementsByTagName("person");

            foreach(XmlNode node in nodes)
            {
                Console.WriteLine($"First name: {node.Attributes["firstname"].Value}, "
                    + $"last name: {node.Attributes["lastname"].Value}");
            }
        }

        public static void Example3()
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var navigator = document.CreateNavigator();
            var query = "//people/person[@firstname='pavel']";
            var iterator = navigator.Select(query);

            Console.WriteLine(iterator.Count);

            while (iterator.MoveNext())
            {
                Console.WriteLine($"First name:{iterator.Current.GetAttribute("firstname", "")}, last name: {iterator.Current.GetAttribute("lastname", "")}");
            }
        }
    }
}
