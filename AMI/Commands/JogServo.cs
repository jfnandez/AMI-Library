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
    public partial struct JogServo
    {
        public static readonly IJogData JogData;

        static JogServo()
        {
            JogData =  typeof(JogServo).GetCustomAttribute<JogAttribute>();
        }
    }
    public partial struct JogServo
    {
        public readonly Jog Jog;
        public readonly Servo? Servo;
        public readonly TimeSpan? Duration;

        private JogServo(
            Jog jog,
            Servo? servo,
            TimeSpan? duration)
        {
            if (duration.HasValue)
                if (!JogData.IsWithinLimits(duration.Value))
                    throw new ArgumentOutOfRangeException();

            Jog = jog;
            Servo = servo;
            Duration = duration;
        }

        public static JogServo Stop()
        {
            return new JogServo(Jog.STOP, null, null);
        }

        public static JogServo Forward(
            Servo servo,
            TimeSpan? duration = null)
        {
            return new JogServo(Jog.FORWARD, servo, duration);
        }

        public static JogServo Reverse(
            Servo servo,
            TimeSpan? duration = null)
        {
            return new JogServo(Jog.REVERSE, servo, duration);
        }
    }
    public partial struct JogServo : IXmlSerializable
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
            writer.WriteStartElement("JogServo");
            {
                var map = EnumCodeDictionary<Jog>.Forward;
                writer.WriteAttributeString("jog", map[Jog]);
            }
            if (Servo.HasValue)
            {
                var map = EnumCodeDictionary<Servo>.Forward;
                writer.WriteAttributeString("servo", map[Servo.Value]);
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
