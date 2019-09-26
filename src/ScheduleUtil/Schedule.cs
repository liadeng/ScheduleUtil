using System;
using System.Collections.Generic;

namespace ScheduleUtil
{
    /// <summary>
    /// Schedules are TimeZone independent, it must always be used together with a TimeZone to be specific.
    /// It's like when you tell your cellphone "Wake me up tomorrow at 7:00 AM", the cellphone will wake you up at 7 in your TimeZone.
    /// If the timezone information is not given, there is no way for the cellphone to know when to trip the alarm
    /// </summary>
    class Schedule
    {
        /// <summary>
        /// Usage: The schedule will only be active during this date range
        /// Encoded as year * 10000 + month * 100 + day, for example, 2019/09/26 = 20190926
        /// </summary>
        public int StartDate { get; set; }

        public int EndDate { get; set; }

        /// <summary>
        /// Usage: decide how the schedule repeats.
        /// Mode == 0 means it repeats Daily
        /// Mode == 1 means it repeats Weekly
        /// Mode == 2 means it repeats Monthly
        /// </summary>
        public int Mode { get; set; }

        /// <summary>
        /// Usage: only used when Mode == 0, the schedule will only be active during this time range
        /// Encoded as hour * 100 + miniute, for example, 14:30 = 1430
        /// </summary>
        public int DailyStart { get; set; }

        public int DailyEnd { get; set; }

        /// <summary>
        /// Usage: only used when Mode == 1, the schedule will only be active during centain days/time_range of every week
        /// Format: will be formatted as a json string like this: [[{"start":0730,"end":1800}, {}, ...], [], [], ...]
        ///     The outter most array has 7 elements, representing each day of the week (the first element is Monday)
        ///         Each element is an array of {start,end} objects, each of the object represents a time range in that day of week that the schedule will be active
        /// </summary>
        public string WeeklyString { get; set; }

        /// <summary>
        /// Usage: only used when Mode == 2, the schedule will only be active on these days of every month
        /// Format: will be formatted as a json string like this: [1,2,3,...,31]
        /// </summary>
        public string MonthlyString { get; set; }

        /// <summary>
        /// Usage: only used when Mode == 2, the schedule will only be active during this time range
        /// </summary>
        public int MonthlyStart { get; set; }

        public int MonthlyEnd { get; set; }
    }
}
