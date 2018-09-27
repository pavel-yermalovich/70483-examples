using ConsoleApp.CSharp7;
using ConsoleApp.Xml;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read xml with XmlReader
            ReadXml.Example1();
            // Reads xml via XmlDocument
            ReadXml.Example2();
            // Query data via XPath query
            ReadXml.Example3();

            // How to use XmlWriter to create an xml document
            WriteXml.Example1();

            PatternVariables.Example1();
            PatternVariables.Example2();
        }
    }
}
