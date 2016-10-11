using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeTravel
    {
        public readonly Mode Type;
        public readonly Bool State;
        public readonly Servo Servo;

        private ModeTravel(
            Mode mode,
            Bool state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }

        public static ModeTravel GetSeqMode()
        {
            return new ModeTravel(Mode.OFF, Bool.TRUE, Servo.WIREFEED);
        }
    }
}
