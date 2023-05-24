using System;

namespace iQuest.VendingMachine
{
    internal class TimeInterval
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentOutOfRangeException(nameof(endTime), "End time must be grater than start time.");
            }

            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
