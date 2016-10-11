using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeServo
    {
        public readonly Mode Type;
        public readonly Bool State;
        public readonly Servo Servo;

        private ModeServo(
            Mode mode,
            Bool state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }

        public static ModeServo GetSeqMode()
        {
            return new ModeServo(Mode.ALL_STOP, Bool.TRUE, Servo.WIREFEED);
        }
    }

    public partial struct ModeServo : IXmlSerializable
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
            writer.WriteStartElement("ServoMode");
            {
                var map = EnumCodeDictionary<Mode>.Forward;
                writer.WriteAttributeString("type", map[Type]);
            }
            {
                var map = EnumCodeDictionary<Bool>.Forward;
                writer.WriteAttributeString("state", map[State]);
            }
            {
                var map = EnumCodeDictionary<Servo>.Forward;
                writer.WriteAttributeString("servo", map[Servo]);
            }
            writer.WriteEndElement();
        }
    }
}
