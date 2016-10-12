using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModePulse
    {
        public readonly Mode Type;
        public readonly Kind State;
        public readonly Servo Servo;

        private ModePulse(
            Mode mode,
            Kind state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }

        public static ModePulse On()
        {
            return new ModePulse(Mode.PULSE_MODE, Kind.ON, Servo.AVC);
        }
        public static ModePulse Off()
        {
            return new ModePulse(Mode.PULSE_MODE, Kind.OFF, Servo.AVC);
        }
        public static ModePulse External()
        {
            return new ModePulse(Mode.PULSE_MODE, Kind.EXTERNAL, Servo.AVC);
        }
        public static ModePulse Synchronous()
        {
            return new ModePulse(Mode.PULSE_MODE, Kind.SYNCHRONOUS, Servo.AVC);
        }
    }
}