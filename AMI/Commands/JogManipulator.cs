using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;
using System.Globalization;

namespace AMI.Commands
{
    [JogAttribute(
        minimumMilliseconds: 10,
        maximumMilliseconds: 30000)]
    public partial struct JogManipulator
    {
        public static readonly IJogData JogData;

        static JogManipulator()
        {
            JogData = typeof(JogManipulator).GetCustomAttribute<JogAttribute>();
        }
    }
    public partial struct JogManipulator
    {
        public readonly Jog Jog;
        public readonly Manipulator? Manipulator;
        public readonly TimeSpan? Duration;

        private JogManipulator(
            Jog jog,
            Manipulator? manipulator,
            TimeSpan? duration)
        {
            if (duration.HasValue)
                if (!JogData.IsWithinLimits(duration.Value))
                    throw new ArgumentOutOfRangeException();

            Jog = jog;
            Manipulator = manipulator;
            Duration = duration;
        }

        public static JogManipulator Stop()
        {
            return new JogManipulator(Jog.STOP, null, null);
        }

        public static JogManipulator Forward(
            Manipulator manipulator,
            TimeSpan? duration = null)
        {
            return new JogManipulator(Jog.FORWARD, manipulator, duration);
        }

        public static JogManipulator Reverse(
            Manipulator manipulator,
            TimeSpan? duration = null)
        {
            return new JogManipulator(Jog.REVERSE, manipulator, duration);
        }
    }
    public partial struct JogManipulator : IXmlSerializable
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
            writer.WriteStartElement("ManipJog");
            {
                var map = EnumCodeDictionary<Jog>.Forward;
                writer.WriteAttributeString("jog", map[Jog]);
            }
            if (Manipulator.HasValue)
            {
                var map = EnumCodeDictionary<Manipulator>.Forward;
                writer.WriteAttributeString("manipulator", map[Manipulator.Value]);
            }
            if (Duration.HasValue)
            {
                var uDuration = (uint)Duration.Value.TotalMilliseconds;
                var sDuration = uDuration.ToString(CultureInfo.InvariantCulture);
                writer.WriteAttributeString("duration", sDuration);
            }
            writer.WriteEndElement();
        }
    }
}
