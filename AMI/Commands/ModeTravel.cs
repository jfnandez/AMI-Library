using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeTravel
    {
        public readonly Mode Type;
        public readonly Kind State;
        public readonly Servo Servo;

        private ModeTravel(
            Mode mode,
            Kind state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }
    }
}
