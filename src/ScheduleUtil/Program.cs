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

        struct UnixTimestampRange
        {
            long start;
            long end;
        }

        struct RepeatableTimeRange
        {
            long baseTimestamp;
            long duration;
            long repeatInterval;
            long cutoffTimestamp;
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
        /// Please implement this function, which returns a list of Daylight Saving Time (DST) ranges, in given year range
        ///     Range.start = when DST starts (in the form of unixTimestamp)
        ///     Range.end = when DST ends
        /// For each year, you need to find out when DST starts/ends at the given timezone,
        ///     then convert that time to unixTimestamp
        /// </summary>
        private static List<UnixTimestampRange> GetListOfDST(string timeZoneText, int yearStart, int yearEnd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Please implement this function, which converts a schedule in a certain timezone to a list of equivalent repeatable time ranges.
        /// A RepeatableTimeRange defines a time range that repeats itself for a definite number of times:
        ///     baseTimestamp: the first unixTimestamp when the schedule is active
        ///     duration: the schedule is active until baseTimestamp + duration
        ///     repeatInterval: the schedule is active again from baseTimestamp + repeatInterval, to baseTimestamp + repeatInterval + duration, and keep repeating itself
        ///     cutoffTimestamp: the schedule is inactive forever after this time
        /// yearStart & yearEnd: the list of RepeatableTimeRange should be covering these years
        /// Important notes: treat all timezone as if they don't have DST (otherwise it will be really complicated, because repeatable time ranges will be wrong when crossing DST start/end date)
        /// For example, a daily schedule will yield a list of only one element (for which repeatInterval = 3600*24)
        ///     Another example, a weekly schedule will yield a list of several elements, depending on how many time ranges are there in the schedule.
        ///     A monthly schedule isn't really repeatable because each month have different days. And it's not even repeatable on a yearly scale because, there are leap years.
        ///         So, for a monthly schedule, you need to generate one time range for each of the month, and set repeatInterval = duration, cutoffTimestamp = baseTimestamp + duration
        /// </summary>
        private static List<RepeatableTimeRange> ConvertScheduleToTimeRanges(Schedule schedule, string timeZoneText, int yearStart, int yearEnd)
        {
            throw new NotImplementedException();
        }
    }
}