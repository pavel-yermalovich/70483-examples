using System;
using System.IO;
using System.Xml;

namespace ConsoleApp.Xml
{
    public class ReadXml
    {
        public static void Example1()
        {
            string xml = @"<?xml version =""1.0"" encoding =""utf - 8""?>
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
    }
}
