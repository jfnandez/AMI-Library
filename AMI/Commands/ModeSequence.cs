using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeSequence
    {
        public readonly Mode Type;

        private ModeSequence(Mode type)
        {
            Type = type;
        }

        public static ModeSequence Start()
        {
            return new ModeSequence(Mode.START);
        }
        public static ModeSequence Stop()
        {
            return new ModeSequence(Mode.STOP);
        }
        public static ModeSequence AllStop()
        {
            return new ModeSequence(Mode.ALL_STOP);
        }
        public static ModeSequence ManualAdvance()
        {
            return new ModeSequence(Mode.MANUAL_ADVANCE);
        }
        public static ModeSequence ManualDeadvance()
        {
            return new ModeSequence(Mode.MANUAL_DEADVANCE);
        }
        public static ModeSequence ClearFaults()
        {
            return new ModeSequence(Mode.CLEAR_FAULTS);
        }
    }

    public partial struct ModeSequence : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
			throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SeqCommand");

            {
                var map = EnumCodeDictionary<Mode>.Forward;
                writer.WriteAttributeString("type", map[Type]);
            }

            writer.WriteEndElement();
        }
    }
}
