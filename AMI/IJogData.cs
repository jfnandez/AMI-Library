using System;

namespace AMI
{
    public interface IJogData
    {
        TimeSpan Minimum { get; }
        TimeSpan Maximum { get; }
        bool IgnoreRestriction { get; set; }

        bool IsWithinLimits(TimeSpan timeSpan);
    }
}
