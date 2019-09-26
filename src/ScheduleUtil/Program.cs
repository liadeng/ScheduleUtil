using System;
using System.Collections.Generic;

namespace ScheduleUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            // this schedule will be active during 2000/01/01 and 9999/12/31, every day during 7:30 and 18:00
            var dailyScheduleExample = new Schedule
            {
                StartDate = 20000101,
                EndDate = 99991231,
                Mode = 0,
                DailyStart = 730,
                DailyEnd = 1800,
            };

            // this schedule will be active during 2019/09/01 and 2020/10/01, every week on these days/time_ranges: TUE 2:00-4:00 TUE 6:00-18:00 TUE 20:00-22:00 THU 0:00-24:00 FRI 8:00-20:00
            var weeklyScheduleExample = new Schedule
            {
                StartDate = 20190901,
                EndDate = 20201001,
                Mode = 1,
                WeeklyString = "[[],[{\"start\":\"200\",\"end\":\"400\"},{\"start\":\"600\",\"end\":\"1800\"},{\"start\":\"2000\",\"end\":\"2200\"}],[],[{\"start\":\"0\",\"end\":\"2400\"}],[{\"start\":\"800\",\"end\":\"2000\"}],[],[]]",
            };

            // active every month on day 2, 3, 7, 9 from 8:00 to 18:30
            var monthlyScheduleExample = new Schedule
            {
                StartDate = 20190901,
                EndDate = 20201001,
                Mode = 2,
                MonthlyString = "[2,3,7,9]",
                MonthlyStart = 800,
                MonthlyEnd = 1830,
            };

            bool isActive = IsScheduleActiveAtGivenTime(weeklyScheduleExample, 1569511207, "Eastern Standard Time");
        }

        struct TimeDifference
        {
            long unixStart;
            long unixEnd;
            long diffSeconds;
        }

        struct SimpleSchedule
        {
            /// <summary>
            /// the schedule is only active during this unixtimestamp range. (assume it's in UTC timezone)
            /// </summary>
            long effectiveStart;
            long effectiveEnd;

            /// <summary>
            /// the schedule is only active on this day of the week (value range 0-6, a value of -1 means it can be any day of week)
            /// </summary>
            int dayOfWeek;

            /// <summary>
            /// the schedule is only active on this day of the Month (value range 0-30, a value of -1 means it can be any day of month)
            /// </summary>
            int dayOfMonth;

            /// <summary>
            /// the schedule is only active from dailyStartSeconds to dailyEndSeconds (value range 0 - 3600*24)
            /// </summary>
            int dailyStartSeconds;
            int dailyEndSeconds;
        }

        /// <summary>
        /// Please implement this function, which returns if a schedule is active at a certain local time
        /// You need to convert unixTimestamp/timeZoneText to local time, 
        ///     then extract year/month/day/hour/minute info from the local time object,
        ///     and finally check if the schedule is active at this time
        /// </summary>
        private static bool IsScheduleActiveAtGivenTime(Schedule schedule, long unixTimestamp, string timeZoneText)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneText);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Please implement this function, which returns a list of TimeDifference
        /// A TimeDifference is defined as the difference seconds between UTC and Local time during a specific range of time.
        ///     unixStart & unixEnd: when this TimeDifference will be effective
        ///     diffSeconds: should satisfy: unixTimestamp + diffSeconds --> treat this time as new unixTimestamp and convert it to UTC_DateTime, it will equal to LocalDateTime(unixTimestamp, timeZone)
        /// yearStart & yearEnd: the returned list should cover EVERY SINGLE SECOND in these years.
        /// Tips: each year, when daylight saving time (DST) is enabled/disabled, you would need a new TimeDifference object.
        ///     For time zones without DST, the List contains only one TimeDifference object.
        /// </summary>
        private static List<TimeDifference> GetListOfTimeDifference(string timeZoneText, int yearStart, int yearEnd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Please implement this function, which converts a schedule to its equivalent list of simple schedules.
        /// For example, a daily schedule will yield a list of only one element (dayOfWeek = -1, dayOfMonth = -1)
        /// Another example, a weekly/monthly schedule will yield many elements, depending on how many time ranges are there in the schedule.
        /// </summary>
        private static List<SimpleSchedule> GetSimplifiedSchedules(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}