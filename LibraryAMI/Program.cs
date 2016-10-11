using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


using CMD = AMI.Commands;

namespace LibraryAMI
{
    class Program
    {
        private static string Print(IXmlSerializable node)
        {
            var result = null as string;

            var settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.OmitXmlDeclaration = true;

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWritter = XmlWriter.Create(stringWriter, settings))
                {
                    node.WriteXml(xmlWritter);
                }

                result = stringWriter.ToString();
            }

            return result;
        }

        static void Main(string[] args)
        {
            var s = CMD.ModeSequence.Start();            

            Console.WriteLine(Print(s));

            Console.ReadKey();
        }
    }
}
