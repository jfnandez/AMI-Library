using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeAVC
    {
        public readonly Mode Type;
        public readonly Bool State;
        public readonly Servo Servo;

        private ModeAVC(
            Mode mode,
            Bool state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }

        public static ModeAVC GetSeqMode()
        {
            return new ModeAVC(Mode.CONTINUOUS, Bool.TRUE, Servo.WIREFEED);
        }
    }
}
