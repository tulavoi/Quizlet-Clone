using System;
using System.Linq.Expressions;

namespace QuizletClone.Extensions
{
    public static class DatetimeExtensions
    {
        public static string ToRelativeTime(this DateTime createdAt)
        {
            var now = DateTime.UtcNow;
            var timespan = now - createdAt;

            // Switch expression
            return timespan.TotalDays switch
            {
                >= 365 => $"{(int)(timespan.TotalDays / 365)} năm trước",
                >= 30 => $"{(int)(timespan.TotalDays / 30)} tháng trước",
                >= 7 => $"{(int)(timespan.TotalDays / 7)} tuần trước",
                >= 1 => $"{(int)(timespan.TotalDays)} ngày trước",
                _ => timespan.TotalHours switch
                {
                    >= 1 => $"{(int)(timespan.TotalHours)} giờ trước",
                    >= 1 / 60.0 => $"{(int)(timespan.TotalMinutes)} phút trước",
                    _ => "Vừa xong"
                }
            };
        }

        public static string GetTimeCategory(DateTime lastUpdated, DateTime now)
        {
            if (lastUpdated.Date == now.Date) return "HÔM NAY";
            else if (lastUpdated.Date >= now.Date.AddDays(-7))
                return "TUẦN NÀY";
            else if (lastUpdated.Date >= now.Date.AddDays(-14) && lastUpdated.Date < now.Date.AddDays(-7))
                return "TUẦN TRƯỚC";
            else if (lastUpdated.Date.Year == now.Date.Year && lastUpdated.Date.Month == now.Date.Month)
                return "THÁNG NÀY";

            return $"THÁNG {lastUpdated.Month} NĂM {lastUpdated.Year}";
        }
    }
}
