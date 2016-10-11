using System;
using System.Reflection;

namespace AMI
{
    [AttributeUsage(AttributeTargets.Struct)]
    internal partial class JogAttribute : Attribute
    {
        public JogAttribute(
            TimeSpan minimum,
            TimeSpan maximum,
            bool ignoreRestriction = false)
        {
            Minimum = minimum;
            Maximum = maximum;
            IgnoreRestriction = ignoreRestriction;
        }

        public JogAttribute(
            uint minimumMilliseconds,
            uint maximumMilliseconds,
            bool ignoreRestriction = false)
            : this(
                minimum: TimeSpan.FromMilliseconds((double)minimumMilliseconds),
                maximum: TimeSpan.FromMilliseconds((double)maximumMilliseconds),
                ignoreRestriction: ignoreRestriction)
        {
        }
    }

    internal partial class JogAttribute : IJogData
    {
        public TimeSpan Minimum { get; private set; }
        public TimeSpan Maximum { get; private set; }
        public bool IgnoreRestriction { get; set; }

        public bool IsWithinLimits(TimeSpan timeSpan)
        {
            if (IgnoreRestriction)
            {
                return true;
            }
            else
            {
                var aboveMinimum = Minimum <= timeSpan;
                var belowMaximum = Maximum >= timeSpan;

                return aboveMinimum && belowMaximum;
            }
        }
    }
}
