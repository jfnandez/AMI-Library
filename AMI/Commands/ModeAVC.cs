using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AMI.Commands
{
    public partial struct ModeAVC
    {
        public readonly Mode Type;
        public readonly Kind State;
        public readonly Servo Servo;

        private ModeAVC(
            Mode mode,
            Kind state,
            Servo servo)
        {
            Type = mode;
            State = state;
            Servo = servo;
        }

        public static ModeAVC Off()
        {
            return new ModeAVC(Mode.AVC_MODE, Kind.OFF, Servo.AVC);
        }
        public static ModeAVC Continuous()
        {
            return new ModeAVC(Mode.AVC_MODE, Kind.CONTINUOUS, Servo.AVC);
        }
        public static ModeAVC SamplingPrimary()
        {
            return new ModeAVC(Mode.AVC_MODE, Kind.SAMPLING_PRIMARY, Servo.AVC);
        }
        public static ModeAVC SamplingBackground()
        {
            return new ModeAVC(Mode.AVC_MODE, Kind.SAMPLING_BACKGROUND, Servo.AVC);
        }
    }
}