using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands.Reply
{
    public partial struct ACK 
    {
        public string Code { get; private set; }
        public Error Error { get; private set; }
    }

    public partial struct ACK : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            var document = new XmlDocument();
            document.Load(reader);

            var sCode = document.SelectSingleNode("ACK").Name;
            var sError = document.SelectSingleNode("ErrorCode").Name;

            Code = sCode;
            Error = EnumCodeDictionary<Error>.Reverse[sError];
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
