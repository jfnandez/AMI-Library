using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModePulse
    {
        public readonly Mode Type;
        public readonly Bool State;
        public readonly Servo Servo;

        private ModePulse(
            Mode mode,
            Bool state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }

        public static ModePulse GetSeqMode()
        {
            return new ModePulse(Mode.ON, Bool.TRUE, Servo.WIREFEED);
        }
    }
}
