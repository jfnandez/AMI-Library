using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeSystem
    {
        public readonly Mode Type;
        public readonly Bool State;

        private ModeSystem(Mode mode, Bool state)
        {
            Type = mode;
            State = state;
        }

        public static ModeSystem LampsOn()
        {
            return new ModeSystem(Mode.LAMPS, Bool.TRUE);
        }
        public static ModeSystem LampsOff()
        {
            return new ModeSystem(Mode.LAMPS, Bool.FALSE);
        }
        public static ModeSystem PurgeManualOn()
        {
            return new ModeSystem(Mode.PURGE, Bool.FALSE);
        }
        public static ModeSystem PurgeManualOff()
        {
            return new ModeSystem(Mode.PURGE, Bool.FALSE);
        }
        public static ModeSystem OscillationAutoOn()
        {
            return new ModeSystem(Mode.OSC, Bool.FALSE);
        }
        public static ModeSystem OscillationAutoOff()
        {
            return new ModeSystem(Mode.OSC, Bool.FALSE);
        }
    }

    public partial struct ModeSystem : IXmlSerializable
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
            writer.WriteStartElement("ModeCommand");
            {
                var map = EnumCodeDictionary<Mode>.Forward;
                writer.WriteAttributeString("type", map[Type]);
            }
            {
                var map = EnumCodeDictionary<Bool>.Forward;
                writer.WriteAttributeString("state", map[State]);
            }
            writer.WriteEndElement();
        }
    }
}
