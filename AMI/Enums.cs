namespace AMI
{
    public enum Bool
    {
        [EnumCodeAttribute("FALSE")]
        FALSE,

        [EnumCodeAttribute("TRUE")]
        TRUE
    };
    public enum Jog
    {
        [EnumCodeAttribute("JOG_FWD")]
        FORWARD,

        [EnumCodeAttribute("JOG_REV")]
        REVERSE,

        [EnumCodeAttribute("JOG_STOP")]
        STOP
    };
    public enum Manipulator
    {
        [EnumCodeAttribute("1")]
        UP_DOWN,

        [EnumCodeAttribute("2")]
        LEFT_RIGHT
    }
    public enum Override
    {
        [EnumCodeAttribute("DELTA")]
        DELTA,

        [EnumCodeAttribute("COMMAND")]
        COMMAND,

        [EnumCodeAttribute("PERCENTAGE")]
        PERCENTAGE
    };
    public enum Parameter
    {
        [EnumCodeAttribute("Gas Flow")]
        GAS_FLOW,

        //[EnumCodeAttribute("Head Pos")]
        //HEAD_POSITION,

        [EnumCodeAttribute("Heat Input")]
        HEAT_INPUT
    };
    public enum Servo
    {
        [EnumCodeAttribute("AVC")]
        AVC,

        [EnumCodeAttribute("Amps")]
        AMPS,

        [EnumCodeAttribute("CrossSeam")]
        CROSS_SEAM,

        [EnumCodeAttribute("Hotwire")]
        HOTWIRE,

        [EnumCodeAttribute("Osc")]
        OSCILLATION,

        [EnumCodeAttribute("Travel")]
        TRAVEL,

        [EnumCodeAttribute("Wirefeed")]
        WIREFEED
    }
}

namespace AMI.Commands
{
    public partial struct ModeAVC
    {
        public enum Mode
        {
            [EnumCodeAttribute("AVC_MODE")]
            AVC_MODE
        }

        public enum Kind
        {
            [EnumCodeAttribute("AVC_OFF")]
            OFF,

            [EnumCodeAttribute("AVC_CONT")]
            CONTINUOUS,

            [EnumCodeAttribute("AVC_SAMPPRI")]
            SAMPLING_PRIMARY,

            [EnumCodeAttribute("AVC_SAMPBAC")]
            SAMPLING_BACKGROUND
        };
    }
    public partial struct ModePulse
    {
        public enum Mode
        {
            [EnumCodeAttribute("PULSE_MODE")]
            PULSE_MODE
        }

        public enum Kind
        {
            [EnumCodeAttribute("PULSE_ON")]
            ON,

            [EnumCodeAttribute("PULSE_OFF")]
            OFF,

            [EnumCodeAttribute("PULSE_EXT")]
            EXTERNAL,

            [EnumCodeAttribute("PULSE_SYNC")]
            SYNCHRONOUS
        };
    }
    public partial struct ModeSequence
    {
        public enum Mode
        {
            [EnumCodeAttribute("SEQ_START")]
            START,

            [EnumCodeAttribute("SEQ_STOP")]
            STOP,

            [EnumCodeAttribute("ALL_STOP")]
            ALL_STOP,

            [EnumCodeAttribute("MAN_ADV")]
            MANUAL_ADVANCE,

            [EnumCodeAttribute("MAN_DEADV")]
            MANUAL_DEADVANCE,

            [EnumCodeAttribute("CLEAR_FAULT")]
            CLEAR_FAULT
        };
    }
    public partial struct ModeServo
    {
        public enum Mode
        {
            [EnumCodeAttribute("OSC_MAN")]
            OSCILLATION_MANUAL,

            [EnumCodeAttribute("TVL_CW")]
            TRAVEL_CLOCKWISE,

            [EnumCodeAttribute("WIRE_AUTO")]
            WIREFEED_AUTOMATIC
        };
    }
    public partial struct ModeSystem
    {
        public enum Mode
        {
            [EnumCodeAttribute("LAMPS_ON")]
            LAMPS_ON,

            [EnumCodeAttribute("MAN_PURGE_ON")]
            PURGE_MANUAL,

            [EnumCodeAttribute("WELD_MODE")]
            WELD_MODE
        };

    }
    public partial struct ModeTravel
    {
        public enum Mode
        {
            [EnumCodeAttribute("TRAVEL_MODE")]
            TRAVEL_MODE
        }

        public enum Kind
        {
        };
    }
}

namespace AMI.Commands.Reply
{
    public enum Error
    {
        [EnumCodeAttribute("\"0x00\"")]
        COMMAND_SUCCEEDED,

        [EnumCodeAttribute("\"0x01\"")]
        INVALID_COMMAND_TYPE,

        [EnumCodeAttribute("\"0x02\"")]
        INVALID_COMMAND_SYNTAX,

        [EnumCodeAttribute("\"0x08\"")]
        SCHEDULE_NOT_LOADED,

        [EnumCodeAttribute("\"0x09\"")]
        SYSTEM_FAULT_PRESENT,

        [EnumCodeAttribute("\"0x0A\"")]
        SYSTEM_IN_SEQUENCE,

        [EnumCodeAttribute("\"0x0B\"")]
        SYSTEM_NOT_WELDING,

        [EnumCodeAttribute("\"0x0C\"")]
        SYSTEM_IN_ALREADY_DOWNSLOPE,

        [EnumCodeAttribute("\"0x10\"")]
        INVALID_STATE_COMMAND,

        [EnumCodeAttribute("\"0x20\"")]
        INVALID_STATE_SERVO_NAME,

        [EnumCodeAttribute("\"0x21\"")]
        INVALID_COMMAND_FOR_NAMED_SERVO,

        [EnumCodeAttribute("\"0x30\"")]
        INVALID_DURATION_PARAMETER,

        [EnumCodeAttribute("\"0x40\"")]
        INVALID_MANIPULATOR_NUMBER,

        [EnumCodeAttribute("\"0x50\"")]
        INVALID_LEVEL_VALUE,

        [EnumCodeAttribute("\"0x51\"")]
        INVALID_OVERRIDE_TYPE,

        [EnumCodeAttribute("\"0x52\"")]
        VALUE_OUTSIDE_ALLOWABLE_RANGE,

        [EnumCodeAttribute("\"0x53\"")]
        VALUE_ALREADY_AT_LIMIT,

        [EnumCodeAttribute("\"0x60\"")]
        INVALID_GROUP_NAME,

        [EnumCodeAttribute("\"0x61\"")]
        INVALID_SCHEDULE_NAME,

        [EnumCodeAttribute("\"0x62\"")]
        INVALID_PASS_NUMBER
    }
}